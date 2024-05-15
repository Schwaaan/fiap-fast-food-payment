
namespace FourSix.Application.UseCases.Produtos.InativaProduto
{
    public interface IOutputPort
    {
        /// <summary>
        /// Produto Excluido
        /// </summary>
        void Ok();

        /// <summary>
        /// Produto não encontrado
        /// </summary>
        void NotFound();

        /// <summary>
        /// Entrada inválida
        /// </summary>
        void Invalid();

        /// <summary>
        /// Entrada inválida
        /// </summary>
        void ExistPedido();
    }
}
