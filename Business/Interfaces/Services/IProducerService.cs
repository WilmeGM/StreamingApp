using ItlaTv.Core.Application.ViewModels.Producers;

namespace ItlaTv.Core.Application.Interfaces.Services
{
    public interface IProducerService : IGenericService<CreateProducerViewModel, ProducerViewModel>, IRemoveService
    {
    }
}