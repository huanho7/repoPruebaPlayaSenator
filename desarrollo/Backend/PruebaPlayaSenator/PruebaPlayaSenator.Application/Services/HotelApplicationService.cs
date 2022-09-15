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

        public Resultado<bool> UpdateHotel(int idHotel, int idNewRelevance)
        {
            Resultado<bool> res = new Resultado<bool>();

            try
            {

                if (idHotel < 1)
                {
                    res.Mensaje = "Debe especificar un valor válido de identificador de hotel";
                    res.ResultadoOperacion = false;

                    return res;
                }

                if (idNewRelevance < 1)
                {
                    res.Mensaje = "Debe especificar un valor válido para el nuevo estado del hotel";
                    res.ResultadoOperacion = false;

                    return res;
                }

                Relevance relv = newContext.Relevance
                                    .Where(r => r.Id == idNewRelevance)
                                    .FirstOrDefault();

                if (relv == null)
                {
                    res.Mensaje = "Debe especificar un valor válido para el nuevo estado del hotel";
                    res.ResultadoOperacion = false;

                    return res;
                }

                Hotel hotel = newContext.Hotel
                                .Where(h => h.Id == idHotel)
                                .FirstOrDefault();

                if (hotel == null)
                {
                    res.Mensaje = "No existe el hotel con el identificador seleccionado.";
                    res.ResultadoOperacion = true;

                    return res;
                }

                if (hotel.IdRelevance == idNewRelevance)
                {
                    res.Mensaje = "El hotel ya se encuentra con el estado de relevancia seleccionado.";
                    res.ResultadoOperacion = true;

                    return res;
                }

                hotel.IdRelevance = idNewRelevance;

                newContext.Update(hotel);

                newContext.SaveChangesAsync();

                res.Mensaje = "Nuevo estado de hotel guardado correctamente.";
                res.ResultadoOperacion = true;

                return res;
            }
            catch (Exception ex)
            {
                res.Mensaje = "Se ha producido un error en la aplicación";
                res.ResultadoOperacion = true;

                return res;

            }

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
                    res.ResultadoOperacion = false;

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

                hotelDto.listaCaracteristicas = new List<CharacteristicDto>();

                hotel.HotelXCharacteristic.ToList().ForEach(x =>
                {
                    hotelDto.listaCaracteristicas.Add(Factoria.Map<Characteristic, CharacteristicDto>(x.Characteristic));
                });

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
