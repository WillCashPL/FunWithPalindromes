using FunWithPalindromes;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using PalindromesLib.Core;
using PalindromesLib.Interfaces;
using ILogger = Microsoft.Extensions.Logging.ILogger;

var builder = Host.CreateDefaultBuilder()
    .ConfigureServices((hostContext, services) =>
    {
        services.AddLogging(
            loggingBuilder =>
                loggingBuilder.ClearProviders()
                    .AddConsole()
        );
        // services.AddScoped
        services.AddTransient<ILogger,Logger<string>>();
        services.AddTransient<IPalindromesChecker, PalindromesChecker>();
        services.AddTransient<ITextDisassembler, TextDisassembler>();
        services.AddTransient<INestedItemsRemover, NestedItemsRemover>();
        services.AddTransient<PalindromeCheckCoordinator>();
        services.AddTransient<BobTheWorker>();
    });


builder.Build().Services.GetRequiredService<BobTheWorker>().RunProgram();