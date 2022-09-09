using ExampleAPIWithEF.Application.Shared;
using PruebaPlayaSenator.Application.Dto;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ExampleAPIWithEF.Application.Services
{
    public interface IHotelApplicationService : IApplicationService
    {
        Resultado<bool> UpdateHotel(int idHotel, int idNewRelevance);
        Resultado<HotelDto> GetHotelById(int idHotel);
        Resultado<List<HotelDto>> GetListaHoteles();
    }
}
