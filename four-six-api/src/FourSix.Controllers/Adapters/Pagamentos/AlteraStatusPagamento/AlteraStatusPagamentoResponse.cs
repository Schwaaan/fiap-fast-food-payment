using FourSix.Controllers.ViewModels;

namespace FourSix.Controllers.Adapters.Pagamentos.AlteraStatusPagamento
{
    public class AlteraStatusPagamentoResponse
    {
        public AlteraStatusPagamentoResponse(PagamentoModel pagamentoModel) => Pagamento = pagamentoModel;
        public PagamentoModel Pagamento { get; }
    }
}
