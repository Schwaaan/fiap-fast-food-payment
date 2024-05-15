using FourSix.Domain.Entities.PagamentoAggregate;
using FourSix.UseCases.Interfaces;

namespace FourSix.UseCases.UseCases.Pagamentos.BuscaPagamento
{
    public class BuscaPagamentoUseCase : IBuscaPagamentoUseCase
    {
        private readonly IPagamentoRepository _pagamentoRepository;

        public BuscaPagamentoUseCase(
            IPagamentoRepository pagamentoRepository)
        {
            _pagamentoRepository = pagamentoRepository;
        }

        public Task<Pagamento> Execute(Guid pedidoId) => BuscaPagamento(pedidoId);

        private async Task<Pagamento> BuscaPagamento(Guid pagamentoId)
        {
            var pagamento = _pagamentoRepository.Obter(pagamentoId);

            if (pagamento == null)
            {
                throw new Exception("Pagamento não encontrado");
            }

            return pagamento;
        }
    }
}
