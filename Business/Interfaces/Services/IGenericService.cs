namespace ItlaTv.Core.Application.Interfaces.Services
{
    public interface IGenericService<CreateViewModel, ViewModel>
        where CreateViewModel: class
        where ViewModel: class
    {
        Task AddAsync(CreateViewModel createViewModel);
        Task UpdateAsync(CreateViewModel createViewModel);
        Task<CreateViewModel> GetByIdAsync(int id);
        Task<List<ViewModel>> GetAllAsync();
    }
}
