using PaymentsMvc.Models;
using PaymentsMvc.DAL;
namespace PaymentsMvc.Repositories
{
    public class Payment_Repository
    {
        private readonly PaymentContext _context;

        public Payment_Repository(PaymentContext context)
        {
            _context = context;
        }

        public IEnumerable<Payment> GetPayments()
        {
            return _context.Payments.ToList();
        }

        public void AddPayment(Payment payment)
        {
            _context.Add(payment);
            _context.SaveChanges();

        }

        public Payment GetPayment(int paymentId)
        {
            var paymentCopy = _context.Payments.FirstOrDefault(p => p.PaymentID == paymentId);
            return paymentCopy;
        }
        public void UpdatePayment(Payment payment)
        {
            var paymentCopy = _context.Payments.FirstOrDefault(p => p.PaymentID == payment.PaymentID);
            if (payment != null)
            {
                paymentCopy.Date = payment.Date;
                paymentCopy.PaymentName = payment.PaymentName;
                paymentCopy.Amount = payment.Amount;
            }
            _context.SaveChanges();
        }


        public void DeleteBulkPayments(Payment[] payments)
        {
            _context.RemoveRange(payments);
            _context.SaveChanges();
        }
    }
}