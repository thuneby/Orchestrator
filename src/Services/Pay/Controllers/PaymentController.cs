using Core.DomainModels;
using Microsoft.AspNetCore.Mvc;
using Pay.Models;

namespace Pay.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PaymentController: ControllerBase
    {
        [HttpPost("[Action]")]
        public ICollection<PaymentResult> RequestPayments(List<Payment> payments)
        {
            var paymentList = payments.Where(x => x.ReconcileStatus == ReconcileStatus.Open && x.Valid);
            return paymentList.Select(payment => new PaymentResult { PaymentId = payment.Id, Paid = true }).ToList();
        }
    }
}
