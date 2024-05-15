using Swashbuckle.AspNetCore.Annotations;

namespace FourSix.WebApi.Requests.Pagamentos
{
    [SwaggerSchema(Required = new[] { "pagamentoId" })]
    public class CancelaPagamentoRequest
    {
        /// <summary>
        /// Id do pagamento
        /// </summary>
        /// <example>c37b8f54-9a67-45c9-90b3-1f34641578d8</example>
        [SwaggerSchema(Nullable = false)]
        public Guid PagamentoId { get; set; }
    }
}
