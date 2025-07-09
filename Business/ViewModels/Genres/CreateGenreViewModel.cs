using System.ComponentModel.DataAnnotations;

namespace ItlaTv.Core.Application.ViewModels.Genres
{
    public class CreateGenreViewModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "*")]
        public string Name { get; set; }
    }
}
