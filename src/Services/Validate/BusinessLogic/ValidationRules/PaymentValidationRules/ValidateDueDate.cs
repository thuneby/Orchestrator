using Core.DomainModels;
using DataAccess.DataAccess;
using Utilities.Dates;

namespace Validate.BusinessLogic.ValidationRules.PaymentValidationRules
{
    public class ValidateDueDate: IPaymentValidationRule
    {
        public ValidationError? Validate(Payment entity, MasterDataRepository repository)
        {
            const string errorText = "Invalid Due date: ";
            if (DateUtil.IsBusinessDay(entity.DueDate))
                return null;
            
            return new ValidationError
            {
                EntityId = entity.Id,
                EntityType = typeof(Payment).ToString(),
                TenantÍd = entity.TenantÍd,
                ErrorCode = ErrorCode.InvalidPaymentDate,
                ErrorMessage = errorText + entity.DueDate.ToString("yyyyMMdd")
            };
        }
    }
}
