using FourSix.Application.Services;
using FourSix.Domain.Entities.PagamentoAggregate;

namespace FourSix.Application.UseCases.Pagamentos.RealizaPagamento
{
    public class RealizaPagamentoValidationUseCase : IRealizaPagamentoUseCase
    {
        private readonly Notification _notification;
        private readonly IRealizaPagamentoUseCase _useCase;
        private IOutputPort<Pagamento> _outputPort;

        public RealizaPagamentoValidationUseCase(IRealizaPagamentoUseCase useCase, Notification notification)
        {
            _useCase = useCase;
            _notification = notification;
            _outputPort = new RealizaPagamentoPresenter();
        }

        public void SetOutputPort(IOutputPort<Pagamento> outputPort)
        {
            _outputPort = outputPort;
            _useCase.SetOutputPort(outputPort);
        }

        public async Task Execute(Guid pagamentoId, decimal valorPago)
        {
            if (valorPago <= 0)
                _notification
                    .Add(nameof(valorPago), $"{nameof(valorPago)} é obrigatório.");

            if (_notification
            .IsInvalid)
            {
                _outputPort
                    .Invalid();
                return;
            }

            await _useCase
                .Execute(pagamentoId, valorPago)
                .ConfigureAwait(false);
        }
    }
}
