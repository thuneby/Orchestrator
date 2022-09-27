using Core.DomainModels;
using DataAccess.DataAccess;

namespace Validate.BusinessLogic.ValidationRules.PaymentValidationRules
{
    public class ValidateDueDate: IPaymentValidationRule
    {
        public ValidationError? Validate(Payment entity, MasterDataRepository repository)
        {
            const string errorText = "Invalid Due date: ";
            if (entity.DueDate > DateTime.Today)
                return null;
            
            // ToDo Validate due date is a bank day using DateUtil

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
