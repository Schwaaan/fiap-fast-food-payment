using Swashbuckle.AspNetCore.Annotations;

namespace FourSix.WebApi.Requests.Pedidos
{
    [SwaggerSchema(Required = new[] { "numeroPedido", "dataPedido", "clienteId", "items" })]
    public class CancelaPedidoRequest
    {
        /// <summary>
        /// Id do Pedido
        /// </summary>
        /// <example>9b084d56-9d07-4060-87f2-9e053af42189</example>
        [SwaggerSchema(Nullable = false)]
        public Guid PedidoId { get; set; }

        /// <summary>
        /// Data do Cancelamento
        /// </summary>
        /// <example>2023-10-24T18:00</example>
        [SwaggerSchema(Nullable = false)]
        public DateTime DataCancelamento { get; set; }
    }
}
