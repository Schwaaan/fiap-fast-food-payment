namespace FourSix.Application.UseCases.Produtos.InativaProduto
{
    public interface IInativaProdutoUseCase
    {
        /// <summary>
        /// Executa o Caso de Uso
        /// </summary>
        Task Execute(Guid produtoId);

        /// <summary>
        /// Define a porta de saída
        /// </summary>
        /// <param name="outputPort">Porta de Saída</param>
        void SetOutputPort(IOutputPort outputPort);
    }
}
