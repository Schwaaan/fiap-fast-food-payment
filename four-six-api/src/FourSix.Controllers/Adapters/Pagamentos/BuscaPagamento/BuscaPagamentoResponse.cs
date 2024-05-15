using FourSix.Controllers.ViewModels;

namespace FourSix.Controllers.Adapters.Pagamentos.BuscaPagamento
{
    public class BuscaPagamentoResponse
    {
        public BuscaPagamentoResponse(PagamentoModel pagamentoModel) => Pagamento = pagamentoModel;
        public PagamentoModel Pagamento { get; }
    }
}
