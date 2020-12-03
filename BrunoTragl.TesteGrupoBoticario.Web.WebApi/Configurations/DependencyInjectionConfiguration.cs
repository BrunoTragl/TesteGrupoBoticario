﻿using AutoMapper;
using BrunoTragl.TesteGrupoBoticario.Domain.Services;
using BrunoTragl.TesteGrupoBoticario.Domain.Services.Interfaces;
using BrunoTragl.TesteGrupoBoticario.Infra.Data;
using BrunoTragl.TesteGrupoBoticario.Infra.Data.Interfaces;
using BrunoTragl.TesteGrupoBoticario.Infra.Repository;
using BrunoTragl.TesteGrupoBoticario.Infra.Repository.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace BrunoTragl.TesteGrupoBoticario.Web.WebApi.Configurations
{
    public static class DependencyInjectionConfiguration
    {
        public static void Resolve(this IServiceCollection services)
        {
            services.AddTransient<IProductRepository, ProductRepository>();
            services.AddTransient<IProductService, ProductService>();
            services.AddSingleton<IContext, Context>();
            services.AddAutoMapper(typeof(Startup));
        }
    }
}