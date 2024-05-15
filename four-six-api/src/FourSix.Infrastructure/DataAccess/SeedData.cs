using FourSix.Domain.Entities.PagamentoAggregate;
using FourSix.Domain.Entities.PedidoAggregate;
using FourSix.Domain.Entities.ProdutoAggregate;
using FourSix.Domain.Entities.ClienteAggregate;
using Microsoft.EntityFrameworkCore;

namespace FourSix.Infrastructure.DataAccess
{
    public static class SeedData
    {
        public static void Seed(ModelBuilder builder)
        {
            if (builder == null)
            {
                throw new ArgumentNullException(nameof(builder));
            }

            #region POPULA StatusPedido

            builder.Entity<StatusPedido>()
                .HasData(
                new
                {
                    Id = EnumStatusPedido.Recebido,
                    Descricao = "Recebido"
                },
                new
                {
                    Id = EnumStatusPedido.Pago,
                    Descricao = "Pago"
                },
                new
                {
                    Id = EnumStatusPedido.EmPreparacao,
                    Descricao = "Em Preparação"
                },
                new
                {
                    Id = EnumStatusPedido.Montagem,
                    Descricao = "Montagem"
                },
                new
                {
                    Id = EnumStatusPedido.Pronto,
                    Descricao = "Pronto"
                },
                new
                {
                    Id = EnumStatusPedido.Finalizado,
                    Descricao = "Finalizado"
                });

            #endregion

            #region POPULA StatusPagamento

            builder.Entity<StatusPagamento>()
                .HasData(
                 new
                 {
                     Id = EnumStatusPagamento.AguardandoPagamento,
                     Descricao = "Aguardando Pagamento"
                 },
                new
                {
                    Id = EnumStatusPagamento.Pago,
                    Descricao = "Pago"
                },
                new
                {
                    Id = EnumStatusPagamento.Cancelado,
                    Descricao = "Cancelado"
                });

            #endregion

            #region POPULA Produto

            builder.Entity<Produto>()
               .HasData(
                new
                {
                    Id = new Guid("63c776f5-4539-478e-a17a-54d3a1c2d3ee"),
                    Nome = "Burger Four",
                    Descricao = "Pão, carne, alface, tomate e maionese ESPECIAL",
                    Categoria = EnumCategoriaProduto.Lanche,
                    Preco = 5.5m,
                    Ativo = true
                },
                new {
                    Id = new Guid("7686debb-92c2-4d89-a669-8988da8e8c72"),
                    Nome = "Burguer Six",
                    Descricao = "Pão, carne, queijo, alface, tomate e maionese ESPECIAL",
                    Categoria = EnumCategoriaProduto.Lanche,
                    Preco = 7.5m,
                    Ativo = true
                },
                new {
                    Id = new Guid("947e3d62-26fa-4ba6-8395-39c259fc43ec"),
                    Nome = "Burguer FourSix",
                    Descricao = "Pão, carne, queijo, ovo, bacon, alface, tomate e maionese ESPECIAL",
                    Categoria = EnumCategoriaProduto.Lanche,
                    Preco = 10m,
                    Ativo = true
                },
                new
                {
                    Id = new Guid("9482fcf0-e9e4-4bdc-869f-ad7d1d15016c"),
                    Nome = "Coca-cola",
                    Descricao = "Coca-cola 600ml",
                    Categoria = EnumCategoriaProduto.Bebida,
                    Preco = 8.25m,
                    Ativo = true
                },
                new
                {
                    Id = new Guid("a0d0225e-0f3c-42ff-935d-beb44bb2cac4"),
                    Nome = "H2O",
                    Descricao = "H2O 500ml",
                    Categoria = EnumCategoriaProduto.Bebida,
                    Preco = 8.25m,
                    Ativo = true
                },
                new
                {
                    Id = new Guid("a45a3af2-17db-459f-867a-b0c2e1261dc0"),
                    Nome = "Suco Natural de Laranja",
                    Descricao = "Suco Natural de Laranja 500ml",
                    Categoria = EnumCategoriaProduto.Bebida,
                    Preco = 10m,
                    Ativo = true
                },
                new
                {
                    Id = new Guid("c2a49da0-6bc2-4cdc-be77-97d0284b8c92"),
                    Nome = "Batata Frita",
                    Descricao = "Batata Frita especial",
                    Categoria = EnumCategoriaProduto.Acompanhamento,
                    Preco = 6.50m,
                    Ativo = true
                },
                new
                {
                    Id = new Guid("c55a9ca7-411d-4245-8b91-1efbc30f7a9b"),
                    Nome = "Onion",
                    Descricao = "Cebola empanada especial",
                    Categoria = EnumCategoriaProduto.Acompanhamento,
                    Preco = 8.25m,
                    Ativo = true
                },
                new
                {
                    Id = new Guid("d23c72b6-0bbe-4e0d-a46e-b8d72da5e9ef"),
                    Nome = "Sorvete de Baunilha",
                    Descricao = "Casquinha de sorvete de baunilha",
                    Categoria = EnumCategoriaProduto.Sobremesa,
                    Preco = 1.25m,
                    Ativo = true
                },
                new
                {
                    Id = new Guid("ea5df339-afd7-41b6-a4ab-44979c1d919d"),
                    Nome = "Bolo Sensação",
                    Descricao = "Bolo de chocolate com recheio de creme de morango",
                    Categoria = EnumCategoriaProduto.Sobremesa,
                    Preco = 3.25m,
                    Ativo = true
                });

            #endregion

            #region POPULA Cliente

            builder.Entity<Cliente>()
              .HasData(
               new
               {
                   Id = new Guid("717B2FB9-4BBE-4A8C-8574-7808CD652E0B"),
                   Cpf = "12851671049",
                   Nome = "João da Silva Gomes",
                   Email = "joao.silva@gmail.com"
               });

            #endregion

            #region POPULA Pedido
            var dataPedido = DateTime.Now.AddHours(-5);
            builder.Entity<Pedido>()
              .HasData(
               new
               {
                   Id = new Guid("78E3B8D0-BE9A-4407-9304-C61788797808"),
                   NumeroPedido = 1,
                   ClienteId = new Guid("717B2FB9-4BBE-4A8C-8574-7808CD652E0B"),
                   DataPedido = dataPedido,
                   StatusId = EnumStatusPedido.Recebido
               });

            #endregion

            #region POPULA PedidoItem

            builder.Entity<PedidoItem>()
              .HasData(
               new
               {
                   PedidoId = new Guid("78E3B8D0-BE9A-4407-9304-C61788797808"),
                   ItemPedidoId = new Guid("63c776f5-4539-478e-a17a-54d3a1c2d3ee"),
                   ValorUnitario = 5.5m,
                   Quantidade = 2,
                   Observacao = "Sem tomate"
               },
               new
               {
                   PedidoId = new Guid("78E3B8D0-BE9A-4407-9304-C61788797808"),
                   ItemPedidoId = new Guid("9482fcf0-e9e4-4bdc-869f-ad7d1d15016c"),
                   ValorUnitario = 8.25m,
                   Quantidade = 1
               });

            #endregion

            #region POPULA ProdutoCheckout

            builder.Entity<PedidoCheckout>()
              .HasData(
               new
               {
                   PedidoId = new Guid("78E3B8D0-BE9A-4407-9304-C61788797808"),
                   StatusId = EnumStatusPedido.Recebido,
                   DataStatus = dataPedido,
                   Sequencia = 0
               });

            #endregion
        }
    }
}
