using CandidateTesting.PedroIvoFagundesSantos.AgileContent.ConsoleApp.Domain.Constants;
using CandidateTesting.PedroIvoFagundesSantos.AgileContent.ConsoleApp.Domain.Entities;
using CandidateTesting.PedroIvoFagundesSantos.AgileContent.ConsoleApp.Domain.Interfaces.Repositories;
using CandidateTesting.PedroIvoFagundesSantos.AgileContent.ConsoleApp.Domain.Interfaces.Services;
using CandidateTesting.PedroIvoFagundesSantos.AgileContent.ConsoleApp.Domain.Services;
using CandidateTesting.PedroIvoFagundesSantos.AgileContent.ConsoleApp.Infra.Data.Proxy;
using CandidateTesting.PedroIvoFagundesSantos.AgileContent.ConsoleApp.Infra.Data.Proxy.Interfaces;
using CandidateTesting.PedroIvoFagundesSantos.AgileContent.ConsoleApp.Infra.Data.Repository;
using Microsoft.Extensions.DependencyInjection;
using System.Collections.Generic;
using System.Text;

namespace CandidateTesting.PedroIvoFagundesSantos.AgileContent.ConsoleApp.Infra.Ioc
{
    public static class NativeBoostraper
    {
        public static void Register(IServiceCollection services)
        {
            AddServices(services);
            AddRepositories(services);
            AddEntities(services);
            AddProxies(services);
        }

        private static void AddServices(IServiceCollection services)
        {
            services.AddScoped<IAdjacentService, AdjacentService>();
            services.AddScoped<ILogService, LogService>();
        }

        private static void AddRepositories(IServiceCollection services)
        {
            services.AddScoped<IAdjacentRepository, AdjacentRepository>();
            services.AddScoped<ILogRepository, LogRepository>();
        }

        private static void AddEntities(IServiceCollection services)
        {
            services.AddScoped<Distance>();
            var positions = new Dictionary<string, int>
            {
                {LogConstants.HttpMethod, 3},
                {LogConstants.StatusCode, 1},
                {LogConstants.UriPath, 4},
                {LogConstants.TimeTaken, 6},
                {LogConstants.ResponseSize, 0},
                {LogConstants.CacheStatus, 2}
            };
            services.AddSingleton(x => new Log(new []{'\r', '\n'}, new StringBuilder(), positions));
        }

        private static void AddProxies(IServiceCollection services)
        {
            services.AddHttpClient<IGetFileProxy, GetFileProxy>();
        }
    }
}
