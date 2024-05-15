namespace FourSix.UseCases.UseCases.Pagamentos.GeraQRCode
{
    public interface IGeraQRCodeUseCase
    {
        /// <summary>
        /// Executa o Caso de Uso
        /// </summary>
        Task<string> Execute(Guid pedidoId, decimal valor);
    }
}
