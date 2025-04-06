using PlatosApp.Models;

namespace PlatosApp.Helpers
{
    public interface IRestClient
    {
        Task<ICollection<Plato>> GetPlatos();
        Task AddPlatoAsync(AddOrModifyPlato plato);
        Task UpdatePlatoAsync(Plato plato);
        Task DeletePlatoAsync(int id);
    }
}
