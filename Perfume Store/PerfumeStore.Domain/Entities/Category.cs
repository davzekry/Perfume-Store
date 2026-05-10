using PerfumeStore.Domain.Common;

namespace PerfumeStore.Domain.Entities
{
    public sealed class Category : BaseEntity
    {
        public string Name { get; set; } = string.Empty;
        public ICollection<Product> Products { get; set; } = [];
    }
}
