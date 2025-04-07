using PlatosApp.Models;
using System.Diagnostics;

namespace PlatosApp.Helpers
{
    public class RestClientDecorator : IRestClient
    {
        private readonly IRestClient _restClient;

        public RestClientDecorator(IRestClient restClient)
        {
            _restClient = restClient;
        }

        public async Task AddPlatoAsync(AddOrModifyPlato plato)
        {
            if (!IsAppConnected())
            {
                return;
            }

            try
            {
                await _restClient.AddPlatoAsync(plato);
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"[RED]: {AddPlatoAsync} {ex.Message}");
            }
        }

        public async Task DeletePlatoAsync(int id)
        {
            if (!IsAppConnected())
            {
                return;
            }

            try
            {
                await _restClient.DeletePlatoAsync(id);
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"[RED]: {AddPlatoAsync} {ex.Message}");
            }
        }

        public async Task<ICollection<Plato>> GetPlatos()
        {
            if (!IsAppConnected())
            {
                return new List<Plato>();
            }

            try
            {
                return await _restClient.GetPlatos();
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"[RED]: {AddPlatoAsync} {ex.Message}");
            }

            return new List<Plato>();
        }

        public async Task UpdatePlatoAsync(Plato plato)
        {
            if (!IsAppConnected())
            {
                return;
            }

            try
            {
                await _restClient.UpdatePlatoAsync(plato);
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"[RED]: {AddPlatoAsync} {ex.Message}");
            }

        }

        private bool IsAppConnected()
        {
            if (Connectivity.Current.NetworkAccess != NetworkAccess.Internet)
            {
                Debug.WriteLine("No hay conexión a internet");

                return false;
            }

            return true;
        }
    }
}
