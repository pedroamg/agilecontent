using CandidateTesting.PedroIvoFagundesSantos.AgileContent.ConsoleApp.Domain.Interfaces.Services;
using CandidateTesting.PedroIvoFagundesSantos.AgileContent.ConsoleApp.Infra.Ioc;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace CandidateTesting.PedroIvoFagundesSantos.AgileContent.ConsoleApp
{
    internal class Program
    {
        private static IServiceProvider _serviceProvider;
        private static IAdjacentService _adjacentService;
        private static ILogService _logService;
        private static async Task Main()
        {
            RegisterServices();
            await ConvertLog();
            CalcAdjcent();
            DisposeServices();
        }

        private static async Task ConvertLog()
        {
            var input = Console.ReadLine();
            await _logService.GenerateAgoraLogAsync(input, CancellationToken.None);
        }

        private static void CalcAdjcent()
        {
            var adjacentValues = new[] { 0, 3, 3, 12, 5, 3, 7, 1 };
            var adjacentValue = _adjacentService?.CalcAdjacentValue(adjacentValues);
            Console.Write($"The adjacent value founded was: {adjacentValue}");
        }

        private static void RegisterServices()
        {
            var services = new ServiceCollection();
            NativeBoostraper.Register(services);
            _serviceProvider = services.BuildServiceProvider();
            _adjacentService = _serviceProvider.GetService<IAdjacentService>();
            _logService = _serviceProvider.GetService<ILogService>();
        }

        private static void DisposeServices()
        {
            switch (_serviceProvider)
            {
                case null:
                    return;
                case IDisposable disposable:
                    disposable.Dispose();
                    break;
            }
        }
    }
}