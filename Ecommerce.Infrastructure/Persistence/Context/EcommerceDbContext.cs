
using Ecommerce.Domain.Entities;
using Ecommerce.Infrastructure.Persistence.Extensions;
using Microsoft.EntityFrameworkCore;

namespace Ecommerce.Infrastructure.Persistence.Context
{
    public class EcommerceDbContext : DbContext
    {
        public EcommerceDbContext(DbContextOptions<EcommerceDbContext> options) : base(options)
        {
        }

        public DbSet<AccessProfile> AccessProfile { get; set; }
        public DbSet<AccessProfileUser> AccessProfileUser { get; set; }
        public DbSet<Address> Address { get; set; }
        public DbSet<Brand> Brand { get; set; }
        public DbSet<CartItem> CartItem { get; set; }
        public DbSet<Category> Category { get; set; }
        public DbSet<Coupon> Coupon { get; set; }
        public DbSet<Customer> Customer { get; set; }
        public DbSet<Email> Email { get; set; }
        public DbSet<EmailStatus> EmailStatus { get; set; }
        public DbSet<EntityMetadata> EntityMetadata { get; set; }
        public DbSet<Logistic> Logistics { get; set; }
        public DbSet<LogisticMethod> LogisticsMethod { get; set; }
        public DbSet<LogisticProvider> LogisticsProvider { get; set; }
        public DbSet<LogisticStatus> LogisticsStatus { get; set; }
        public DbSet<Order> Order { get; set; }
        public DbSet<OrderItem> OrderItem { get; set; }
        public DbSet<OrderStatus> OrderStatus { get; set; }
        public DbSet<Payment> Payment { get; set; }
        public DbSet<PaymentGateway> PaymentGateway { get; set; }
        public DbSet<PaymentMethod> PaymentMethod { get; set; }
        public DbSet<PaymentStatus> PaymentStatus { get; set; }
        public DbSet<Product> Product { get; set; }
        public DbSet<ProductAttribute> ProductAttribute { get; set; }
        public DbSet<ProductAttributeValue> ProductAttributeValue { get; set; }
        public DbSet<ProductCategory> ProductCategory { get; set; }
        public DbSet<ProductImage> ProductImage { get; set; }
        public DbSet<ProductReview> ProductReview { get; set; }
        public DbSet<ProductReviewImage> ProductReviewImage { get; set; }
        public DbSet<ProductReviewStatus> ProductReviewStatus { get; set; }
        public DbSet<ProductVariant> ProductVariant { get; set; }
        public DbSet<ProductVariantAttribute> ProductVariantAttribute { get; set; }
        public DbSet<Stock> Stock { get; set; }
        public DbSet<StockTransaction> StockTransaction { get; set; }
        public DbSet<StockTransactionReason> StockTransactionReason { get; set; }
        public DbSet<TemplateEmail> TemplateEmail { get; set; }
        public DbSet<User> User { get; set; }
        public DbSet<InvoiceStatus> InvoiceStatus { get; set; }
        public DbSet<Invoice> Invoice { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(EcommerceDbContext).Assembly);
            modelBuilder.ApplySeeders(typeof(EcommerceDbContext).Assembly);
        }
    }
}
