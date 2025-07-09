using ItlaTv.Core.Application.ViewModels.Genres;
using ItlaTv.Core.Application.ViewModels.Producers;
using System.ComponentModel.DataAnnotations;

namespace ItlaTv.Core.Application.ViewModels.Series
{
    public class CreateSerieViewModel
    {
        public virtual int Id { get; set; }

        [Required(ErrorMessage = "*")]
        public string Name { get; set; }

        [Required(ErrorMessage = "*")]
        public string ImageUrl { get; set; }

        [Required(ErrorMessage = "*")]
        public string VideoUrl { get; set; }

        [Required(ErrorMessage = "*")]
        public int ProducerId { get; set; }

        [Required(ErrorMessage = "*")]
        public int PrimaryGenreId { get; set; }

        public int? SecundaryGenreId { get; set; }

        public List<ProducerViewModel>? Producers { get; set; }
        public List<GenreViewModel>? Genres { get; set; }
    }
}
