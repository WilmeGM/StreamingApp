using ItlaTv.Core.Domain.Common;

namespace ItlaTv.Core.Domain.Entities
{
    public class Serie : AuditableBaseEntity
    {
        public string Name { get; set; }
        public string ImageUrl { get; set; }
        public string VideoUrl { get; set; }

        public int ProducerId { get; set; } //Producer's Foreign Key
        public Producer Producer { get; set; } //Producer's Navigation Property

        public int PrimaryGenreId { get; set; } //PrimaryGenre's Foreign Key
        public Genre PrimaryGenre { get; set; } //PrimaryGenre's Navigation Property

        public int? SecundaryGenreId { get; set; } //SecundaryGenre's Foreign Key
        public Genre? SecundaryGenre { get; set; } //SecundaryGenre's Navigation Property
    }
}
