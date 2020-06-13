using Domain.Core.Bus;
using Domain.Core.Entities;
using Domain.MongoDB.Interfaces;
using Domain.MongoDB.Repository;
using Infra.Bus;
using MediatR;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using SharePic.Application.Interfaces;
using SharePic.Application.Services;
using SharePic.Data.Repository;
using SharePic.Domain.CommandHandlers;
using SharePic.Domain.Commands;
using SharePic.Domain.EventHandlers;
using SharePic.Domain.Events;
using SharePic.Domain.Interfaces;

namespace Infra.IoC
{
    public class DependencyContainer
    {
        public static void RegisterServices(IServiceCollection services)
        {



            //Domain Bus
            //var config = IConfiguration.GetSection("AppSettings").Get<AppSettings>();
            //services.AddTransient<AppSettings, config>();

            //Domain SharePic Commands
            services.AddSingleton<IRequestHandler<CreateSharePicCommand, bool>, SharePicCommandHandler>();

            ///Domain Bus
            services.AddTransient<IEventBus, RabbitMQBus>(sp =>
            {
                var scopeFactory = sp.GetRequiredService<IServiceScopeFactory>();
                return new RabbitMQBus(sp.GetService<IMediator>(), scopeFactory, sp.GetService<IOptions<RabbitMQSettings>>());
            });

            //Subscriptions
            services.AddTransient<SharePicEventHandler>();

            //Domains Events
            services.AddTransient<IEventHandler<SharePicCreatedEvent>, SharePicEventHandler>();

            //Application Services 
            services.AddTransient<ISharePicService, SharePicService>();

            //Transfer Services
            services.AddTransient<ISharePicService, SharePicService>();

            //Data
            services.AddTransient<ISharePicRepository, PicRepository>();

            //MongoRepository
            services.AddTransient(typeof(IMongoRepository<>), typeof(MongoRepository<>));



        }
    }
}
