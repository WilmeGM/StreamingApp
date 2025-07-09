using ItlaTv.Core.Domain.Common;

namespace ItlaTv.Core.Domain.Entities
{
    public class Genre : AuditableBaseEntity
    {
        public string Name { get; set; }
        public ICollection<Serie> PrimarySeries { get; set; }
        public ICollection<Serie> SecundarySeries { get; set; }
    }
}
