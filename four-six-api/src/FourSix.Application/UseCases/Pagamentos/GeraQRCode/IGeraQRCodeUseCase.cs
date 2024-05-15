namespace FourSix.Application.UseCases.Pagamentos.GeraQRCode
{
    public interface IGeraQRCodeUseCase
    {
        /// <summary>
        /// Executa o Caso de Uso
        /// </summary>
        Task<string> Execute(Guid pedidoId, decimal valor);

        /// <summary>
        /// Define a porta de saída
        /// </summary>
        /// <param name="outputPort">Porta de Saída</param>
        void SetOutputPort(IOutputPort<string> outputPort);
    }
}
