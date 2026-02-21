
using Ecommerce.Domain.Entities.Base;
using Ecommerce.Domain.Enums;
using Ecommerce.Domain.Exceptions;
using Ecommerce.Domain.Utils;

namespace Ecommerce.Domain.Entities
{
    public class Coupon : BaseEntity
    {
        public string Code { get; private set; } = string.Empty;
        public decimal DiscountAmount { get; private set; }
        public DateTime StartDate { get; private set; }
        public DateTime ExpirationDate { get; private set; }
        public int UsageLimit { get; private set; }
        public decimal MinPurchaseAmount { get; private set; }
        public DiscountTypeEnum Type { get; private set; }
        public Guid? CategoryId { get; private set; }
        public Category? Category { get; private set; }

        protected Coupon() { }

        public Coupon(
        string code,
        decimal discountAmount,
        DateTime startDate,
        DateTime expirationDate,
        int usageLimit,
        decimal minPurchaseAmount,
        DiscountTypeEnum type,
        Guid userId,
        Guid? categoryId = null)
        {
            Update(code, discountAmount, startDate, expirationDate, usageLimit, minPurchaseAmount, type, userId, categoryId);
        }

        public void Update(
        string code,
        decimal discountAmount,
        DateTime startDate,
        DateTime expirationDate,
        int usageLimit,
        decimal minPurchaseAmount,
        DiscountTypeEnum type,
        Guid userId,
        Guid? categoryId = null)
        {
            Guard.AgainstNullOrEmpty(code, nameof(code));
            Guard.AgainstMinValue(discountAmount, 0.01m, nameof(discountAmount));
            Guard.AgainstMinValue(usageLimit, 1,nameof(usageLimit));
            Guard.AgainstMinValue(minPurchaseAmount, 0.01m, nameof(minPurchaseAmount));
            Guard.AgainstMinDate(startDate.Date, DateTime.UtcNow.Date, nameof(startDate));
            Guard.AgainstMinDate(expirationDate.Date, startDate.Date, nameof(expirationDate));

            if (type == DiscountTypeEnum.Percentage && discountAmount > 100)
                throw new DomainException("O desconto percentual não pode ser maior que 100%.");

            Code = code.Trim().ToUpper();
            DiscountAmount = discountAmount;
            StartDate = startDate;
            ExpirationDate = expirationDate;
            UsageLimit = usageLimit;
            MinPurchaseAmount = minPurchaseAmount;
            Type = type;
            CategoryId = categoryId;

            //SetUpdateMetadata(userId);
        }
    }
}
