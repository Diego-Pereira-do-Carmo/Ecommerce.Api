
using Ecommerce.Domain.Utils;

namespace Ecommerce.Domain.ValueObjects
{
    public record DimensionsValueObject
    {
        private const decimal _cubicMetersConversionFactor = 1_000_000m;

        public decimal Length { get; init; }
        public decimal Width { get; init; }
        public decimal Height { get; init; }
        public decimal Weight { get; init; }

        public DimensionsValueObject(decimal length, decimal width, decimal height, decimal weight)
        {
            Guard.AgainstMinValue(length, 0.01m, nameof(length));
            Guard.AgainstMinValue(width, 0.01m, nameof(width));
            Guard.AgainstMinValue(height, 0.01m, nameof(height));
            Guard.AgainstMinValue(weight, 0.01m, nameof(weight));

            Length = length;
            Width = width;
            Height = height;
            Weight = weight;
        }

        public override string ToString() => $"{Length:F2} L x {Width:F2} C x {Height:F2} A cm - {Weight:F2} kg";
        public decimal VolumeInCubicMeters => (Length * Width * Height) / _cubicMetersConversionFactor;
    }
}
