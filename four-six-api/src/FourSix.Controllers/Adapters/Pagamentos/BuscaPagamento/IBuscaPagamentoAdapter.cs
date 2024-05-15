namespace FourSix.Controllers.Adapters.Pagamentos.BuscaPagamento
{
    public interface IBuscaPagamentoAdapter
    {
        Task<BuscaPagamentoResponse> Buscar(Guid pagamentoId);
    }
}
