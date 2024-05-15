using FourSix.Domain.Entities.ProdutoAggregate;

namespace FourSix.Application.UseCases.Produtos.AlteraProduto
{
    public interface IOutputPort
    {
        /// <summary>
        /// Novo Produto
        /// </summary>
        void Ok(Produto produto);

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
        void Exist();
    }
}
