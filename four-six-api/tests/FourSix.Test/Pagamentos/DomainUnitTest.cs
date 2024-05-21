using FourSix.Domain.Entities.PagamentoAggregate;
using FourSix.UseCases.Interfaces;
using FourSix.UseCases.UseCases.Pagamentos.AlterarStatusPagamento;
using FourSix.UseCases.UseCases.Pagamentos.BuscaPagamento;
using FourSix.UseCases.UseCases.Pagamentos.GeraPagamento;
using FourSix.UseCases.UseCases.Pagamentos.GeraQRCode;
using FourSix.UseCases.UseCases.Pagamentos.ObtemStatusPagamentoPedido;
using Moq;
using System.Globalization;

namespace FourSix.Test.Pagamentos
{
    public class DomainUnitTest
    {
        private Mock<IPagamentoRepository> _mockRepository;
        private Mock<IUnitOfWork> _mockUnitOfWork;
        private Mock<IOrderIntegrationService> _mockIntegrationService;
        public DomainUnitTest()
        {
            _mockRepository = new();
            _mockUnitOfWork = new();
            _mockIntegrationService = new();
        }

        #region [ Classe Pagamento ]

        [Fact]
        public void Cria_classe_pagamento()
        {
            Guid pedidoId = Guid.NewGuid();
            string codigoQR = "codigodeteste";
            EnumStatusPagamento statusPagamento = EnumStatusPagamento.AguardandoPagamento;
            decimal valorPedido = 35.78M;
            decimal desconto = 1.50M;
            decimal valorTotal = valorPedido - desconto;
            decimal valorPago = 0;

            Pagamento pagamento = MontarClassePagamento(pedidoId: pedidoId,
                codigoQR: codigoQR,
                statusPagamento: statusPagamento,
                valorPedido: valorPedido,
                desconto: desconto,
                valorPago: valorPago);

            Assert.Equal(pedidoId, pagamento.PedidoId);
            Assert.Equal(codigoQR, pagamento.CodigoQR);
            Assert.Equal(statusPagamento, pagamento.StatusId);
            Assert.Equal(valorPedido, pagamento.ValorPedido);
            Assert.Equal(desconto, pagamento.Desconto);
            Assert.Equal(valorTotal, pagamento.ValorTotal);
            Assert.Equal(valorPago, pagamento.ValorPago);
        }

        public void Cria_classe_status_pagamento()
        {
            StatusPagamento statusPagamento = MontarClasseStatusPagamento();

            Assert.True(statusPagamento.Id > 0);
            Assert.False(string.IsNullOrEmpty(statusPagamento.Descricao));
        }

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
