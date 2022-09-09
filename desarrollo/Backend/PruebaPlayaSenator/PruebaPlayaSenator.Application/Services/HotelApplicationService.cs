using ExampleAPIWithEF.Application.Shared;
using ExampleAPIWithEF.Context;
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

        public Resultado<HotelDto> GetHotelById(int idUsuario)
        {
            //Resultado<UserDto> res = new Resultado<UserDto>();

            //try
            //{



            //    if (idUsuario < 1)
            //    {
            //        res.Mensaje = "Debe especificar un valor válido de identificador de usuario";
            //        res.ResultadoOperacion = true;

            //        return res;
            //    }

            //    User user = newContext.User.Where(u => u.IdUsuario == 1).FirstOrDefault();

            //    if (user == null)
            //    {
            //        res.Mensaje = "No existe el usuario en el sistema.";
            //        res.ResultadoOperacion = true;

            //        return res;
            //    }

            //    // Mapear las propiedades
            //    UserDto userDto = Factoria.Map<User, UserDto>(user);

            //    res.Respuesta = userDto;
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

        public Resultado<List<HotelDto>> GetListaHoteles()
        {
            Resultado<List<HotelDto>> res = new Resultado<List<HotelDto>>();

            try
            {



                //if (idUsuario < 1)
                //{
                //    res.Mensaje = "Debe especificar un valor válido de identificador de usuario";
                //    res.ResultadoOperacion = true;

                //    return res;
                //}

                List<Hotel> hoteles = newContext.Hotel.ToList();

                //if (user == null)
                //{
                //    res.Mensaje = "No existe el usuario en el sistema.";
                //    res.ResultadoOperacion = true;

                //    return res;
                //}

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
