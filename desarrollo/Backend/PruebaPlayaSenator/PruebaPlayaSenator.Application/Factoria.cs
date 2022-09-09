using System;
using System.Collections.Generic;
using AutoMapper;
using ExampleAPIWithEF.Application;
using ExampleAPIWithEF.Application.Services;
using ExampleAPIWithEF.Context;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using PagedList;

namespace PruebPlayaSenator.Aplicacion
{
    public class Factoria
    {
        protected static ServiceProvider servicesProvider = null;

        /// <summary>
        /// Inicializa los proveedores de instancias por defecto
        /// </summary>
        /// <remarks></remarks>
        public static void InitializeProviders(IServiceCollection services)
        {

            services.AddTransient<IHotelApplicationService, HotelApplicationService>();

            //Contexts
            services.AddTransient<PruebaPlayaSenatorContext>();

            servicesProvider = services.BuildServiceProvider();

            services.AddSingleton<ILoggerFactory, LoggerFactory>();

            services.AddSingleton(typeof(ILogger<>), typeof(Logger<>));

            Mapper.Initialize(x => x.AddProfile<AutoMapperProfile>());
        }

        public static TBase GetInstance<TBase>()
        {
            return servicesProvider.GetRequiredService<TBase>();
        }


        public static T Get<T>(string key) where T : new()
        {
            T instance = new T();
            GetInstance<Microsoft.Extensions.Configuration.IConfiguration>().GetSection(key).Bind(instance);
            return instance;
        }

        public static TDestination Map<TSource, TDestination>(TSource source, TDestination destination)
        {
            TDestination salida = AutoMapper.Mapper.Map<TSource, TDestination>(source, destination);
            return salida;
        }

        public static TDestination Map<TSource, TDestination>(TSource source, TDestination destination, Action<IMappingOperationOptions<TSource, TDestination>> opts)
        {
            TDestination salida = AutoMapper.Mapper.Map<TSource, TDestination>(source, destination, opts);
            return salida;
        }

        public static TDestination Map<TSource, TDestination>(TSource source)
        {
            TDestination salida = AutoMapper.Mapper.Map<TSource, TDestination>(source);
            return salida;
        }

        public static IEnumerable<TDestination> MapList<TSource, TDestination>(IEnumerable<TSource> source)
        {
            IEnumerable<TDestination> salida = AutoMapper.Mapper.Map<IEnumerable<TSource>, IEnumerable<TDestination>>(source);
            if (source is IPagedList)
            {
                IPagedList<TSource> sourcePaged = (IPagedList<TSource>)source;
                salida = new StaticPagedList<TDestination>(salida, sourcePaged.PageNumber, sourcePaged.PageSize, sourcePaged.TotalItemCount);
            }
            return salida;
        }
    }
}