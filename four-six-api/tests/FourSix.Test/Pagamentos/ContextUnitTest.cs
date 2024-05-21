using FourSix.Controllers.Gateways.DataAccess;
using FourSix.Domain.Entities.PagamentoAggregate;
using Microsoft.EntityFrameworkCore;

namespace FourSix.Test.Pagamentos
{
    public class ContextUnitTest
    {
        [Fact]
        public void Context_ConfiguresDbSets()
        {
            // Arrange
            var options = new DbContextOptionsBuilder<Context>()
                .UseInMemoryDatabase(databaseName: "test_database")
                .Options;

            // Act
            using (var context = new Context(options))
            {
                // Assert
                Assert.NotNull(context.Pagamentos);
                Assert.NotNull(context.StatusPagamentos);
            }
        }

        //[Fact]
        //public void Context_AppliesConfigurations()
        //{
        //    // Arrange
        //    var options = new DbContextOptionsBuilder<Context>()
        //        .UseInMemoryDatabase(databaseName: "test_database")
        //        .Options;

        //    // Act
        //    using (var context = new Context(options))
        //    {
        //        // Assert
        //        Assert.Throws<InvalidOperationException>(() => context.Model.FindEntityType(typeof(Pagamento)));
        //        Assert.Throws<InvalidOperationException>(() => context.Model.FindEntityType(typeof(StatusPagamento)));
        //    }
        //}
    }
}