using FourSix.Domain.Entities.PagamentoAggregate;

namespace FourSix.Controllers.ViewModels
{
    public class PedidoModel
    {
        public PedidoModel(Guid idPedido, int codigoPagamentoPedido, DateTime dataAtualizacao)
        {
            IdPedido = idPedido;
            CodigoPagamentoPedido = codigoPagamentoPedido;
            DataAtualizacao = dataAtualizacao;
        }

        public Guid IdPedido { get; }
        public int CodigoPagamentoPedido { get; }
        public DateTime DataAtualizacao { get; }
    }
}
