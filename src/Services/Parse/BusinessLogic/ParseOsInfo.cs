using System.Data;
using BlobAccess.DataAccessLayer.Helpers;
using Core.Models;
using DocumentAccess.Models;
using ExternalModels.MasterCard.OsInfoModel;
using FileHelpers;
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

        public async Task<Guid> Parse(Guid fileId)
        {
            var model = new FlatOsInfoModel();
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
                var exception = new DataException("Error - The formatet is not OS-Information!");
                throw exception;
            }

            ParseRecordsIntoModel(model, result);
            
            // Fix model
            var osInfoStart = OrderModel(model);
            // Save Model

            return model.OsInfoStart.Id;
        }

        private static OsInfoStart OrderModel(FlatOsInfoModel model)
        {
            // Todo fix relations
            return model.OsInfoStart;
        }

        private static FlatOsInfoModel ParseRecordsIntoModel(FlatOsInfoModel model, object[] result)
        {
            var osStartMapper = new OsInfoStartMapper();
            var osSectionStartMapper = new OsInfoSectionStartMapper();
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
                        break;
                    case OsInfoFixedRecordType.OsRecordFixed01:
                        break;
                    case OsInfoFixedRecordType.OsRecordFixed02:
                        break;
                    case OsInfoFixedRecordType.OsRecordFixed03:
                        break;
                    case OsInfoFixedRecordType.OsRecordFixed04:
                        break;
                    case OsInfoFixedRecordType.OsRecordFixed05:
                        break;
                    case OsInfoFixedRecordType.OsRecordFixed10:
                        break;
                    case OsInfoFixedRecordType.SectionEndRecord:
                        break;
                    case OsInfoFixedRecordType.DataEndRecordA:
                        break;
                    case OsInfoFixedRecordType.DataEndRecordB:
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
