
namespace Ecommerce.Infrastructure.Persistence.Seeders.SeederInterface
{
    internal interface ISeeder<T> where T : class
    {
        IEnumerable<T> GetSeedData();
    }
}
