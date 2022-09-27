using Core.CoreModels;
using Core.DomainModels;
using Validate.BusinessLogic.ValidationRules.PaymentValidationRules;

namespace Validate.BusinessLogic
{
    public static class ValidationRuleFactory
    {
        public static IEnumerable<IPaymentValidationRule> GetPaymentRules(DocumentType documentType)
        {
            return documentType switch
            {
                DocumentType.NetsOsInfo => GetPaymentValidationRules<Payment>(),
                DocumentType.NetsOs => GetPaymentValidationRules<Payment>(),
                //_ => GetValidationRules<Payment>()
                _ => throw new ArgumentOutOfRangeException(nameof(documentType), documentType, null)
            };
        }

        private static IEnumerable<IPaymentValidationRule> GetPaymentValidationRules<T>()
        where T: Payment
        {
            var types = AppDomain.CurrentDomain.GetAssemblies().Where(ass => ass.IsDynamic == false)
                .SelectMany(s => s.GetTypes())
                .Where(p => typeof(IPaymentValidationRule)
                    .IsAssignableFrom(p)  && !p.IsAbstract && !p.IsInterface);
            return types.Select(validation => Activator.CreateInstance(validation) as IPaymentValidationRule).ToList();
        }
    }
}
