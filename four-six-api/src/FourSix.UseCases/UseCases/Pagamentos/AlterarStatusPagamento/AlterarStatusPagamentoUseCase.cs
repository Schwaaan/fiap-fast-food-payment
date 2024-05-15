using FourSix.Domain.Entities.PagamentoAggregate;
using FourSix.UseCases.Interfaces;

namespace FourSix.UseCases.UseCases.Pagamentos.AlterarStatusPagamento
{
    public class AlterarStatusPagamentoUseCase : IAlterarStatusPagamentoUseCase
    {
        private readonly IPagamentoRepository _pagamentoRepository;
        private readonly IUnitOfWork _unitOfWork;

        public AlterarStatusPagamentoUseCase(
            IPagamentoRepository pagamentoRepository,
            IUnitOfWork unitOfWork)
        {
            _pagamentoRepository = pagamentoRepository;
            _unitOfWork = unitOfWork;
        }

        public Task<Pagamento> Execute(Guid pagamentoId, EnumStatusPagamento statusId) => AlterarStatus(pagamentoId, statusId);

        private async Task<Pagamento> AlterarStatus(Guid pagamentoId, EnumStatusPagamento statusId, decimal? valorPago = null)
        {
            var pagamento = _pagamentoRepository.Obter(pagamentoId);

            if (pagamento == null)
            {
                throw new Exception("Pagamento não encontrado");
            }

            pagamento.AtualizarStatus(statusId, valorPago);

            await _unitOfWork.Save();

            return pagamento;
        }
    }
}
