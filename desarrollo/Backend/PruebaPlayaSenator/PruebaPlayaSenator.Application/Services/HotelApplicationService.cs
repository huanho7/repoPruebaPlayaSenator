using ExampleAPIWithEF.Application.Shared;
using ExampleAPIWithEF.Context;
using Microsoft.EntityFrameworkCore;
using PruebaPlayaSenator.Application.Dto;
using PruebaPlayaSenator.Application.Entities;
using PruebaPlayaSenator.Application.Shared;
using PruebaPlayaSenator.Application.ViewModel;
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
                Console.WriteLine(ex.ToString());

                return res;

            }
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
                Console.WriteLine(ex.ToString());

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
                Console.WriteLine(ex.ToString());

                return res;

            }

        }

        public async Task<Resultado<List<HotelDto>>> GetListaHotelesPaginadoAsync(HotelFilterQueryParametersViewModel hotelFilterQueryParametersViewModel)
        {
            Resultado<List<HotelDto>> res = new Resultado<List<HotelDto>>();

            try 
            {

                IQueryable<Hotel> newQuery = newContext.
                                                Hotel
                                                .Include(h => h.Relevance)
                                                .Include(h => h.Category)
                                                .Include(h => h.City)
                                                .Include(h => h.HotelXCharacteristic)
                                                .ThenInclude(hc => hc.Characteristic);

                if(hotelFilterQueryParametersViewModel != null)
                {
                    if(hotelFilterQueryParametersViewModel.FilterName != null)
                    {
                        newQuery = newQuery.Where(x => x.Name.ToUpper().Contains(hotelFilterQueryParametersViewModel.FilterName.ToUpper()));
                    }
                    if(hotelFilterQueryParametersViewModel.FilterTop != null)
                    {
                        if(hotelFilterQueryParametersViewModel.FilterTop == true)
                        {
                            newQuery = newQuery.Where(x => x.Relevance.Id == 1);
                        }
                    }
                }

                PagedList<Hotel> listaHotelesPaginados = await PagedList<Hotel>.ToPagedList(newQuery, hotelFilterQueryParametersViewModel.PagOptions.CurrentPage, hotelFilterQueryParametersViewModel.PagOptions.PageSize);

                // Mapear las propiedades
                List<HotelDto> hotelesDto = Factoria.MapList<Hotel, HotelDto>(listaHotelesPaginados).ToList();
                res.ResultadoPaginacion = new PaginationOptions() 
                                               {    TotalItemsCount = listaHotelesPaginados.TotalCount,
                                                    CurrentItemsCount = listaHotelesPaginados.Count,
                                                    HasPreviousPage = listaHotelesPaginados.HasPrevious,
                                                    HasNextPage = listaHotelesPaginados.HasNext,
                                                    CurrentPage = listaHotelesPaginados.CurrentPage,
                                                    PageSize = hotelFilterQueryParametersViewModel.PagOptions.PageSize};

                res.Respuesta = hotelesDto;
                res.Mensaje = "Listado recuperado correctamente";
                res.ResultadoOperacion = true;

                return res;

            }
            catch (Exception ex)
            {
                res.Mensaje = "Se ha producido un error en la aplicación";
                res.ResultadoOperacion = true;
                Console.WriteLine(ex.ToString());

                return res;
            }
        }
        public void Dispose()
        {

        }
    }
}
