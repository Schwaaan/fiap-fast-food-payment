using FourSix.Domain.Entities.PagamentoAggregate;

namespace FourSix.UseCases.UseCases.Pagamentos.AlterarStatusPagamento
{
    public interface IAlterarStatusPagamentoUseCase
    {
        Task<Pagamento> Execute(Guid pagamentoId, EnumStatusPagamento statusId);
    }
}
