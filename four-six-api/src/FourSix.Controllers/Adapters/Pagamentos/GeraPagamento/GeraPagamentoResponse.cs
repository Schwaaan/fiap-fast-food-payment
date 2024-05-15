using FourSix.Controllers.ViewModels;

namespace FourSix.Controllers.Adapters.Pagamentos.GeraPagamento
{
    public class GeraPagamentoResponse
    {
        public GeraPagamentoResponse(PagamentoModel pagamentoModel) => Pagamento = pagamentoModel;
        public PagamentoModel Pagamento { get; }
    }
}
