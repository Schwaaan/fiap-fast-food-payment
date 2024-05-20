using FourSix.Domain.Entities.PagamentoAggregate;
using FourSix.UseCases.Interfaces;
using Microsoft.Extensions.Configuration;

namespace FourSix.Controllers.Gateways.Integrations
{
    public class OrderIntegrationService : IOrderIntegrationService
    {
        private readonly HttpClient _httpClient;
        public OrderIntegrationService(HttpClient httpClient, IConfiguration configuration)
        {
            _httpClient = httpClient;
            _httpClient.BaseAddress = new Uri(configuration.GetValue<string>("Endpoints:Orders"));
        }

        public async Task AtualizarPedido(Guid pedidoId, EnumStatusPagamento statusPagamento)
        {
            if (statusPagamento != EnumStatusPagamento.AguardandoPagamento)
            {
                int codigoPagamentoPedido = 3;

                switch (statusPagamento)
                {
                    case EnumStatusPagamento.Pago:
                        codigoPagamentoPedido = 3;
                        break;
                    case EnumStatusPagamento.Cancelado:
                        codigoPagamentoPedido = 7;
                        break;
                    case EnumStatusPagamento.Negado:
                        codigoPagamentoPedido = 8;
                        break;
                }

                var response = await _httpClient.PutAsync($"/pedidos/{pedidoId}/status/{codigoPagamentoPedido}", null);
                response.EnsureSuccessStatusCode();
            }
        }
    }
}
