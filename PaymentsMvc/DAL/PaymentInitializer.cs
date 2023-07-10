using Microsoft.EntityFrameworkCore;
using PaymentsMvc.Models;

namespace PaymentsMvc.DAL
{
    public class PaymentInitializer
    {
        private readonly ModelBuilder modelBuilder;

        public PaymentInitializer(ModelBuilder modelBuilder)
        {
            this.modelBuilder = modelBuilder;
        }

        public static void Initialize(PaymentContext context)
        {
            // Look for any students.
            if (context.Payments.Any())
            {
                return;   // DB has been seeded
            }


            var payments = new Payment[]
            {
                new Payment{PaymentName="School",Amount=2000,Date=DateTime.Parse("2019-09-01")},
                new Payment{PaymentName="Hospital",Amount=45000,Date=DateTime.Parse("2017-09-01")},
                new Payment{PaymentName="Car",Amount=580,Date=DateTime.Parse("2018-09-01")},
                new Payment{PaymentName="Rent",Amount=1200,Date=DateTime.Parse("2017-09-01")},
                new Payment{PaymentName="Streaming",Amount=10,Date=DateTime.Parse("2017-09-01")},
                new Payment{PaymentName="Bus",Amount=5,Date=DateTime.Parse("2016-09-01")},
                new Payment{PaymentName="Hotel",Amount=230,Date=DateTime.Parse("2018-09-01")},
                new Payment{PaymentName="Food",Amount=300,Date=DateTime.Parse("2019-09-01")}
            };

            context.Payments.AddRange(payments);
            context.SaveChanges();
        }
    }
}
