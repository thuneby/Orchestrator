using BlobAccess.DataAccessLayer.Helpers;
using Core.CoreModels;
using DocumentAccess.DocumentAccessLayer;
using ExternalModels.MasterCard.Bs601Model;
using FileHelpers;
using Parse.BusinessLogic.Helpers;
using Parse.BusinessLogic.Mappers.Bs601;
using Parse.Models.Bs601Format;

namespace Parse.BusinessLogic
{
    public class ParseBs601: IAsyncParser
    {
        private readonly IStorageHelper _storageHelper;
        private readonly IDocumentRepository _documentRepository;
        private readonly ILogger<ParseBs601> _logger;

        public ParseBs601(IStorageHelper storageHelper, IDocumentRepository documentRepository, ILoggerFactory loggerFactory)
        {
            _storageHelper = storageHelper;
            _documentRepository = documentRepository;
            _logger = loggerFactory.CreateLogger<ParseBs601>();
        }

        public async Task<Guid> Parse(Guid fileId, long tenantId)
        {
            var payload = await _storageHelper.GetPayload(fileId);
            var errors = new HashSet<string>();

            var engine = new MultiRecordEngine(typeof(BsStart), typeof(BsSectionStart), typeof(BsFixed22),
                    typeof(BsFixed2209), typeof(BsFixed2210),
                    typeof(BsFixed42), typeof(BsFixed52), typeof(BsFixed62), typeof(BsSectionEnd), typeof(BsEnd))
                { RecordSelector = NetsBsSelector };
            engine.ErrorManager.ErrorMode = ErrorMode.SaveAndContinue;

            var result = engine.ReadStream(new StreamReader(payload, EncodingHelper.GetEncoding(DocumentType.Bs601)));
            if (engine.ErrorManager.HasErrors)
                foreach (var error in engine.ErrorManager.Errors)
                {
                    var message = error.ExceptionInfo.Message;
                    _logger.LogError(message);
                    errors.Add(message);
                }

            if (errors.Any())
            {
                var exception = new Exception(errors.FirstOrDefault());
                throw exception;
            }

            if (result.Length == 0)
            {
                var errorMessage = "Error - The format is not BS601!";
                _logger.LogError(errorMessage);
                var exception = new Exception(errorMessage);
                throw exception;
            }

            var model = ParseRecordsIntoModel(result, tenantId, fileId);
            NetsBs601ParserHelper.SetForignKeys(model);

            // Save Model
            await _documentRepository.SaveModel(model);

            return model.Delivery601Start.Id;
        }


        private static FlatNetsBs601Model ParseRecordsIntoModel(object[] result, long tenantId, Guid fileId)
        {
            var model = new FlatNetsBs601Model();
            var deliveryStartMapper = new Delivery601StartMapper(tenantId);
            var sectionStartMapper = new Section0112StartMapper(tenantId);
            var bsRecord22Mapper = new BsRecord22Mapper(tenantId);
            var bsRecord2209Mapper = new BsRecord2209Mapper(tenantId);
            var bsRecord2210Mapper = new BsRecord2210Mapper(tenantId);
            var bsRecord42Mapper = new BsRecord42Mapper(tenantId);
            var bsRecord52Mapper = new BsRecord52Mapper(tenantId);
            var bsRecord62Mapper = new BsRecord62Mapper(tenantId);
            var sectionEndMapper = new Section0112EndMapper(tenantId);
            var deliveryEndMapper = new Delivery601EndMapper(tenantId);

            foreach (var record in result)
            {
                var recType = record.GetType();
                if (recType == typeof(BsStart))
                {
                    NetsBs601ParserHelper.AddBsStart(fileId, model, deliveryStartMapper, record);
                    continue;
                }
                if (recType == typeof(BsSectionStart))
                {
                    NetsBs601ParserHelper.AddSectionStart(model, sectionStartMapper, record);
                    continue;
                }
                if (recType == typeof(BsFixed22))
                {
                    NetsBs601ParserHelper.AddBsFixed22(model, bsRecord22Mapper, record);
                    continue;
                }
                if (recType == typeof(BsFixed2209))
                {
                    NetsBs601ParserHelper.AddBsFixed2209(model, bsRecord2209Mapper, record);
                    continue;
                }
                if (recType == typeof(BsFixed2210))
                {
                    NetsBs601ParserHelper.AddBsFixed2210(model, bsRecord2210Mapper, record);
                    continue;
                }
                if (recType == typeof(BsFixed42))
                {
                    NetsBs601ParserHelper.AddBsFixed42(model, bsRecord42Mapper, record);
                    continue;
                }
                if (recType == typeof(BsFixed52))
                {
                    NetsBs601ParserHelper.AddBsFixed52(model, bsRecord52Mapper, record);
                    continue;
                }
                if (recType == typeof(BsFixed62))
                {
                    NetsBs601ParserHelper.AddBsFixed62(model, bsRecord62Mapper, record);
                    continue;
                }
                if (recType == typeof(BsSectionEnd))
                {
                    NetsBs601ParserHelper.AddSectionEnd(model, sectionEndMapper, record);
                    continue;
                }
                if (recType == typeof(BsEnd))
                {
                    NetsBs601ParserHelper.AddBsEnd(model, deliveryEndMapper, record);
                }
            }

            return model;
        }


        private static Type? NetsBsSelector(MultiRecordEngine engine, string recordLine)
        {
            if (recordLine.Length == 0)
                return null;
            var recordType = recordLine.Substring(2, 3);
            var dataRecordNumber = recordLine.Substring(17, 5);
            switch (recordType)
            {
                case "002":
                    return typeof(BsStart);
                case "012":
                    return typeof(BsSectionStart);
                case "022":
                {
                    switch (dataRecordNumber)
                    {
                        case "00001":
                        case "00002":
                        case "00003":
                        case "00004":
                        case "00005":
                            return typeof(BsFixed22);
                        case "00009":
                            return typeof(BsFixed2209);
                        case "00010":
                            return typeof(BsFixed2210);
                        default:
                            return null;
                    }
                }
                case "042":
                    return typeof(BsFixed42);
                case "052":
                    return typeof(BsFixed52);
                case "062":
                    return typeof(BsFixed62);
                case "092":
                    return typeof(BsSectionEnd);
                case "992":
                    return typeof(BsEnd);
                default:
                    return null;
            }
        }
    }
}
