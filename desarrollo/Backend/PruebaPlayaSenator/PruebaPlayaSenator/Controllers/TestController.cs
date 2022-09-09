using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using ExampleAPIWithEF.Application.Shared;
using ExampleAPIWithEF.Application.Services;
using PruebPlayaSenator.Aplicacion;
using PruebaPlayaSenator.Application.Dto;
using System.Collections.Generic;

namespace ExampleAPIWithEF.Controllers
{
    [ApiController]
    [Route("api")]
    public class TestController : ControllerBase
    {


        [Route("~/api/GetHotel/{id}")]
        [HttpGet]
        public Resultado<HotelDto> GetNumeroAsync(int id)
        {

            Resultado<HotelDto> res = null;

            using (IHotelApplicationService userApplicationService = Factoria.GetInstance<IHotelApplicationService>())
            {
                res = userApplicationService.GetHotelById(id);
            }

            return res;


        }

        [Route("~/api/GetHoteles")]
        [HttpGet]
        public Resultado<List<HotelDto>> GetHoteles(int id)
        {

            Resultado<List<HotelDto>> res = null;

            using (IHotelApplicationService userApplicationService = Factoria.GetInstance<IHotelApplicationService>())
            {
                res = userApplicationService.GetListaHoteles();
            }

            return res;


        }

        [Route("~/api/PostNuevoUsuario")]
        [HttpPost]
        public async Task<Resultado<HotelDto>> PostNuevoUsuarioAsync(HotelDto uDto)
        {

            Resultado<HotelDto> res = null;

            using (IHotelApplicationService userApplicationService = Factoria.GetInstance<IHotelApplicationService>())
            {
                res = await userApplicationService.CrearHotelAsync(uDto);
            }

            return res;

        }
    }
}
