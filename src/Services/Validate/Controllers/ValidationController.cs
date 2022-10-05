using Core.CoreModels;
using Core.DomainModels;
using Core.Dtos;
using DataAccess.DataAccess;
using Microsoft.AspNetCore.Mvc;
using Validate.BusinessLogic;

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
        public async Task<ValidationResult> ValidatePayment(Payment payment)
        {
            
            var result = (await ValidatePaymentList(new List<Payment> { payment })).ToList();
            return result.First();
        }

        [HttpPost("[Action]")]
        public async Task<IEnumerable<ValidationResult>> ValidatePaymentList(List<Payment> payments)
        {
            if (!payments.Any())
                return new List<ValidationResult>();
            var documentType = payments.FirstOrDefault()?.DocumentType?? DocumentType.Basic;
            return _paymentValidator.ValidatePayments(payments, documentType);
        }
    }
}
