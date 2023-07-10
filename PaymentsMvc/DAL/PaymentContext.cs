using Microsoft.EntityFrameworkCore;
using PaymentsMvc.Models;
namespace PaymentsMvc.DAL
{
    public class PaymentContext : DbContext
    {

        public PaymentContext(DbContextOptions<PaymentContext> options) : base(options)
        {

        }

        public DbSet<Payment> Payments { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Payment>().ToTable("Payment");
        }
    }
}
