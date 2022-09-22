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
    }
}
