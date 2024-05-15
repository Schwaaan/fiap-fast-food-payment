namespace FourSix.Domain.Entities.PagamentoAggregate
{
    public class Pagamento : BaseEntity, IAggregateRoot, IBaseEntity
    {
        public Pagamento()
        {
        }

        public Pagamento(Guid pedidoId, string codigoQR, EnumStatusPagamento statusId, decimal valorPedido, decimal desconto, decimal valorPago = 0)
        {
            PedidoId = pedidoId;
            CodigoQR = codigoQR;
            StatusId = statusId;
            ValorPedido = valorPedido;
            Desconto = desconto;
            ValorTotal = valorPedido - desconto;
            ValorPago = valorPago;
            DataAtualizacao = DateTime.Now;
        }

        public Pagamento(Guid id, Guid pedidoId, string codigoQR, EnumStatusPagamento statusId, decimal valorPedido, decimal desconto, decimal valorPago = 0)
        {
            Id = id;
            PedidoId = pedidoId;
            CodigoQR = codigoQR;
            StatusId = statusId;
            ValorPedido = valorPedido;
            Desconto = desconto;
            ValorTotal = valorPedido - desconto;
            ValorPago = valorPago;
            DataAtualizacao = DateTime.Now;
        }

        public Guid PedidoId { get; }
        public string CodigoQR { get; }
        public EnumStatusPagamento StatusId { get; private set; }
        public decimal ValorPedido { get; }
        public decimal Desconto { get; }
        public decimal ValorTotal { get; }
        public decimal ValorPago { get; private set; }
        public DateTime DataAtualizacao { get; private set; }

        public StatusPagamento Status { get; private set; }

        public void AtualizarStatus(EnumStatusPagamento status, decimal? valorPago = null)
        {
            ValorPago = valorPago ?? 0;
            StatusId = status;
            DataAtualizacao = DateTime.Now;
        }
        public void AtualizarStatus(EnumStatusPagamento status)
        {
            StatusId = status;
            DataAtualizacao = DateTime.Now;
        }
    }
}
