using FourSix.Domain.Entities.PagamentoAggregate;
using FourSix.UseCases.Interfaces;

namespace FourSix.UseCases.UseCases.Pagamentos.AlterarStatusPagamento
{
    public class AlterarStatusPagamentoUseCase : IAlterarStatusPagamentoUseCase
    {
        private readonly IPagamentoRepository _pagamentoRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IOrderIntegrationService _orderService;

        public AlterarStatusPagamentoUseCase(
            IPagamentoRepository pagamentoRepository,
            IUnitOfWork unitOfWork,
            IOrderIntegrationService orderService)
        {
            _pagamentoRepository = pagamentoRepository;
            _unitOfWork = unitOfWork;
            _orderService = orderService;
        }

        public Task<Pagamento> Execute(Guid pagamentoId, EnumStatusPagamento statusId, decimal? valorPago = null) => AlterarStatus(pagamentoId, statusId, valorPago);

        private async Task<Pagamento> AlterarStatus(Guid pagamentoId, EnumStatusPagamento statusId, decimal? valorPago = null)
        {
            var pagamento = _pagamentoRepository.Obter(pagamentoId);

            if (pagamento == null)
            {
                throw new Exception("Pagamento não encontrado");
            }

            pagamento.AtualizarStatus(statusId, valorPago);

            await _pagamentoRepository.Alterar(pagamento);

            await _orderService.AtualizarPedido(pagamento.PedidoId, pagamento.StatusId);

            await _unitOfWork.Save();

            return pagamento;
        }
    }
}
