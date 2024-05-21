using FourSix.Controllers.Adapters.Pagamentos.BuscaPagamento;
using FourSix.Controllers.Adapters.Pedidos.ObtemStatusPagamentoPedido;
using FourSix.Domain.Entities.PagamentoAggregate;
using FourSix.UseCases.Interfaces;
using FourSix.UseCases.UseCases.Pagamentos.BuscaPagamento;
using FourSix.UseCases.UseCases.Pagamentos.ObtemStatusPagamentoPedido;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FourSix.Test.Pedidos
{
    public class AdapterUnitTest
    {
        private Mock<IPagamentoRepository> _mockRepository;
        private Mock<IUnitOfWork> _mockUnitOfWork;
        private Mock<IOrderIntegrationService> _mockIntegrationService;
        public AdapterUnitTest()
        {
            _mockRepository = new();
            _mockUnitOfWork = new();
            _mockIntegrationService = new();
        }

        #region [ ObtemStatusPagamentoPedido ]

        //[Fact]
        //public async Task Obter_status_pagamento_por_pedido_ok()
        //{
        //    // Arrange
        //    var mockUseCase = new Mock<IObtemStatusPagamentoPedidoUseCase>();
        //    var statusPagamento = MontarClassePagamento();
        //    Guid pedidoId = Guid.NewGuid();
        //    mockUseCase.Setup<StatusPagamento>(x => x.Execute(pedidoId)).ReturnsAsync(statusPagamento);
        //    var adapter = new ObtemStatusPagamentoPedidoAdapter(mockUseCase.Object);

        //    // Act
        //    var response = await adapter.ObterStatusPagamento(pedidoId);

        //    // Assert
        //    Assert.NotNull(response);
        //    Assert.Equal(pagamento.Id, response.Pagamento.Id);
        //    mockUseCase.Verify(x => x.Execute(pagamento.Id), Times.Once);
        //}

        #endregion

        #region [ Private methods ]

        private Pagamento MontarClassePagamento(Guid? id = null, Guid? pedidoId = null, string? codigoQR = null, EnumStatusPagamento? statusPagamento = null, decimal? valorPedido = null, decimal? desconto = null, decimal? valorTotal = null, decimal? valorPago = null)
        {
            id ??= Guid.NewGuid();
            pedidoId ??= Guid.NewGuid();
            valorPedido ??= 26.80M;
            desconto ??= 1.68M;

            return new Pagamento(id.Value,
                pedidoId.Value,
                codigoQR ?? "CodigoQR",
                statusPagamento != null ? statusPagamento.Value : EnumStatusPagamento.AguardandoPagamento,
                valorPedido.Value,
                desconto.Value,
                valorPago ?? 0);
        }

        private StatusPagamento MontarClasseStatusPagamento()
        {
            return new StatusPagamento(EnumStatusPagamento.Pago, "Pago");
        }

        #endregion
    }
}
