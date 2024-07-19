namespace Discount.gRPC.DataAccess
{
    public class DiscountContext : DbContext
    {
        public DbSet<Coupon> Coupons { get; set; }

        public DiscountContext(DbContextOptions<DiscountContext> options) : base(options) 
        {
        
        }
    }
}
