using FourSix.Domain.Entities.PagamentoAggregate;

namespace FourSix.Application.UseCases.Pagamentos.CancelaPagamento
{
    public interface ICancelaPagamentoUseCase
    {
        /// <summary>
        /// Executa o Caso de Uso
        /// </summary>
        Task Execute(Guid pagamentoId);

        /// <summary>
        /// Define a porta de saída
        /// </summary>
        /// <param name="outputPort">Porta de Saída</param>
        void SetOutputPort(IOutputPort<Pagamento> outputPort);
    }
}
