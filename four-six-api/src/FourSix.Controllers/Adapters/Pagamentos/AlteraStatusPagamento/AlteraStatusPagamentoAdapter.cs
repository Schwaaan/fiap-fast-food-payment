using FourSix.Controllers.Presenters;
using FourSix.Controllers.ViewModels;
using FourSix.UseCases.UseCases.Pagamentos.AlterarStatusPagamento;

namespace FourSix.Controllers.Adapters.Pagamentos.AlteraStatusPagamento
{
    public class AlteraStatusPagamentoAdapter : IAlteraStatusPagamentoAdapter
    {
        private readonly Notification _notification;

        private readonly IAlterarStatusPagamentoUseCase _useCase;

        public AlteraStatusPagamentoAdapter(Notification notification,
            IAlterarStatusPagamentoUseCase useCase)
        {
            _useCase = useCase;
            _notification = notification;
        }

        public async Task<AlteraStatusPagamentoResponse> AlterarStatus(AlteraStatusPagamentRequest request, Guid pagamentoId)
        {
            var model = new PagamentoModel(await _useCase.Execute(pagamentoId, request.StatusId));

            return new AlteraStatusPagamentoResponse(model);
        }
    }
}
