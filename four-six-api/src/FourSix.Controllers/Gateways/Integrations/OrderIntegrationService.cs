using Amazon;
using Amazon.SQS;
using Amazon.SQS.Model;
using FourSix.Controllers.ViewModels;
using FourSix.Domain.Entities.PagamentoAggregate;
using FourSix.UseCases.Interfaces;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System.Diagnostics.CodeAnalysis;

namespace FourSix.Controllers.Gateways.Integrations
{
    [ExcludeFromCodeCoverage]
    public class OrderIntegrationService : IOrderIntegrationService
    {
        private readonly AmazonSQSClient _amazonSQSClient;
        private readonly string _endpointQueue;

        public OrderIntegrationService(IConfiguration configuration)
        {
            _amazonSQSClient = new AmazonSQSClient(RegionEndpoint.USEast1);
            _endpointQueue = configuration.GetValue<string>("Endpoints:OrdersQueue");
        }

        public async Task AtualizarPedido(Guid pedidoId, EnumStatusPagamento statusPagamento)
        {
            if (statusPagamento != EnumStatusPagamento.AguardandoPagamento)
            {
                int codigoStatusPedido = 3;

                switch (statusPagamento)
                {
                    case EnumStatusPagamento.Pago:
                        codigoStatusPedido = 3;
                        break;
                    case EnumStatusPagamento.Cancelado:
                        codigoStatusPedido = 7;
                        break;
                    case EnumStatusPagamento.Negado:
                        codigoStatusPedido = 8;
                        break;
                }

                var request = new SendMessageRequest
                {
                    QueueUrl = _endpointQueue,
                    MessageBody = JsonConvert.SerializeObject(new PedidoModel(pedidoId, codigoStatusPedido),
                    new JsonSerializerSettings
                    {
                        ContractResolver = new CamelCasePropertyNamesContractResolver()
                    })
                };

                await _amazonSQSClient.SendMessageAsync(request);
            }
        }
    }
}
