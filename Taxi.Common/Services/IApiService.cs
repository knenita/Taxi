using Taxi.Common.Models;
using System.Threading.Tasks;

namespace Taxi.Common.Services
{
    public interface IApiService
    {
        Task<Response> GetTaxiAsync(
            string plaque, //placa
            string urlBase, //donde se consume dir azure
            string servicePrefix, //api
            string controller); //nombre controlador
    }
}