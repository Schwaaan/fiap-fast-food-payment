using FourSix.Domain.Entities.PagamentoAggregate;
using Swashbuckle.AspNetCore.Annotations;

namespace FourSix.Controllers.Adapters.Pagamentos.AlteraStatusPagamento
{
    [SwaggerSchema(Required = new[] { "statusId" })]
    public class AlteraStatusPagamentRequest
    {
        /// <summary>
        /// Novo status do pagamento
        /// 
        /// AguardandoPagamento = 1
        /// Pago = 2
        /// Cancelado = 3
        /// Negado = 4
        /// </summary>
        /// <example>2</example>
        public EnumStatusPagamento StatusId { get; set; }

        /// <summary>
        /// Valor pago
        /// </summary>
        /// <example>47.15</example>
        public decimal? ValorPago { get; set; }
    }
}
