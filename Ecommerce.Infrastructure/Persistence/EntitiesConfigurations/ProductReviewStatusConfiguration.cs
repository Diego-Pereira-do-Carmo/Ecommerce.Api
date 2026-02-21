
using Ecommerce.Domain.Entities;
using Ecommerce.Infrastructure.Persistence.EntitiesConfigurations.Base;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Ecommerce.Infrastructure.Persistence.EntitiesConfigurations
{
    internal class ProductReviewStatusConfiguration : BaseStatusEntityConfiguration<ProductReviewStatus>
    {
        public override void Configure(EntityTypeBuilder<ProductReviewStatus> builder)
        {
            base.Configure(builder);
            builder.ToTable("product_review_status");
        }
    }
}
