namespace ItlaTv.Core.Application.ViewModels.Series
{
    public class SerieViewModel
    {
        public virtual int Id { get; set; }
        public string Name { get; set; }
        public string ImageUrl { get; set; }
        public string VideoUrl { get; set; }
        public int ProducerId { get; set; }
        public string Producer { get; set; }
        public int PrimaryGenreId { get; set; }
        public string PrimaryGenre { get; set; }
        public int? SecundaryGenreId { get; set; }
        public string? SecundaryGenre { get; set; }
    }
}
