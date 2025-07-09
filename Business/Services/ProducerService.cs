using ItlaTv.Core.Application.ViewModels.Producers;
using ItlaTv.Core.Domain.Entities;
using ItlaTv.Core.Application.Interfaces.Repositories;
using ItlaTv.Core.Application.Interfaces.Services;

namespace ItlaTv.Core.Application.Services
{
    public class ProducerService : IProducerService
    {
        private readonly IProducerRepository _producerRepository;

        public ProducerService(IProducerRepository producerRepository)
        {
            _producerRepository = producerRepository;
        }

        public async Task AddAsync(CreateProducerViewModel createViewModel)
        {
            var producer = new Producer
            {
                Id = createViewModel.Id,
                Name = createViewModel.Name,
            };

            await _producerRepository.AddAsync(producer);
        }

        public async Task UpdateAsync(CreateProducerViewModel updateViewModel)
        {
            var producer = new Producer
            {
                Id = updateViewModel.Id,
                Name = updateViewModel.Name
            };

            await _producerRepository.UpdateAsync(producer);
        }

        public async Task RemoveAsync(int id)
        {
            var producerToRemove = await _producerRepository.GetByIdAsync(id);
            await _producerRepository.RemoveAsync(producerToRemove);
        }

        public async Task<CreateProducerViewModel> GetByIdAsync(int id)
        {
            var producer = await _producerRepository.GetByIdWithIncludesAsync(id);

            var createViewModel = new CreateProducerViewModel
            {
                Id = producer.Id,
                Name = producer.Name
            };

            return createViewModel;
        }

        public async Task<List<ProducerViewModel>> GetAllAsync()
        {
            var producerList = await _producerRepository.GetAllAsync();

            return producerList.Select(producer => new ProducerViewModel
            {
                Id = producer.Id,
                Name = producer.Name
            }).ToList();
        }
    }
}
