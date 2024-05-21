using FourSix.Controllers.Gateways.Configurations;
using FourSix.Controllers.Gateways.DataAccess;
using FourSix.Controllers.Gateways.Repositories;
using FourSix.Domain.Entities.PagamentoAggregate;
using Microsoft.EntityFrameworkCore;
using Moq;

namespace FourSix.Test.Pagamentos
{
    public class RepositoryUnitTest
    {
        Mock<DbContext> dbContextMock;
        Mock<DbSet<Pagamento>> dbSetMock;

        public RepositoryUnitTest()
        {
            dbContextMock = new();
            dbSetMock = new();
        }

        #region [ Produto ]

        [Fact]
        public void Obter_resultado_ok()
        {
            // Arrange
            var repository = new PagamentoRepository(dbContextMock.Object);
            var id = Guid.NewGuid();
            var pagamento = MontarClassePagamento();
            dbSetMock.Setup(m => m.Find(id)).Returns(pagamento);
            dbContextMock.Setup(m => m.Set<Pagamento>()).Returns(dbSetMock.Object);

            // Act
            var resultado = repository.Obter(id);

            // Assert
            Assert.Equal(pagamento, resultado);
        }

        [Fact]
        public async Task Incluir_pagamento_ok()
        {
            // Arrange
            var pagamentos = new List<Pagamento> { MontarClassePagamento() };
            var pagamentoIncluir = pagamentos.FirstOrDefault();
            var repository = new PagamentoRepository(dbContextMock.Object);

            var mockSet = new Mock<DbSet<Pagamento>>();

            dbContextMock.Setup(c => c.Set<Pagamento>()).Returns(mockSet.Object);


            // Act
            await repository.Incluir(pagamentoIncluir);
            var _unitOfWork = new UnitOfWork(dbContextMock.Object);
            await _unitOfWork.Save();

            // Assert
            mockSet.Verify(m => m.AddAsync(It.IsAny<Pagamento>(), CancellationToken.None), Times.Once);
        }

        #endregion

        #region [ Configuration ]

        [Fact]
        public void Status_pagamento_configuration_erro()
        {
            // Arrange
            var pagamentoConfiguration = new PagamentoConfiguration();

            // Act
            Action act = () => pagamentoConfiguration.Configure(null);

            // Assert
            Assert.Throws<ArgumentNullException>(act);
        }

        [Fact]
        public void Status_pagamento_configuration_ok()
        {
            // Arrange
            var options = new DbContextOptionsBuilder<PagamentoDbContext>()
                .UseInMemoryDatabase(databaseName: "TestDatabase")
                .Options;

            using var context = new PagamentoDbContext(options);
            var modelBuilder = new ModelBuilder();
            var produtoConfiguration = new StatusPagamentoConfiguration();

            // Act
            produtoConfiguration.Configure(modelBuilder.Entity<StatusPagamento>());

            // Assert
            var entityType = modelBuilder.Model.FindEntityType(typeof(StatusPagamento));
            Assert.NotNull(entityType);

            Assert.Equal("StatusPagamento", entityType.GetTableName());
            Assert.Equal(nameof(Pagamento.Id), entityType.FindPrimaryKey().Properties.First().Name);

            Assert.Equal(20, entityType.FindProperty(nameof(StatusPagamento.Descricao)).GetMaxLength());
        }

        [Fact]
        public void Pagamento_configuration_erro()
        {
            // Arrange
            var produtoConfiguration = new PagamentoConfiguration();

            // Act
            Action act = () => produtoConfiguration.Configure(null);

            // Assert
            Assert.Throws<ArgumentNullException>(act);
        }

        [Fact]
        public void Pagamento_configuration_ok()
        {
            // Arrange
            var options = new DbContextOptionsBuilder<PagamentoDbContext>()
                .UseInMemoryDatabase(databaseName: "TestDatabase")
                .Options;

            using var context = new PagamentoDbContext(options);
            var modelBuilder = new ModelBuilder();
            var produtoConfiguration = new PagamentoConfiguration();

            // Act
            produtoConfiguration.Configure(modelBuilder.Entity<Pagamento>());

            // Assert
            var entityType = modelBuilder.Model.FindEntityType(typeof(Pagamento));
            Assert.NotNull(entityType);

            Assert.Equal("Pagamento", entityType.GetTableName());
            Assert.Equal(nameof(Pagamento.Id), entityType.FindPrimaryKey().Properties.First().Name);

            Assert.Equal(18, entityType.FindProperty(nameof(Pagamento.ValorPedido)).GetPrecision());
            Assert.Equal(2, entityType.FindProperty(nameof(Pagamento.ValorPedido)).GetScale());
        }

        [Fact]
        public void Seed_erro()
        {
            // Arrange


            // Act
            Action act = () => SeedData.Seed(null);

            // Assert
            Assert.Throws<ArgumentNullException>(act);
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

        #endregion
    }

    public class PagamentoDbContext : DbContext
    {
        public PagamentoDbContext(DbContextOptions<PagamentoDbContext> options) : base(options)
        {
        }

        public DbSet<Pagamento> Pagamentos { get; set; }
        public DbSet<StatusPagamento> StatusPagamentos { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            new PagamentoConfiguration().Configure(modelBuilder.Entity<Pagamento>());
            new StatusPagamentoConfiguration().Configure(modelBuilder.Entity<StatusPagamento>());
        }
    }
}
