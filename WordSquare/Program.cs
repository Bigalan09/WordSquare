using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using WordSquare.Game;


IConfiguration config = new ConfigurationBuilder()
    .AddJsonFile("appsettings.json")
    .Build();

using IHost host = Host.CreateDefaultBuilder(args)
    .ConfigureServices((context, services) =>
    {
        services.RegisterWordSquare(context.Configuration);
    })
    .Build();

HostGame(host.Services);

await host.RunAsync();

static void HostGame(IServiceProvider hostProvider)
{
    using IServiceScope serviceScope = hostProvider.CreateScope();
    IServiceProvider provider = serviceScope.ServiceProvider;
    Console.WriteLine("WordSquare");
    Console.WriteLine("----------");

    var gameFactory =
        provider.GetRequiredService<IGameFactory>();

    var game = gameFactory.GetGame(Mode.ComputerVsComputer);
    game.Begin();
}
