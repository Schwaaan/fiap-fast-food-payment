using FourSix.UseCases.UseCases.Pagamentos.GeraQRCode;
using FourSix.Domain.Entities.PagamentoAggregate;
using FourSix.UseCases.Interfaces;

namespace FourSix.UseCases.UseCases.Pagamentos.GeraPagamento
{
    public class GeraPagamentoUseCase : IGeraPagamentoUseCase
    {
        private readonly IGeraQRCodeUseCase _geraQRCodeUseCase;
        private readonly IPagamentoRepository _pagamentoRepository;
        private readonly IUnitOfWork _unitOfWork;

        public GeraPagamentoUseCase(IGeraQRCodeUseCase geraQRCodeUseCase,
            IPagamentoRepository pagamentoRepository,
            IUnitOfWork unitOfWork)
        {
            _geraQRCodeUseCase = geraQRCodeUseCase;
            _pagamentoRepository = pagamentoRepository;
            _unitOfWork = unitOfWork;
        }

        public Task<Pagamento> Execute(Guid pedidoId, decimal valor, decimal desconto) =>
            GerarPagamento(pedidoId, valor, desconto);

        private async Task<Pagamento> GerarPagamento(Guid pedidoId, decimal valor, decimal desconto)
        {
            var qrCode = await _geraQRCodeUseCase.Execute(pedidoId, valor);

            var pagamento = new Pagamento(pedidoId, qrCode, EnumStatusPagamento.AguardandoPagamento, valor, desconto, valor - desconto, 0);

            await _pagamentoRepository.Incluir(pagamento);

            await _unitOfWork.Save();

            return pagamento;
        }
    }
}
