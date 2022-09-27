using DataAccess.DataAccess;
using Microsoft.AspNetCore.Mvc;

namespace Administration.Controllers
{
    public class PaymentController : Controller
    {
        private readonly PaymentRepository _paymentRepository;

        public PaymentController(PaymentRepository paymentRepository)
        {
            _paymentRepository = paymentRepository;
        }

        public IActionResult Index()
        {
            var payments = _paymentRepository.GetQueryList();
            return View(payments);
        }
    }
}
