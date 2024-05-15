using FourSix.Domain.Entities.PagamentoAggregate;

namespace FourSix.Application.UseCases.Pagamentos.RealizaPagamento
{
    public interface IRealizaPagamentoUseCase
    {
        /// <summary>
        /// Executa o Caso de Uso
        /// </summary>
        Task Execute(Guid pagamentoId, decimal valorPago);

        /// <summary>
        /// Define a porta de saída
        /// </summary>
        /// <param name="outputPort">Porta de Saída</param>
        void SetOutputPort(IOutputPort<Pagamento> outputPort);
    }
}
