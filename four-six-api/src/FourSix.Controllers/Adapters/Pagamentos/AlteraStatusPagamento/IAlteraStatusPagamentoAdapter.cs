namespace FourSix.Controllers.Adapters.Pagamentos.AlteraStatusPagamento
{
    public interface IAlteraStatusPagamentoAdapter
    {
        Task<AlteraStatusPagamentoResponse> AlterarStatus(AlteraStatusPagamentRequest request, Guid pagamentoId);
    }
}
