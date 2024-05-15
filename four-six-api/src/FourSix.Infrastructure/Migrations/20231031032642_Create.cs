using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace FourSix.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class Create : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Cliente",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Cpf = table.Column<string>(type: "nvarchar(11)", maxLength: 11, nullable: false),
                    Nome = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cliente", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Produto",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Nome = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Descricao = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Categoria = table.Column<int>(type: "int", nullable: false),
                    Preco = table.Column<decimal>(type: "decimal(6,2)", precision: 6, scale: 2, nullable: false),
                    Ativo = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Produto", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "StatusPagamento",
                columns: table => new
                {
                    Id = table.Column<short>(type: "smallint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Descricao = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StatusPagamento", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "StatusPedido",
                columns: table => new
                {
                    Id = table.Column<short>(type: "smallint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Descricao = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StatusPedido", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Pedido",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    NumeroPedido = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ClienteId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    DataPedido = table.Column<DateTime>(type: "datetime2", nullable: false),
                    StatusId = table.Column<short>(type: "smallint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pedido", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Pedido_Cliente_ClienteId",
                        column: x => x.ClienteId,
                        principalTable: "Cliente",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Pedido_StatusPedido_StatusId",
                        column: x => x.StatusId,
                        principalTable: "StatusPedido",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Pagamento",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PedidoId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CodigoQR = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    StatusId = table.Column<short>(type: "smallint", nullable: false),
                    ValorPedido = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false),
                    Desconto = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false),
                    ValorTotal = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false),
                    ValorPago = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pagamento", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Pagamento_Pedido_PedidoId",
                        column: x => x.PedidoId,
                        principalTable: "Pedido",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Pagamento_StatusPagamento_StatusId",
                        column: x => x.StatusId,
                        principalTable: "StatusPagamento",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PedidoCheckout",
                columns: table => new
                {
                    PedidoId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Sequencia = table.Column<int>(type: "int", nullable: false),
                    StatusId = table.Column<short>(type: "smallint", nullable: false),
                    DataStatus = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PedidoCheckout", x => new { x.PedidoId, x.Sequencia });
                    table.ForeignKey(
                        name: "FK_PedidoCheckout_Pedido_PedidoId",
                        column: x => x.PedidoId,
                        principalTable: "Pedido",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PedidoCheckout_StatusPedido_StatusId",
                        column: x => x.StatusId,
                        principalTable: "StatusPedido",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "PedidoItem",
                columns: table => new
                {
                    PedidoId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ItemPedidoId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ValorUnitario = table.Column<decimal>(type: "decimal(6,2)", precision: 6, scale: 2, nullable: false),
                    Quantidade = table.Column<int>(type: "int", nullable: false),
                    Observacao = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PedidoItem", x => new { x.PedidoId, x.ItemPedidoId });
                    table.ForeignKey(
                        name: "FK_PedidoItem_Pedido_PedidoId",
                        column: x => x.PedidoId,
                        principalTable: "Pedido",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PedidoItem_Produto_ItemPedidoId",
                        column: x => x.ItemPedidoId,
                        principalTable: "Produto",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Cliente",
                columns: new[] { "Id", "Cpf", "Email", "Nome" },
                values: new object[] { new Guid("717b2fb9-4bbe-4a8c-8574-7808cd652e0b"), "12851671049", "joao.silva@gmail.com", "João da Silva Gomes" });

            migrationBuilder.InsertData(
                table: "Produto",
                columns: new[] { "Id", "Ativo", "Categoria", "Descricao", "Nome", "Preco" },
                values: new object[,]
                {
                    { new Guid("63c776f5-4539-478e-a17a-54d3a1c2d3ee"), true, 0, "Pão, carne, alface, tomate e maionese ESPECIAL", "Burger Four", 5.5m },
                    { new Guid("7686debb-92c2-4d89-a669-8988da8e8c72"), true, 0, "Pão, carne, queijo, alface, tomate e maionese ESPECIAL", "Burguer Six", 7.5m },
                    { new Guid("947e3d62-26fa-4ba6-8395-39c259fc43ec"), true, 0, "Pão, carne, queijo, ovo, bacon, alface, tomate e maionese ESPECIAL", "Burguer FourSix", 10m },
                    { new Guid("9482fcf0-e9e4-4bdc-869f-ad7d1d15016c"), true, 3, "Coca-cola 600ml", "Coca-cola", 8.25m },
                    { new Guid("a0d0225e-0f3c-42ff-935d-beb44bb2cac4"), true, 3, "H2O 500ml", "H2O", 8.25m },
                    { new Guid("a45a3af2-17db-459f-867a-b0c2e1261dc0"), true, 3, "Suco Natural de Laranja 500ml", "Suco Natural de Laranja", 10m },
                    { new Guid("c2a49da0-6bc2-4cdc-be77-97d0284b8c92"), true, 1, "Batata Frita especial", "Batata Frita", 6.50m },
                    { new Guid("c55a9ca7-411d-4245-8b91-1efbc30f7a9b"), true, 1, "Cebola empanada especial", "Onion", 8.25m },
                    { new Guid("d23c72b6-0bbe-4e0d-a46e-b8d72da5e9ef"), true, 2, "Casquinha de sorvete de baunilha", "Sorvete de Baunilha", 1.25m },
                    { new Guid("ea5df339-afd7-41b6-a4ab-44979c1d919d"), true, 2, "Bolo de chocolate com recheio de creme de morango", "Bolo Sensação", 3.25m }
                });

            migrationBuilder.InsertData(
                table: "StatusPagamento",
                columns: new[] { "Id", "Descricao" },
                values: new object[,]
                {
                    { (short)1, "Aguardando Pagamento" },
                    { (short)2, "Pago" },
                    { (short)3, "Cancelado" }
                });

            migrationBuilder.InsertData(
                table: "StatusPedido",
                columns: new[] { "Id", "Descricao" },
                values: new object[,]
                {
                    { (short)1, "Recebido" },
                    { (short)2, "Pago" },
                    { (short)3, "Em Preparação" },
                    { (short)4, "Montagem" },
                    { (short)5, "Pronto" },
                    { (short)6, "Finalizado" }
                });

            migrationBuilder.InsertData(
                table: "Pedido",
                columns: new[] { "Id", "ClienteId", "DataPedido", "NumeroPedido", "StatusId" },
                values: new object[] { new Guid("78e3b8d0-be9a-4407-9304-c61788797808"), new Guid("717b2fb9-4bbe-4a8c-8574-7808cd652e0b"), new DateTime(2023, 10, 30, 19, 26, 39, 762, DateTimeKind.Local).AddTicks(4023), 1, (short)1 });

            migrationBuilder.InsertData(
                table: "PedidoCheckout",
                columns: new[] { "PedidoId", "Sequencia", "DataStatus", "StatusId" },
                values: new object[] { new Guid("78e3b8d0-be9a-4407-9304-c61788797808"), 0, new DateTime(2023, 10, 30, 19, 26, 39, 762, DateTimeKind.Local).AddTicks(4023), (short)1 });

            migrationBuilder.InsertData(
                table: "PedidoItem",
                columns: new[] { "ItemPedidoId", "PedidoId", "Observacao", "Quantidade", "ValorUnitario" },
                values: new object[,]
                {
                    { new Guid("63c776f5-4539-478e-a17a-54d3a1c2d3ee"), new Guid("78e3b8d0-be9a-4407-9304-c61788797808"), "Sem tomate", 2, 5.5m },
                    { new Guid("9482fcf0-e9e4-4bdc-869f-ad7d1d15016c"), new Guid("78e3b8d0-be9a-4407-9304-c61788797808"), null, 1, 8.25m }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Pagamento_PedidoId",
                table: "Pagamento",
                column: "PedidoId");

            migrationBuilder.CreateIndex(
                name: "IX_Pagamento_StatusId",
                table: "Pagamento",
                column: "StatusId");

            migrationBuilder.CreateIndex(
                name: "IX_Pedido_ClienteId",
                table: "Pedido",
                column: "ClienteId");

            migrationBuilder.CreateIndex(
                name: "IX_Pedido_StatusId",
                table: "Pedido",
                column: "StatusId");

            migrationBuilder.CreateIndex(
                name: "IX_PedidoCheckout_StatusId",
                table: "PedidoCheckout",
                column: "StatusId");

            migrationBuilder.CreateIndex(
                name: "IX_PedidoItem_ItemPedidoId",
                table: "PedidoItem",
                column: "ItemPedidoId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Pagamento");

            migrationBuilder.DropTable(
                name: "PedidoCheckout");

            migrationBuilder.DropTable(
                name: "PedidoItem");

            migrationBuilder.DropTable(
                name: "StatusPagamento");

            migrationBuilder.DropTable(
                name: "Pedido");

            migrationBuilder.DropTable(
                name: "Produto");

            migrationBuilder.DropTable(
                name: "Cliente");

            migrationBuilder.DropTable(
                name: "StatusPedido");
        }
    }
}
