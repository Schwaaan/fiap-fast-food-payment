using FourSix.Application.Services;
using FourSix.Domain.Entities.PagamentoAggregate;

namespace FourSix.Application.UseCases.Pagamentos.CancelaPagamento
{
    public class CancelaPagamentoUseCase : ICancelaPagamentoUseCase
    {
        private readonly IPagamentoRepository _pagamentoRepository;
        private readonly IUnitOfWork _unitOfWork;
        private IOutputPort<Pagamento> _outputPort;

        public CancelaPagamentoUseCase(
            IPagamentoRepository pagamentoRepository,
            IUnitOfWork unitOfWork)
        {
            _outputPort = new CancelaPagamentoPresenter();
            _pagamentoRepository = pagamentoRepository;
            _unitOfWork = unitOfWork;
        }

        /// <inheritdoc />
        public void SetOutputPort(IOutputPort<Pagamento> outputPort) => _outputPort = outputPort;

        /// <inheritdoc />
        public Task Execute(Guid pedidoId) =>
            CancelarPagamento(pedidoId);

        private async Task CancelarPagamento(Guid pagamentoId)
        {
            var pagamento = _pagamentoRepository.Obter(pagamentoId);

            pagamento.Cancelar();

            var resultado = await _unitOfWork.Save();

            _outputPort?.Ok(pagamento);
        }
    }
}
