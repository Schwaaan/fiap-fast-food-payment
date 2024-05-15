using FourSix.Controllers.Presenters;
using FourSix.Controllers.ViewModels;
using FourSix.UseCases.UseCases.Pagamentos.GeraPagamento;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FourSix.Controllers.Adapters.Pagamentos.GeraPagamento
{
    public class GeraPagamentoAdapter : IGeraPagamentoAdapter
    {
        private readonly Notification _notification;
        private readonly IGeraPagamentoUseCase _useCase;

        public GeraPagamentoAdapter(Notification notification,
            IGeraPagamentoUseCase useCase)
        {
            _useCase = useCase;
            _notification = notification;
        }

        [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(GeraPagamentoResponse))]
        public async Task<GeraPagamentoResponse> Gerar(GeraPagamentoRequest request)
        {
            var model = new PagamentoModel(await _useCase.Execute(request.PedidoId, request.ValorPedido, request.Desconto));

            return new GeraPagamentoResponse(model);
        }
    }
}
