using Aplication.AppServices;
using Aplication.AppServices.Implementations;
using AutoMapper;
using Domain.Model.Interfaces.Repositories;
using Domain.Model.Interfaces.Services;
using Domain.Service.Services;
using Infraestructure.Cross_cutting.IoC.MappingProfiles;
using Infraestructure.Data.Context;

using Infraestructure.Data.Repositories;
using InfraestructureAzure.Services.Blob;
//using InfraestructureAzure.Services.Blob;
using InfraestructureAzure.Services.Queue;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infraestructure.Cross_cutting.IoC
{
   public  class Bootstrapper
    {
        

        public static void RegisterServices(IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<IJogadorAppService, JogadorApp>();
            services.AddScoped<IJogoAppService, JogoApp>();

            services.AddScoped<IJogadorService, JogadorService>();
            services.AddScoped<IJogoService, JogoService>();

            services.AddScoped<IJogadorRepository, JogadorRepository>();
            services.AddScoped<IJogoRepository, JogoRepository>();

            services.AddDbContext<JogoContext>(options =>
                    options.UseSqlServer(configuration.GetConnectionString("JogoContext")));

            services.AddAutoMapper(x => x.AddProfile(typeof(MappingProfile)));

            services.AddScoped<IBlobService, BlobService>(provider => 
            new BlobService(configuration.GetValue<string>("StorageAccount")));

         //   services.AddScoped<IQueueService, Queue>(provider => new Queue(configuration.GetValue<string>("StorageAccount")));

        }
    }
}
