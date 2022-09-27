using Core.DomainModels;
using DataAccess.DataAccess;

namespace Validate.BusinessLogic.ValidationRules.PaymentValidationRules
{
    public class ValidateAgreement: IPaymentValidationRule
    {
        public ValidationError? Validate(Payment entity, MasterDataRepository repository)
        {
            const string errorText = "Unknown Agreement for PBSNumber: ";

            var pbsNumber = entity.PbsNumberRecepient;

            var valid = repository.IsValidPbsNumber(pbsNumber);
            if (valid)
                return null;

            return new ValidationError
            {
                EntityId = entity.Id,
                EntityType = typeof(Payment).ToString(),
                TenantÍd = entity.TenantÍd,
                ErrorCode = ErrorCode.UnknownAgreement,
                ErrorMessage = errorText + entity.PbsNumberRecepient
            };
        }
    }
}
