namespace FourSix.Controllers.Adapters.Pagamentos.GeraPagamento
{
    public interface IGeraPagamentoAdapter
    {
        Task<GeraPagamentoResponse> Gerar(GeraPagamentoRequest request);
    }
}
