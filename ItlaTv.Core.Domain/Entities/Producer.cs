using ItlaTv.Core.Domain.Common;

namespace ItlaTv.Core.Domain.Entities
{
    public class Producer : AuditableBaseEntity
    {
        public string Name { get; set; }
        public ICollection<Serie> Series { get; set; }
    }
}
