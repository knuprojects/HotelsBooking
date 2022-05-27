using Catalog.Domain.ValueObjects;

namespace Catalog.Domain.Entities
{
    public class Hotel : BaseEntity
    {
        public Name Name { get; set; }
        public Description Description { get; set; }
        public City City { get; set; }
        public PhotoUrl PhotoUrl { get; set; }
    }
}
