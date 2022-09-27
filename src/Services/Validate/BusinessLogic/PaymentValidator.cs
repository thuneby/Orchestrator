using Core.CoreModels;
using Core.DomainModels;
using DataAccess.DataAccess;
using Validate.BusinessLogic.ValidationRules.PaymentValidationRules;
using Validate.Dtos;

namespace Validate.BusinessLogic
{
    public class PaymentValidator
    {
        private readonly MasterDataRepository _masterDataRepository; 
        public PaymentValidator(MasterDataRepository masterDataRepository)
        {
            _masterDataRepository = masterDataRepository;
        }
        
        public IEnumerable<ValidationResult> ValidatePayments(List<Payment> payments, DocumentType documentType)
        {
            if (!payments.Any())
                return new List<ValidationResult>();
            var resultList = new List<ValidationResult>();
            var rules = ValidationRuleFactory.GetPaymentRules(documentType).ToList();
            if (!rules.Any())
                return resultList;
            resultList.AddRange(from payment in payments let errors = Validate(payment, rules) select new ValidationResult { PaymentId = payment.Id, Valid = !errors.Any(), ValidationErrors = errors.Select(x => x.ErrorMessage).ToList() });

            return resultList;
        }

        private List<ValidationError> Validate(Payment payment, IEnumerable<IPaymentValidationRule> rules)
        {
            return rules.Select(rule => rule.Validate(payment, _masterDataRepository)).Where(error => error != null).ToList();
        }
    }
}
