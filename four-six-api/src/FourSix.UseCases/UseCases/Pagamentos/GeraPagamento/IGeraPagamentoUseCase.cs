using FourSix.Domain.Entities.PagamentoAggregate;

namespace FourSix.UseCases.UseCases.Pagamentos.GeraPagamento
{
    public interface IGeraPagamentoUseCase
    {
        /// <summary>
        /// Executa o Caso de Uso
        /// </summary>
        Task<Pagamento> Execute(Guid pedidoId, decimal valor, decimal desconto);
    }
}
