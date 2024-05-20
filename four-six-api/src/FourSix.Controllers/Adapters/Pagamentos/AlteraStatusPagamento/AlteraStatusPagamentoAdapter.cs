using FourSix.Controllers.ViewModels;
using FourSix.UseCases.Interfaces;
using FourSix.UseCases.UseCases.Pagamentos.AlterarStatusPagamento;

namespace FourSix.Controllers.Adapters.Pagamentos.AlteraStatusPagamento
{
    public class AlteraStatusPagamentoAdapter : IAlteraStatusPagamentoAdapter
    {
        private readonly IAlterarStatusPagamentoUseCase _useCase;
        private readonly IOrderIntegrationService _orderService;

        public AlteraStatusPagamentoAdapter(IAlterarStatusPagamentoUseCase useCase,
            IOrderIntegrationService orderService)
        {
            _useCase = useCase;
            _orderService = orderService;
        }

        public async Task<AlteraStatusPagamentoResponse> AlterarStatus(AlteraStatusPagamentRequest request, Guid pagamentoId)
        {
            PagamentoModel model = null;

            try
            {
                var pagamento = await _useCase.Execute(pagamentoId, request.StatusId, request.ValorPago);

                await _orderService.AtualizarPedido(pagamento.PedidoId, pagamento.StatusId);

                model = new PagamentoModel(pagamento);
            }
            catch
            {
                throw;
            }

            return new AlteraStatusPagamentoResponse(model);
        }
    }
}
