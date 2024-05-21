using FourSix.Controllers.ViewModels;
using FourSix.UseCases.UseCases.Pagamentos.ObtemStatusPagamentoPedido;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics.CodeAnalysis;

namespace FourSix.Controllers.Adapters.Pedidos.ObtemStatusPagamentoPedido
{
    [ExcludeFromCodeCoverage]
    public class ObtemStatusPagamentoPedidoAdapter : IObtemStatusPagamentoPedidoAdapter
    {
        private readonly IObtemStatusPagamentoPedidoUseCase _useCase;

        public ObtemStatusPagamentoPedidoAdapter(IObtemStatusPagamentoPedidoUseCase useCase)
        {
            _useCase = useCase;
        }

        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ObtemStatusPagamentoPedidoResponse))]
        public async Task<ObtemStatusPagamentoPedidoResponse> ObterStatusPagamento(Guid pedidoId)
        {
            var status = new StatusPagamentoModel(await _useCase.Execute(pedidoId));

            return new ObtemStatusPagamentoPedidoResponse(status);
        }
    }
}
