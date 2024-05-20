using FourSix.Controllers.ViewModels;
using FourSix.UseCases.Interfaces;
using FourSix.UseCases.UseCases.Pagamentos.AlterarStatusPagamento;

namespace FourSix.Controllers.Adapters.Pagamentos.AlteraStatusPagamento
{
    public class AlteraStatusPagamentoAdapter : IAlteraStatusPagamentoAdapter
    {
        private readonly IAlterarStatusPagamentoUseCase _useCase;

        public AlteraStatusPagamentoAdapter(IAlterarStatusPagamentoUseCase useCase)
        {
            _useCase = useCase;
        }

        public async Task<AlteraStatusPagamentoResponse> AlterarStatus(AlteraStatusPagamentRequest request, Guid pagamentoId)
        {
            PagamentoModel model = null;

            try
            {
                var pagamento = await _useCase.Execute(pagamentoId, request.StatusId, request.ValorPago);

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
