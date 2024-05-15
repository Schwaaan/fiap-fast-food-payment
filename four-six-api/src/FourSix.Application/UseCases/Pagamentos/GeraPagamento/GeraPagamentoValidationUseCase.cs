using FourSix.Application.Services;
using FourSix.Domain.Entities.PagamentoAggregate;

namespace FourSix.Application.UseCases.Pagamentos.GeraPagamento
{
    public class GeraPagamentoValidationUseCase : IGeraPagamentoUseCase
    {
        private readonly Notification _notification;
        private readonly IGeraPagamentoUseCase _useCase;
        private IOutputPort<Pagamento> _outputPort;

        public GeraPagamentoValidationUseCase(IGeraPagamentoUseCase useCase, Notification notification)
        {
            _useCase = useCase;
            _notification = notification;
            _outputPort = new GeraPagamentoPresenter();
        }

        public void SetOutputPort(IOutputPort<Pagamento> outputPort)
        {
            _outputPort = outputPort;
            _useCase.SetOutputPort(outputPort);
        }

        public async Task Execute(Guid pedidoId, decimal valor, decimal desconto)
        {
            if (valor <= 0)
                _notification
                    .Add(nameof(valor), $"{nameof(valor)} é obrigatório.");

            if (_notification
            .IsInvalid)
            {
                _outputPort
                    .Invalid();
                return;
            }

            await _useCase
                .Execute(pedidoId, valor, desconto)
                .ConfigureAwait(false);
        }
    }
}
