using FourSix.Domain.Entities.PagamentoAggregate;

namespace FourSix.UseCases.UseCases.Pagamentos.BuscaPagamento
{
    public interface IBuscaPagamentoUseCase
    {
        /// <summary>
        /// Executa o Caso de Uso
        /// </summary>
        Task<Pagamento> Execute(Guid pagamentoId);
    }
}
