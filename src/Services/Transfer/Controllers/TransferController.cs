using Microsoft.AspNetCore.Mvc;

namespace Transfer.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TransferController: ControllerBase
    {
        [HttpPost("[Action]")]
        public Guid TransferToRecepient()
        {
            return Guid.Empty;
        }
    }
}
