using Core.DomainModels;
using DataAccess.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace DataAccess.DataAccess
{
    public class PaymentRepository: GuidRepositoryBase<Payment>
    {
        private readonly DomainContext _context;
        private readonly ILogger<PaymentRepository> _logger;
        public PaymentRepository(DomainContext context, ILogger<PaymentRepository> logger) : base(context, logger)
        {
            _context = context;
            _logger = logger;
        }

        public async Task AddRange(List<Payment> paymentList)
        {
            if (!paymentList.Any())
                return;
            try
            {
                var paymentDetails = paymentList.SelectMany(x => x.PaymentDetails).ToList();
                _context.Payment.AddRange(paymentList);
                _context.PaymentDetail.AddRange(paymentDetails);
                await _context.SaveChangesAsync();
            }
            catch (Exception e)
            {
                _logger.LogError(e.Message, e, e.InnerException?.Message);
                throw;
            }
        }

        public async Task UpdateRange(List<Payment> paymentList)
        {
            if (!paymentList.Any())
                return;
            try
            {
                _context.Payment.UpdateRange(paymentList);
                await _context.SaveChangesAsync();
            }
            catch (Exception e)
            {
                _logger.LogError(e.Message, e, e.InnerException?.Message);
                throw;
            }
        }

        public IEnumerable<Payment> GetFromDocumentId(Guid documentId)
        {
            var payments = _context.Payment.Where(x => x.DocumentId == documentId).Include(x => x.PaymentDetails)
                .ToList();
            return payments;
        }
    }
}
