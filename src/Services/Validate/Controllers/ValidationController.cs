using Core.DomainModels;
using Microsoft.AspNetCore.Mvc;
using Validate.Dtos;

namespace Validate.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ValidationController: ControllerBase
    {
        [HttpPost("[Action]")]
        public async Task<ValidationResult> ValidatePayment(Payment payment)
        {
            return new ValidationResult
            {
                PaymentId = payment.Id,
                Valid = true
            };
        }

        [HttpPost("[Action]")]
        public async Task<IEnumerable<ValidationResult>> ValidatePaymentList(List<Payment> payments)
        {
            var result = new List<ValidationResult>();
            foreach (var payment in payments)
            {
                result.Add(await ValidatePayment(payment));
            }
            return result;
        }
    }
}
