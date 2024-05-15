using FourSix.Controllers.Presenters;
using FourSix.Controllers.ViewModels;
using FourSix.UseCases.UseCases.Pedidos.ObtemStatusPagamentoPedido;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FourSix.Controllers.Adapters.Pedidos.ObtemStatusPagamentoPedido
{
    public class ObtemStatusPagamentoPedidoAdapter : IObtemStatusPagamentoPedidoAdapter
    {
        private readonly Notification _notification;

        private readonly IObtemStatusPagamentoPedidoUseCase _useCase;

        public ObtemStatusPagamentoPedidoAdapter(Notification notification,
            IObtemStatusPagamentoPedidoUseCase useCase)
        {
            _useCase = useCase;
            _notification = notification;
        }

        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ObtemStatusPagamentoPedidoResponse))]
        public async Task<ObtemStatusPagamentoPedidoResponse> ObterStatusPagamento(Guid pedidoId)
        {
            var status = new StatusPagamentoModel(await _useCase.Execute(pedidoId));

            return new ObtemStatusPagamentoPedidoResponse(status);
        }
    }
}
