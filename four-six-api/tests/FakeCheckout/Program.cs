using FourSix.Application.UseCases.Pedidos.ObtemPedidosPorStatus;
using FourSix.Domain.Entities.PedidoAggregate;
using FourSix.Infrastructure.DataAccess;
using FourSix.Infrastructure.DataAccess.Repositories;

IObtemPedidosPorStatusUseCase useCase = new ObtemPedidosPorStatusUseCase(new PedidoRepository(new Context()));

do
{
    while (!Console.KeyAvailable)
    {
        Console.Clear();
        Console.WriteLine("Aguardando novos pedidos. Pressione ESC para parar");

        var lista = useCase.Execute(EnumStatusPedido.Pago).Result;

        if (lista.Any())
        {
            foreach (var pedido in lista)
            {
                Console.WriteLine($"Pedido {pedido.NumeroPedido} sendo preparado");
            }
        }

        await Task.Delay(2000);
    }

} while (Console.ReadKey(true).Key != ConsoleKey.Escape);