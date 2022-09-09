using ExampleAPIWithEF.Application.Shared;
using ExampleAPIWithEF.Context;
using Microsoft.EntityFrameworkCore;
using PruebaPlayaSenator.Application.Dto;
using PruebaPlayaSenator.Application.Entities;
using PruebPlayaSenator.Aplicacion;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExampleAPIWithEF.Application.Services
{
    public class HotelApplicationService : IHotelApplicationService
    {
        PruebaPlayaSenatorContext newContext = new PruebaPlayaSenatorContext();

        public async Task<Resultado<HotelDto>> CrearHotelAsync(HotelDto uDto)
        {
            //Resultado<UserDto> res = new Resultado<UserDto>();

            //try
            //{

            //    User unew = new User();

            //    // Mapear las propiedades
            //    unew = Factoria.Map<UserDto, User>(uDto);
            //    unew.IdUsuario = null;

            //    newContext.Add(unew);

            //    await newContext.SaveChangesAsync();

            //    if (unew != null && unew.IdUsuario != null)
            //    {
            //        // Ejemplo llamada webservice para recuperar por id generado
            //        var externalProduct = await ExternalProductAPI.getExternalEmployeeAsync();

            //        //Se asignan propiedades de servicio externo
            //    }
            //    res.Mensaje = "Usuario guardado correctamente";
            //    res.ResultadoOperacion = true;

            //    return res;
            //}
            //catch (Exception ex)
            //{
            //    res.Mensaje = "Se ha producido un error en la aplicación";
            //    res.ResultadoOperacion = true;

            //    return res;

            //}

            return null;
        }

        public Resultado<HotelDto> GetHotelById(int idHotel)
        {
            Resultado<HotelDto> res = new Resultado<HotelDto>();

            try
            {

                if (idHotel < 1)
                {
                    res.Mensaje = "Debe especificar un valor válido de identificador de hotel";
                    res.ResultadoOperacion = true;

                    return res;
                }

                Hotel hotel = newContext.Hotel
                                .Include(h => h.Relevance)
                                .Include(h => h.Category)
                                .Include(h => h.City)
                                .Include(h => h.HotelXCharacteristic)
                                .ThenInclude(hc => hc.Characteristic)
                                .Where(h => h.Id == idHotel)
                                .FirstOrDefault();

                if (hotel == null)
                {
                    res.Mensaje = "No existe el hotel con el identificador seleccionado.";
                    res.ResultadoOperacion = true;

                    return res;
                }

                // Mapear las propiedades
                HotelDto hotelDto = Factoria.Map<Hotel, HotelDto>(hotel);

                //hotel.HotelXCharacteristic.ToList().ForEach(x =>
                //{
                //    hotelDto.listaCaracteristicas.Add();
                //});

                res.Respuesta = hotelDto;
                res.Mensaje = "Hotel recuperado correctamente";
                res.ResultadoOperacion = true;

                return res;
            }
            catch (Exception ex)
            {
                res.Mensaje = "Se ha producido un error en la aplicación";
                res.ResultadoOperacion = true;

                return res;

            }

        }

        public Resultado<List<HotelDto>> GetListaHoteles()
        {
            Resultado<List<HotelDto>> res = new Resultado<List<HotelDto>>();

            try
            {

                List<Hotel> hoteles = newContext.
                                        Hotel
                                        .Include(h => h.Relevance)
                                        .Include(h => h.Category)
                                        .Include(h => h.City)
                                        .Include(h => h.HotelXCharacteristic)
                                        .ThenInclude(hc => hc.Characteristic)
                                        .ToList();

                // Mapear las propiedades
                List<HotelDto> hotelesDto = Factoria.MapList<Hotel, HotelDto>(hoteles).ToList();

                res.Respuesta = hotelesDto;
                res.Mensaje = "Usuario guardado correctamente";
                res.ResultadoOperacion = true;

                return res;
            }
            catch (Exception ex)
            {
                res.Mensaje = "Se ha producido un error en la aplicación";
                res.ResultadoOperacion = true;

                return res;

            }

        }

        public void Dispose()
        {

        }
    }
}
