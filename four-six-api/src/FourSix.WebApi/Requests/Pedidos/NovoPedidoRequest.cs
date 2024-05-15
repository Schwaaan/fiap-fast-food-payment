using Swashbuckle.AspNetCore.Annotations;

namespace FourSix.WebApi.Requests.Pedidos
{
    [SwaggerSchema(Required = new[] { "numeroPedido", "dataPedido", "clienteId", "items" })]
    public class NovoPedidoRequest
    {
        /// <summary>
        /// Data do Pedido
        /// </summary>
        /// <example>2023-10-24T18:00</example>
        [SwaggerSchema(Nullable = false)]
        public DateTime DataPedido { get; set; }

        /// <summary>
        /// Id do Cliente
        /// </summary>
        /// <example>9b084d56-9d07-4060-87f2-9e053af42189</example>
        [SwaggerSchema(Nullable = true)]
        public Guid? ClienteId { get; set; }

        /// <summary>
        /// Itens do Pedido
        /// </summary>
        [SwaggerSchema(Nullable = false)]
        public ICollection<NovoPedidoItemRequest> Items { get; set; } = new List<NovoPedidoItemRequest>();
    }

    public class NovoPedidoItemRequest
    {
        /// <summary>
        /// Id do Produto
        /// </summary>
        /// <example>00b63caa-f9b1-441d-8f5e-29f270981243</example>
        [SwaggerSchema(Nullable = false)]
        public Guid ItemPedidoId { get; set; }

        /// <summary>
        /// Valor do Produto
        /// </summary>
        /// <example>39,90</example>
        [SwaggerSchema(Nullable = false)]
        public decimal ValorUnitario { get; set; }

        /// <summary>
        /// Quantidade do produto
        /// </summary>
        /// <example>1</example>
        [SwaggerSchema(Nullable = false)]
        public int Quantidade { get; set; }

        /// <summary>
        /// Observação
        /// </summary>
        /// <example>Sem cebola</example>
        [SwaggerSchema(Nullable = true)]
        public string? Observacao { get; set; }
    }
}
