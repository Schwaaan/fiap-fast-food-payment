using FourSix.Domain.Entities.ProdutoAggregate;
using Swashbuckle.AspNetCore.Annotations;

namespace FourSix.WebApi.Requests.Produtos
{
    [SwaggerSchema(Required = new[] { "cpf", "nomeCompleto", "email" })]
    public class AlteraProdutoRequest
    {
        /// <summary>
        /// Nome do produto
        /// </summary>
        /// <example>FourSix Burguer Plus</example>
        [SwaggerSchema(Nullable = false)]
        public string Nome { get; set; }
        /// <summary>
        /// Descrição do Produto
        /// </summary>
        /// <example>Lanche com hamburguer de carne, queijo, cebola e molho especial</example>
        [SwaggerSchema(Nullable = false)]
        public string Descricao { get; set; }
        /// <summary>
        /// Categoria
        /// </summary>
        /// <example>1</example>
        [SwaggerSchema(Nullable = false)]
        public EnumCategoriaProduto Categoria { get; set; }
        /// <summary>
        /// Preço deo produto
        /// </summary>
        /// <example>15.30</example>
        [SwaggerSchema(Nullable = false)]
        public decimal Preco { get; set; }
    }
}
