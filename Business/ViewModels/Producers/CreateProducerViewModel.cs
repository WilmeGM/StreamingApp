using System.ComponentModel.DataAnnotations;

namespace ItlaTv.Core.Application.ViewModels.Producers
{
    public class CreateProducerViewModel
    {
        public virtual int Id { get; set; }

        [Required(ErrorMessage = "*")]
        public string Name { get; set; }
    }
}
