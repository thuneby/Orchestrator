using Core.CoreModels;
using Core.DomainModels;
using DataAccess.DataAccess;
using Microsoft.AspNetCore.Mvc;
using Validate.BusinessLogic;
using Validate.Dtos;

namespace Validate.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ValidationController: ControllerBase
    {
        private readonly PaymentValidator _paymentValidator;

        public ValidationController(MasterDataRepository masterDataRepository)
        {
            _paymentValidator = new PaymentValidator(masterDataRepository);
        }

        [HttpPost("[Action]")]
        public async Task<ValidationResult> ValidatePayment(Payment payment, DocumentType documentType)
        {
            var result = (await ValidatePaymentList(new List<Payment> { payment }, documentType)).ToList();
            return result.First();
        }

        [HttpPost("[Action]")]
        public async Task<IEnumerable<ValidationResult>> ValidatePaymentList(List<Payment> payments, DocumentType documentType)
        {
            return _paymentValidator.ValidatePayments(payments, documentType);
        }
    }
}
