namespace FourSix.Domain.Entities.PagamentoAggregate
{
    public enum EnumStatusPagamento
    {
        AguardandoPagamento = 1,
        Pago = 2,
        Cancelado = 3,
        Negado = 4
    }

    public class StatusPagamento
    {
        public EnumStatusPagamento Id { get; }
        public string Descricao { get; }
    }
}
