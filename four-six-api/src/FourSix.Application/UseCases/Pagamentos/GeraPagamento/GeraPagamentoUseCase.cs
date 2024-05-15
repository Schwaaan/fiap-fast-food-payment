using FourSix.Application.Services;
using FourSix.Application.UseCases.Pagamentos.GeraQRCode;
using FourSix.Domain.Entities.PagamentoAggregate;

namespace FourSix.Application.UseCases.Pagamentos.GeraPagamento
{
    public class GeraPagamentoUseCase : IGeraPagamentoUseCase
    {
        private readonly IGeraQRCodeUseCase _geraQRCodeUseCase;
        private readonly IPagamentoRepository _pagamentoRepository;
        private readonly IUnitOfWork _unitOfWork;
        private IOutputPort<Pagamento> _outputPort;

        public GeraPagamentoUseCase(IGeraQRCodeUseCase geraQRCodeUseCase,
            IPagamentoRepository pagamentoRepository,
            IUnitOfWork unitOfWork)
        {
            _outputPort = new GeraPagamentoPresenter();
            _geraQRCodeUseCase = geraQRCodeUseCase;
            _pagamentoRepository = pagamentoRepository;
            _unitOfWork = unitOfWork;
        }

        /// <inheritdoc />
        public void SetOutputPort(IOutputPort<Pagamento> outputPort) => _outputPort = outputPort;

        /// <inheritdoc />
        public Task Execute(Guid pedidoId, decimal valor, decimal desconto) =>
            GerarPagamento(pedidoId, valor, desconto);

        private async Task GerarPagamento(Guid pedidoId, decimal valor, decimal desconto)
        {
            var qrCode = await _geraQRCodeUseCase.Execute(pedidoId, valor);

            var pagamento = new Pagamento(pedidoId, qrCode, EnumStatusPagamento.AguardandoPagamento, valor, desconto, valor - desconto, 0);

            await _pagamentoRepository.Incluir(pagamento);

            await _unitOfWork.Save();

            _outputPort?.Ok(pagamento);
        }
    }
}
