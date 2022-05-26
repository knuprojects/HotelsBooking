using Catalog.Domain.ValueObjects;

namespace Catalog.Domain.Entities
{
    public class Hotel : BaseEntity
    {
        public Name Name { get; private set; }
        public Description Description { get; private set; }
        public City City { get; private set; }
        public PhotoUrl PhotoUrl { get; private set; }
    }
}
