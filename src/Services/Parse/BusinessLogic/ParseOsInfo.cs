using System.Data;
using BlobAccess.DataAccessLayer.Helpers;
using Core.Models;
using DocumentAccess.Models;
using ExternalModels.MasterCard.OsInfoModel;
using FileHelpers;
using Google.Api;
using Parse.BusinessLogic.Helpers;
using Parse.BusinessLogic.Mappers;
using Parse.Models.OsInfoFormat;

namespace Parse.BusinessLogic
{
    public class ParseOsInfo : IAsyncParser
    {
        private readonly IStorageHelper _storageHelper;
        private readonly DocumentContext _documentContext;  
        private readonly ILogger _logger;

        public ParseOsInfo(IStorageHelper storageHelper, DocumentContext documentContext, ILoggerFactory loggerFactory)
        {
            _storageHelper = storageHelper;
            _documentContext = documentContext;
            _logger = loggerFactory.CreateLogger<ParseOsInfo>();
        }

        public async Task<Guid> Parse(Guid fileId, long tenantId)
        {
            var payload = await _storageHelper.GetPayload(fileId.ToString());
            var errors = new List<string>();

            var engine = new MultiRecordEngine(
                typeof(OsInfoStartRecord), typeof(SectionStartRecord),
                typeof(OsRecordFixed00), typeof(OsRecordFixed01),
                typeof(OsRecordFixed02), typeof(OsRecordFixed03), 
                typeof(OsRecordFixed04), typeof(OsRecordFixed05), 
                typeof(OsRecordFixed10), typeof(SectionEndRecord),
                typeof(DataEndRecordA), typeof(DataEndRecordB)
                ) { RecordSelector = NetsOsSelector };
            engine.ErrorManager.ErrorMode = ErrorMode.SaveAndContinue;

            var result = engine.ReadStream(new StreamReader(payload, EncodingHelper.GetEncoding(DocumentType.NetsOs)));
            if (engine.ErrorManager.HasErrors) errors.AddRange(engine.ErrorManager.Errors.Select(error => error.ExceptionInfo.Message));
            if (errors.Any())
            {
                var exception = new DataException(errors.FirstOrDefault());
                throw exception;
            }
            if (result.Length == 0)
            {
                var exception = new DataException("Error - The format is not OS-Information!"); throw exception;
            }

            var model = ParseRecordsIntoModel(result, tenantId);
            
            // Fix model
            model = OrderModel(model);
            
            // Save Model
            await SaveModel(model);

            return model.OsInfoStart.Id;
        }

        private static FlatOsInfoModel OrderModel(FlatOsInfoModel model)
        {
            // Todo fix FK relations

            model.OsInfoEnd.OsStart = model.OsInfoStart;
            return model;
        }

        private async Task SaveModel(FlatOsInfoModel model)
        {
            try
            {
                _documentContext.OsInfoStart.Add(model.OsInfoStart);
                _documentContext.OsInfoEnd.Add(model.OsInfoEnd);
                _documentContext.OsSectionStart.AddRange(model.OsInfoSectionStartCollection);
                _documentContext.OsSectionEnd.AddRange(model.OsInfoSectionEndCollection);
                _documentContext.OsRecord00.AddRange(model.OsInfoRecord00Collection);
                _documentContext.OsRecord01.AddRange(model.OsInfoRecord01Collection);
                _documentContext.OsRecord02.AddRange(model.OsInfoRecord02Collection);
                _documentContext.OsRecord03.AddRange(model.OsInfoRecord03Collection);
                _documentContext.OsRecord04.AddRange(model.OsInfoRecord04Collection);
                _documentContext.OsRecord05.AddRange(model.OsInfoRecord05Collection);
                _documentContext.OsRecord10.AddRange(model.OsInfoRecord10Collection);
                await _documentContext.SaveChangesAsync();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        private static FlatOsInfoModel ParseRecordsIntoModel(object[] result, long tenantId)
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
                        model.OsInfoStart = osStartMapper.Map((OsInfoStartRecord) record);
                        break;
                    }
                    case OsInfoFixedRecordType.SectionStartRecord:
                        model.OsInfoSectionStartCollection.Add(osSectionStartMapper.Map((SectionStartRecord) record));
                        break;
                    case OsInfoFixedRecordType.OsRecordFixed00:
                        model.OsInfoRecord00Collection.Add(osRecord00Mapper.Map((OsRecordFixed00) record));
                        break;
                    case OsInfoFixedRecordType.OsRecordFixed01:
                        model.OsInfoRecord01Collection.Add(osRecord01Mapper.Map((OsRecordFixed01) record));
                        break;
                    case OsInfoFixedRecordType.OsRecordFixed02:
                        model.OsInfoRecord02Collection.Add(osRecord02Mapper.Map((OsRecordFixed02) record));
                        break;
                    case OsInfoFixedRecordType.OsRecordFixed03:
                        model.OsInfoRecord03Collection.Add(osRecord03Mapper.Map((OsRecordFixed03) record));
                        break;
                    case OsInfoFixedRecordType.OsRecordFixed04:
                        model.OsInfoRecord04Collection.Add(osRecord04Mapper.Map((OsRecordFixed04) record));
                        break;
                    case OsInfoFixedRecordType.OsRecordFixed05:
                        model.OsInfoRecord05Collection.Add(osRecord05Mapper.Map((OsRecordFixed05) record));
                        break;
                    case OsInfoFixedRecordType.OsRecordFixed10:
                        model.OsInfoRecord10Collection.Add(osRecord10Mapper.Map((OsRecordFixed10) record));
                        break;
                    case OsInfoFixedRecordType.SectionEndRecord:
                        model.OsInfoSectionEndCollection.Add(osSectionEndMapper.Map((SectionEndRecord) record));
                        break;
                    case OsInfoFixedRecordType.DataEndRecordA:
                        model.OsInfoEnd = osEndAMapper.Map((DataEndRecordA) record);
                        break;
                    case OsInfoFixedRecordType.DataEndRecordB:
                        model.OsInfoEnd = osEndBMapper.Map((DataEndRecordB) record);
                        break;
                    default:
                        throw new ArgumentOutOfRangeException();
                }

            }
            return model;

        }

        public static Type NetsOsSelector(MultiRecordEngine engine, string recordLine)
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
