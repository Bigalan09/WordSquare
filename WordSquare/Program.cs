using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using WordSquare.Game;

using IHost host = Host.CreateDefaultBuilder(args)
    .ConfigureServices(services =>
    {
        services.RegisterWordSquare();
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

    var game = gameFactory.GetGame(Mode.HumanVsHuman);
    game.Begin();
}
