using FourSix.Domain.Entities.PedidoAggregate;

namespace FourSix.Application.UseCases.Pedidos.NovoPedido
{
    public interface INovoPedidoUseCase
    {
        /// <summary>
        /// Executa o Caso de Uso
        /// </summary>
        Task Execute(DateTime dataPedido, Guid? clienteId, ICollection<Tuple<Guid, decimal, int, string>> itens);

        /// <summary>
        /// Define a porta de saída
        /// </summary>
        /// <param name="outputPort">Porta de Saída</param>
        void SetOutputPort(IOutputPort<Pedido> outputPort);
    }
}
