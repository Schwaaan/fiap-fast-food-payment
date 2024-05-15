using FourSix.Application.Services;
using FourSix.Domain.Entities.PagamentoAggregate;

namespace FourSix.Application.UseCases.Pagamentos.RealizaPagamento
{
    public class RealizaPagamentoUseCase : IRealizaPagamentoUseCase
    {
        private readonly IPagamentoRepository _pagamentoRepository;
        private readonly IUnitOfWork _unitOfWork;
        private IOutputPort<Pagamento> _outputPort;

        public RealizaPagamentoUseCase(
            IPagamentoRepository pagamentoRepository,
            IUnitOfWork unitOfWork)
        {
            _outputPort = new RealizaPagamentoPresenter();
            _pagamentoRepository = pagamentoRepository;
            _unitOfWork = unitOfWork;
        }

        /// <inheritdoc />
        public void SetOutputPort(IOutputPort<Pagamento> outputPort) => _outputPort = outputPort;

        /// <inheritdoc />
        public Task Execute(Guid pedidoId, decimal valorPago) =>
            RealizarPagamento(pedidoId, valorPago);

        private async Task RealizarPagamento(Guid pagamentoId, decimal valorPago)
        {
            var pagamento = _pagamentoRepository.Obter(pagamentoId);

            pagamento.Pagar(valorPago);

            var resultado = await _unitOfWork.Save();

            _outputPort?.Ok(pagamento);
        }
    }
}
