using FourSix.Domain.Entities.PagamentoAggregate;

namespace FourSix.Controllers.ViewModels
{
    public class PagamentoModel
    {
        public PagamentoModel(Pagamento pagamento)
        {
            Id = pagamento.Id;
            PedidoId = pagamento.PedidoId;
            CodigoQR = pagamento.CodigoQR;
            StatusId = pagamento.StatusId;
            ValorPedido = pagamento.ValorPedido;
            Desconto = pagamento.Desconto;
            ValorTotal = pagamento.ValorTotal;
            ValorPago = pagamento.ValorPago;
            DataAtualizacao = pagamento.DataAtualizacao;
        }
        public Guid Id { get; }
        public Guid PedidoId { get; }
        public string CodigoQR { get; }
        public EnumStatusPagamento StatusId { get; }
        public decimal ValorPedido { get; }
        public decimal Desconto { get; }
        public decimal ValorTotal { get; }
        public decimal ValorPago { get; }
        public DateTime DataAtualizacao { get; set; }
    }
}
