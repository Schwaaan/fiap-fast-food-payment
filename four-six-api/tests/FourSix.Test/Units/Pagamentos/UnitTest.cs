using FourSix.Domain.Entities.PagamentoAggregate;
using FourSix.UseCases.Interfaces;
using FourSix.UseCases.UseCases.Pagamentos.AlterarStatusPagamento;
using FourSix.UseCases.UseCases.Pagamentos.BuscaPagamento;
using FourSix.UseCases.UseCases.Pagamentos.GeraPagamento;
using FourSix.UseCases.UseCases.Pagamentos.GeraQRCode;
using FourSix.UseCases.UseCases.Pagamentos.ObtemStatusPagamentoPedido;
using Moq;
using System.Globalization;

namespace FourSix.Test.Units.Pagamentos
{
    public class UnitTest
    {
        private Mock<IPagamentoRepository> _mockRepository;
        private Mock<IUnitOfWork> _mockUnitOfWork;

        public UnitTest()
        {
            _mockRepository = new();
            _mockUnitOfWork = new();
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

        #endregion

        #region [ AlterarStatusPagamentoUseCase ]

        [Fact]
        public async void Altera_status_pagamento_OK()
        {
            //Arrange
            AlterarStatusPagamentoUseCase useCase = new(_mockRepository.Object, _mockUnitOfWork.Object);
            Pagamento pagamento = MontarClassePagamento();
            _mockRepository.Setup(repo => repo.Obter(pagamento.Id)).Returns(pagamento);
            _mockRepository.Setup(repo => repo.Alterar(pagamento)).Returns(Task.CompletedTask);

            //Act
            await useCase.Execute(pagamento.Id, EnumStatusPagamento.Pago);

            //Assert
            _mockRepository.Verify(repo => repo.Alterar(It.IsAny<Pagamento>()), Times.Once);
            _mockUnitOfWork.Verify(unit => unit.Save(), Times.Once);
        }

        [Fact]
        public async void Altera_status_pagamento_inexistente()
        {
            //Arrange
            AlterarStatusPagamentoUseCase useCase = new(_mockRepository.Object, _mockUnitOfWork.Object);
            Pagamento pagamento = MontarClassePagamento();
            _mockRepository.Setup(repo => repo.Obter(It.IsAny<Guid>())).Returns(() => null);
            _mockRepository.Setup(repo => repo.Alterar(pagamento)).Returns(Task.CompletedTask);

            //Act & Assert
            var ex = await Assert.ThrowsAsync<Exception>(() => useCase.Execute(pagamento.Id, EnumStatusPagamento.Pago));
            Assert.Equal("Pagamento não encontrado", ex.Message);
            _mockRepository.Verify(repo => repo.Alterar(It.IsAny<Pagamento>()), Times.Never);
            _mockUnitOfWork.Verify(unit => unit.Save(), Times.Never);
        }

        #endregion

        #region [ BuscaPagamentoUseCase ]

        [Fact]
        public async void Busca_pagamento_OK()
        {
            //Arrange
            BuscaPagamentoUseCase useCase = new(_mockRepository.Object);
            Pagamento pagamento = MontarClassePagamento();
            _mockRepository.Setup(repo => repo.Obter(pagamento.PedidoId)).Returns(pagamento);

            //Act
            var resultado = await useCase.Execute(pagamento.PedidoId);

            //Assert
            Assert.Equal(pagamento.Id, resultado.Id);
        }

        [Fact]
        public async void Busca_pagamento_inexistente()
        {
            //Arrange
            BuscaPagamentoUseCase useCase = new(_mockRepository.Object);
            Pagamento pagamento = MontarClassePagamento();
            _mockRepository.Setup(repo => repo.Obter(It.IsAny<Guid>())).Returns(() => null);

            //Act & Assert
            var ex = await Assert.ThrowsAsync<Exception>(() => useCase.Execute(pagamento.PedidoId));
            Assert.Equal("Pagamento não encontrado", ex.Message);
        }

        #endregion

        #region [ GeraPagamentoUseCase ]

        [Fact]
        public async void Gera_pagamento_OK()
        {
            //Arrange
            Mock<GeraQRCodeUseCase> geraQRCodeUseCase = new();
            GeraPagamentoUseCase useCase = new(geraQRCodeUseCase.Object, _mockRepository.Object, _mockUnitOfWork.Object);
            Guid pedidoId = Guid.NewGuid();
            decimal valorPedido = 68.75M;
            decimal desconto = 0.50M;
            string qrCodeGerado = "QRCodeGerado";
            Pagamento pagamento = MontarClassePagamento(pedidoId: pedidoId, valorPedido: valorPedido, desconto: desconto);
            geraQRCodeUseCase.Setup(use => use.Execute(pagamento.PedidoId, pagamento.ValorPedido)).ReturnsAsync(qrCodeGerado);
            _mockRepository.Setup(repo => repo.Incluir(pagamento)).Returns(Task.CompletedTask);

            //Act
            var resultado = await useCase.Execute(pagamento.PedidoId, pagamento.ValorPedido, pagamento.Desconto);

            //Assert
            Assert.Equal(pedidoId, resultado.PedidoId);
            Assert.Equal(valorPedido, resultado.ValorPedido);
            Assert.Equal(desconto, resultado.Desconto);
            Assert.Equal(valorPedido - desconto, resultado.ValorTotal);
            Assert.Equal(EnumStatusPagamento.AguardandoPagamento, resultado.StatusId);
            Assert.Equal(qrCodeGerado, resultado.CodigoQR);
            _mockRepository.Verify(repo => repo.Incluir(It.IsAny<Pagamento>()), Times.Once);
            _mockUnitOfWork.Verify(unit => unit.Save(), Times.Once);
        }

        #endregion

        #region [ GeraQRCodeUseCase ]

        [Fact]
        public async void Gera_QRCode_OK()
        {
            //Arrange
            GeraQRCodeUseCase useCase = new();
            Pagamento pagamento = MontarClassePagamento();

            //Act
            var resultado = await useCase.Execute(pagamento.PedidoId, pagamento.ValorPedido);

            //Assert
            Assert.Contains(pagamento.PedidoId.ToString(), resultado);
            Assert.Contains(pagamento.ValorPedido.ToString("0.00", new NumberFormatInfo { NumberDecimalSeparator = "." }), resultado);
        }

        #endregion

        #region [ ObtemStatusPagamentoPedidoUseCase ]

        //[Fact]
        //public async void Obtem_status_pagamento_por_id_pedido_ok()
        //{
        //    //Arrange
        //    ObtemStatusPagamentoPedidoUseCase useCase = new(_mockRepository.Object);
        //    Pagamento pagamento = MontarClassePagamento(statusPagamento: EnumStatusPagamento.Pago);
        //    _mockRepository.Setup(repo => repo.ObterPagamentosPorPedido(pagamento.PedidoId)).Returns(new List<Pagamento> { pagamento });

        //    //Act
        //    var resultado = await useCase.Execute(pagamento.PedidoId);

        //    //Assert
        //    Assert.Equal(new StatusPagamento(), resultado);
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

        #endregion
    }
}
