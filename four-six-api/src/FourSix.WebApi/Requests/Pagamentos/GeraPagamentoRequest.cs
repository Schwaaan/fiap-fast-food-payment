using Swashbuckle.AspNetCore.Annotations;

namespace FourSix.WebApi.Requests.Pagamentos
{
    [SwaggerSchema(Required = new[] { "pedidoId", "valorPedido", "desconto" })]
    public class GeraPagamentoRequest
    {
        /// <summary>
        /// Id do pedido
        /// </summary>
        /// <example>c37b8f54-9a67-45c9-90b3-1f34641578d8</example>
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
