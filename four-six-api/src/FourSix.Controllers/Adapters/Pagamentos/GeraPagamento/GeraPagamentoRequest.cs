using Swashbuckle.AspNetCore.Annotations;

namespace FourSix.Controllers.Adapters.Pagamentos.GeraPagamento
{
    [SwaggerSchema(Required = new[] { "pedidoId", "valorPedido", "desconto" })]
    public class GeraPagamentoRequest
    {
        /// <summary>
        /// Id do pedido
        /// </summary>
        /// <example>78e3b8d0-be9a-4407-9304-c61788797808</example>
        [SwaggerSchema(Nullable = false)]
        public Guid PedidoId { get; set; }

        /// <summary>
        /// Valor do pedido
        /// </summary>
        /// <example>23.59</example>
        [SwaggerSchema(Nullable = false)]
        public decimal ValorPedido { get; set; }

        /// <summary>
        /// Valor do desconto
        /// </summary>
        /// <example>2.15</example>
        [SwaggerSchema(Nullable = false)]
        public decimal Desconto { get; set; }
    }
}
