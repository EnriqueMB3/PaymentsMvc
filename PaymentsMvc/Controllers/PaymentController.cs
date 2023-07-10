using Microsoft.AspNetCore.Mvc;
using PaymentsMvc.DAL;
using PaymentsMvc.Models;
using PaymentsMvc.Repositories;

namespace PaymentsMvc.Controllers
{
    [Route("[controller]/[action]")]
    public class PaymentController : Controller
    {
        private readonly PaymentContext _context;

        public PaymentController(PaymentContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            Payment_Repository payment_Repository = new Payment_Repository(_context);
            var payments = payment_Repository.GetPayments();
            return View(payments);
        }
        public IActionResult AddPayment()
        {
            return View();
        }

        public IActionResult AddPaymentAction(Payment payment )
        {
            Payment_Repository payment_Repository = new Payment_Repository(_context);
            payment_Repository.AddPayment(payment);
            return RedirectToAction("Index");
        }

        public IActionResult UpdatePayment(int? paymentId)
        {
            Payment_Repository payment_Repository = new Payment_Repository(_context);
            var paymentModel = payment_Repository.GetPayment(paymentId.Value);
            return View(paymentModel);
        }

        public IActionResult UpdatePaymentAction(Payment payment)
        {
            Payment_Repository payment_Repository = new Payment_Repository(_context);
            payment_Repository.UpdatePayment(payment);
            return RedirectToAction("Index");
        }

    }
}
