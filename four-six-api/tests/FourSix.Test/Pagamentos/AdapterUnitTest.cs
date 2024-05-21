using FourSix.Controllers.Adapters.Pagamentos.AlteraStatusPagamento;
using FourSix.Controllers.Adapters.Pagamentos.BuscaPagamento;
using FourSix.Controllers.Adapters.Pagamentos.GeraPagamento;
using FourSix.Controllers.ViewModels;
using FourSix.Domain.Entities.PagamentoAggregate;
using FourSix.UseCases.UseCases.Pagamentos.AlterarStatusPagamento;
using FourSix.UseCases.UseCases.Pagamentos.BuscaPagamento;
using FourSix.UseCases.UseCases.Pagamentos.GeraPagamento;
using Moq;

namespace FourSix.Test.Pagamentos
{
    public class AdapterUnitTest
    {
        #region [ AlteraStatusPagamento ]

        [Fact]
        public async Task Alterar_status_pagamento_ok()
        {
            // Arrange
            var mockUseCase = new Mock<IAlterarStatusPagamentoUseCase>();
            var pagamento = MontarClassePagamento();
            mockUseCase.Setup(x => x.Execute(pagamento.Id, pagamento.StatusId, pagamento.ValorPago)).ReturnsAsync(pagamento);
            var adapter = new AlteraStatusPagamentoAdapter(mockUseCase.Object);
            var request = new AlteraStatusPagamentRequest
            {
                StatusId = pagamento.StatusId,
                ValorPago = pagamento.ValorPago
            };

            // Act
            var response = await adapter.AlterarStatus(request, pagamento.Id);

            // Assert
            Assert.NotNull(response);
            Assert.IsType<AlteraStatusPagamentoResponse>(response);
            Assert.Equal(pagamento.Id, response.Pagamento.Id);
            Assert.Equal(request.StatusId, response.Pagamento.StatusId);
            Assert.Equal(request.ValorPago, response.Pagamento.ValorPago);

            mockUseCase.Verify(x => x.Execute(pagamento.Id, pagamento.StatusId, pagamento.ValorPago), Times.Once);
        }

        #endregion

        #region [ BuscaPagamento ]

        [Fact]
        public async Task Busca_pagamento_ok()
        {
            // Arrange
            var mockUseCase = new Mock<IBuscaPagamentoUseCase>();
            var pagamento = MontarClassePagamento();
            mockUseCase.Setup(x => x.Execute(pagamento.Id)).ReturnsAsync(pagamento);
            var adapter = new BuscaPagamentoAdapter(mockUseCase.Object);

            // Act
            var response = await adapter.Buscar(pagamento.Id);

            // Assert
            Assert.NotNull(response);
            Assert.Equal(pagamento.Id, response.Pagamento.Id);
            mockUseCase.Verify(x => x.Execute(pagamento.Id), Times.Once);
        }

        #endregion

        #region [ GeraPagamento ]

        [Fact]
        public async Task Gera_pagamento_ok()
        {
            // Arrange
            var mockUseCase = new Mock<IGeraPagamentoUseCase>();
            var pagamento = MontarClassePagamento();
            mockUseCase.Setup(x => x.Execute(pagamento.PedidoId, pagamento.ValorPedido, pagamento.Desconto)).ReturnsAsync(pagamento);
            var adapter = new GeraPagamentoAdapter(mockUseCase.Object);
            var request = new GeraPagamentoRequest
            {
                Desconto = pagamento.Desconto,
                PedidoId = pagamento.PedidoId,
                ValorPedido = pagamento.ValorPedido
            };

            // Act
            var response = await adapter.Gerar(request);

            // Assert
            Assert.NotNull(response);
            Assert.Equal(request.PedidoId, response.Pagamento.PedidoId);

            mockUseCase.Verify(x => x.Execute(pagamento.PedidoId, pagamento.ValorPedido, pagamento.Desconto), Times.Once);
        }

        #endregion

        [Fact]
        public void Constructor_SetsPropertiesCorrectly()
        {
            // Arrange
            var statusPagamento = new StatusPagamento(EnumStatusPagamento.Pago, "Pagamento concluído com sucesso");

            // Act
            var statusPagamentoModel = new StatusPagamentoModel(statusPagamento);

            // Assert
            Assert.Equal(EnumStatusPagamento.Pago, statusPagamentoModel.StatusId);
            Assert.Equal("Pagamento concluído com sucesso", statusPagamentoModel.Descricao);
        }

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

        #endregion
    }
}
