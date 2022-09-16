using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using ExampleAPIWithEF.Application.Shared;
using ExampleAPIWithEF.Application.Services;
using PruebPlayaSenator.Aplicacion;
using PruebaPlayaSenator.Application.Dto;
using System.Collections.Generic;
using PruebaPlayaSenator.Application.ViewModel;
using PruebaPlayaSenator.Application.Shared;

namespace ExampleAPIWithEF.Controllers
{
    [ApiController]
    [Route("api")]
    public class HotelController : ControllerBase
    {


        [Route("~/api/GetHotelById/{id}")]
        [HttpGet]
        public Resultado<HotelDto> GetHotelById(int id)
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

        [Route("~/api/ChangeRelevancePost")]
        [HttpPost]
        public Resultado<bool> ChangeRelevancePost([FromBody] ChangeRelevanceIdRequestViewModel changeRelevanceIdRequestViewModel)
        {

            Resultado<bool> res = null;

            using (IHotelApplicationService userApplicationService = Factoria.GetInstance<IHotelApplicationService>())
            {
                res = userApplicationService.UpdateHotel(changeRelevanceIdRequestViewModel.IdHotel, changeRelevanceIdRequestViewModel.IdNewRelevanceStatus);
            }

            return res;

        }

        [Route("~/api/GetHotelesPaginado")]
        [HttpPost]
        public async Task<Resultado<List<HotelDto>>> GetHotelesPaginadoAsync([FromBody] PaginationOptions pagOpt)
        {

            Resultado<List<HotelDto>> res = null;

            using (IHotelApplicationService userApplicationService = Factoria.GetInstance<IHotelApplicationService>())
            {
                res = await userApplicationService.GetListaHotelesPaginadoAsync(pagOpt);
            }

            return res;

        }
    }
}
