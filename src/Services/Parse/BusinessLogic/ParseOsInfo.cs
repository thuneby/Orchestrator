using System.Data;
using BlobAccess.DataAccessLayer.Helpers;
using Core.CoreModels;
using DocumentAccess.DocumentAccessLayer;
using ExternalModels.MasterCard.OsInfoModel;
using FileHelpers;
using Parse.BusinessLogic.Helpers;
using Parse.BusinessLogic.Mappers;
using Parse.BusinessLogic.Mappers.OsInfo;
using Parse.Models.OsInfoFormat;
using Utilities.Encoding;

namespace Parse.BusinessLogic
{
    public class ParseOsInfo : IAsyncParser
    {
        private readonly IStorageHelper _storageHelper;
        private readonly IDocumentRepository _documentRepository;
        private readonly ILogger<ParseOsInfo> _logger;

        public ParseOsInfo(IStorageHelper storageHelper, IDocumentRepository documentRepository, ILoggerFactory loggerFactory)
        {
            _storageHelper = storageHelper;
            _documentRepository = documentRepository;
            _logger = loggerFactory.CreateLogger<ParseOsInfo>();
        }

        public async Task<Guid> Parse(Guid fileId, long tenantId)
        {
            var payload = await _storageHelper.GetPayload(fileId);
            var errors = new List<string>();

            var engine = new MultiRecordEngine(
                typeof(OsInfoStartRecord), typeof(SectionStartRecord),
                typeof(OsRecordFixed00), typeof(OsRecordFixed01),
                typeof(OsRecordFixed02), typeof(OsRecordFixed03), 
                typeof(OsRecordFixed04), typeof(OsRecordFixed05), 
                typeof(OsRecordFixed10), typeof(OsRecordFixed1116), 
                typeof(SectionEndRecord), 
                typeof(DataEndRecordA), typeof(DataEndRecordB)
                ) { RecordSelector = NetsOsSelector };
            engine.ErrorManager.ErrorMode = ErrorMode.SaveAndContinue;

            var result = engine.ReadStream(new StreamReader(payload, EncodingHelper.GetEncoding(DocumentType.NetsOs)));
            if (engine.ErrorManager.HasErrors) errors.AddRange(engine.ErrorManager.Errors.Select(error => error.ExceptionInfo.Message));
            if (errors.Any())
            {
                foreach (var error in errors)
                {
                    _logger.LogError(error);   
                }
                var exception = new DataException(errors.FirstOrDefault());
                throw exception;
            }
            if (result.Length == 0)
            {
                const string errorText = "Error - The format is not OS-Information!";
                var exception = new DataException(errorText); 
                throw exception;
            }

            var model = ParseRecordsIntoModel(result, tenantId, fileId);
            
            // Save Model
            await _documentRepository.SaveModel(model);

            return model.OsInfoStart.Id;
        }

        private static FlatOsInfoModel ParseRecordsIntoModel(object[] result, long tenantId, Guid fileId)
        {
            var model = new FlatOsInfoModel();
            var osStartMapper = new OsInfoStartMapper(tenantId);
            var osSectionStartMapper = new OsInfoSectionStartMapper(tenantId);
            var osRecord00Mapper = new OsInfoRecord00Mapper(tenantId);
            var osRecord01Mapper = new OsInfoRecord01Mapper(tenantId);
            var osRecord02Mapper = new OsInfoRecord02Mapper(tenantId);
            var osRecord03Mapper = new OsInfoRecord03Mapper(tenantId);
            var osRecord04Mapper = new OsInfoRecord04Mapper(tenantId);
            var osRecord05Mapper = new OsInfoRecord05Mapper(tenantId);
            var osRecord10Mapper = new OsInfoRecord10Mapper(tenantId);
            var osSectionEndMapper = new OsInfoSectionEndMapper(tenantId);
            var osEndAMapper = new OsInfoEndAMapper(tenantId);
            var osEndBMapper = new OsInfoEndBMapper(tenantId); 

            foreach (var record in result)
            {
                var type = OsInfoParserHelper.GetRecordType((OsBase)record);
                switch (type)
                {
                    case OsInfoFixedRecordType.DataStartRecord:
                    {
                        OsInfoParserHelper.AddDataStart(fileId, model, osStartMapper, record);
                        break;
                    }
                    case OsInfoFixedRecordType.SectionStartRecord:
                        OsInfoParserHelper.AddOsSectionStart(model, osSectionStartMapper, record);
                        break;
                    case OsInfoFixedRecordType.OsRecordFixed00:
                        OsInfoParserHelper.AddOsRecord00(model, osRecord00Mapper, record);
                        break;
                    case OsInfoFixedRecordType.OsRecordFixed01:
                        OsInfoParserHelper.AddOsRecord01(model, osRecord01Mapper, record);
                        break;
                    case OsInfoFixedRecordType.OsRecordFixed02:
                        OsInfoParserHelper.AddOsRecord02(model, osRecord02Mapper, record);
                        break;
                    case OsInfoFixedRecordType.OsRecordFixed03:
                        OsInfoParserHelper.AddOsRecord03(model, osRecord03Mapper, record);
                        break;
                    case OsInfoFixedRecordType.OsRecordFixed04:
                        OsInfoParserHelper.AddOsRecord04(model, osRecord04Mapper, record);
                        break;
                    case OsInfoFixedRecordType.OsRecordFixed05:
                        OsInfoParserHelper.AddOsRecord05(model, osRecord05Mapper, record);
                        break;
                    case OsInfoFixedRecordType.OsRecordFixed10:
                        OsInfoParserHelper.AddOsRecord10(model, osRecord10Mapper, record);
                        break;
                    case OsInfoFixedRecordType.OsRecordFixed1116:
                        break; // ToDo 
                    case OsInfoFixedRecordType.SectionEndRecord:
                        OsInfoParserHelper.AddOsSectionEnd(model, osSectionEndMapper, record);
                        break;
                    case OsInfoFixedRecordType.DataEndRecordA:
                        OsInfoParserHelper.AddDataEndA(model, osEndAMapper, record);
                        break;
                    case OsInfoFixedRecordType.DataEndRecordB:
                        OsInfoParserHelper.AddDataEndB(model, osEndBMapper, record);
                        break;
                    default:
                        throw new ArgumentOutOfRangeException();
                }
            }
            return model;

        }

        public static Type? NetsOsSelector(MultiRecordEngine engine, string recordLine)
        {
            if (recordLine.Length == 0)
                return null;
            var recordType = recordLine.Substring(2, 1);
            var infoRecordType = recordLine.Substring(8, 2);

            switch (recordType)
            {
                case "1":
                    return typeof(OsInfoStartRecord);
                case "A":
                    return typeof(SectionStartRecord);
                case "I":
                    return infoRecordType switch
                    {
                        "00" => typeof(OsRecordFixed00),
                        "01" => typeof(OsRecordFixed01),
                        "02" => typeof(OsRecordFixed02),
                        "03" => typeof(OsRecordFixed03),
                        "04" => typeof(OsRecordFixed04),
                        "05" => typeof(OsRecordFixed05),
                        "10" => typeof(OsRecordFixed10),
                        _ => null
                    };
                case "T":
                    return typeof(SectionEndRecord);
                case "9":
                {
                    var indicator = int.Parse(recordLine.Substring(5, 1));
                    return indicator switch
                    {
                        0 => typeof(DataEndRecordA),
                        9 => typeof(DataEndRecordB),
                        _ => null
                    };
                }
                default:
                    return null;
            }
        }
    }
}
