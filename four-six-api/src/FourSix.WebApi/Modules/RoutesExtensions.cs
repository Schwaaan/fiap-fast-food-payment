using FourSix.Controllers.Adapters.Pagamentos.AlteraStatusPagamento;
using FourSix.Controllers.Adapters.Pagamentos.BuscaPagamento;
using FourSix.Controllers.Adapters.Pagamentos.GeraPagamento;
using FourSix.Controllers.Adapters.Pedidos.ObtemStatusPagamentoPedido;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace FourSix.WebApi.Modules
{
    public static class RoutesExtensions
    {
        public static void AddRoutesMaps(this IEndpointRouteBuilder app)
        {
            #region [ Pedidos ]

            app.MapGet("pedidos/{pedidoId:Guid}/pagamentos",
            [SwaggerOperation(Summary = "Obtém o status do pagamento do pedido")]
            ([SwaggerParameter("Id do pedido")] Guid pedidoId, IObtemStatusPagamentoPedidoAdapter adapter) =>
            {
                return adapter.ObterStatusPagamento(pedidoId);
            }).WithTags("Pedidos").AllowAnonymous(); ;

            #endregion
            #region [ Pagamentos ]

            app.MapPost("pagamentos",
            [SwaggerOperation(Summary = "Gera novo pagamento")]
            ([SwaggerParameter("Dados do pagamento")][FromBody] GeraPagamentoRequest request, IGeraPagamentoAdapter adapter) =>
            {
                return adapter.Gerar(request);
            }).WithTags("Pagamentos").AllowAnonymous(); ;

            app.MapPut("pagamentos/{pagamentoId:Guid}/status",
            [SwaggerOperation(Summary = "Altera o status do pagamento")]
            ([SwaggerParameter("Id do pagamento")] Guid pagamentoId,
            [SwaggerParameter("Dados do pagamento")][FromBody] AlteraStatusPagamentRequest request, IAlteraStatusPagamentoAdapter adapter) =>
            {
                return adapter.AlterarStatus(request, pagamentoId);
            }).WithTags("Pagamentos").AllowAnonymous(); ;

            app.MapGet("pagamentos/{pagamentoId:Guid}",
            [SwaggerOperation(Summary = "Obtém o pagamento")]
            ([SwaggerParameter("Id do pagamento")] Guid pagamentoId, IBuscaPagamentoAdapter adapter) =>
            {
                return adapter.Buscar(pagamentoId);
            }).WithTags("Pagamentos").AllowAnonymous(); ;

            #endregion
        }
    }
}
