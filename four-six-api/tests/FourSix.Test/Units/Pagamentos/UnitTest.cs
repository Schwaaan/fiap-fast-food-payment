using FourSix.Domain.Entities.PagamentoAggregate;

namespace FourSix.Test.Units.Pagamentos
{
    public class UnitTest
    {
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

            Pagamento pagamento = new(pedidoId,
                codigoQR,
                statusPagamento,
                valorPedido,
                desconto,
                valorTotal,
                valorPago);

            Assert.Equal(pedidoId, pagamento.PedidoId);
            Assert.Equal(codigoQR, pagamento.CodigoQR);
            Assert.Equal(statusPagamento, pagamento.StatusId);
            Assert.Equal(valorPedido, pagamento.ValorPedido);
            Assert.Equal(desconto, pagamento.Desconto);
            Assert.Equal(valorTotal, pagamento.ValorTotal);
            Assert.Equal(valorPago, pagamento.ValorPago);
        }

        [Fact]
        public void Atualiza_status_pagamento_OK()
        {
            EnumStatusPagamento statusPagamento = EnumStatusPagamento.Pago;

            Pagamento pagamento = new Pagamento();
            pagamento.AtualizarStatus(statusPagamento);

            Assert.Equal(statusPagamento, pagamento.StatusId);
        }

        [Fact]
        public void Atualiza_status_pagamento_com_valor_OK()
        {
            EnumStatusPagamento statusPagamento = EnumStatusPagamento.Pago;
            decimal valorPago = 14.50M;

            Pagamento pagamento = new Pagamento();
            pagamento.AtualizarStatus(statusPagamento, valorPago);

            Assert.Equal(statusPagamento, pagamento.StatusId);
            Assert.Equal(valorPago, pagamento.ValorPago);
        }

    }
}
