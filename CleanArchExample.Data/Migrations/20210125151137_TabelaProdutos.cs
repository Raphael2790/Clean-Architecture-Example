using Microsoft.EntityFrameworkCore.Migrations;

namespace CleanArchExample.Data.Migrations
{
    public partial class TabelaProdutos : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Produtos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Price = table.Column<decimal>(type: "decimal(10,2)", precision: 10, scale: 2, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Produtos", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Produtos",
                columns: new[] { "Id", "Description", "Nome", "Price" },
                values: new object[] { 3, "Uma ótima para de pressão", "Panela", 80.20m });

            migrationBuilder.InsertData(
                table: "Produtos",
                columns: new[] { "Id", "Description", "Nome", "Price" },
                values: new object[] { 1, "Um confortável sofá para você e sua família", "Sofá", 800.80m });

            migrationBuilder.InsertData(
                table: "Produtos",
                columns: new[] { "Id", "Description", "Nome", "Price" },
                values: new object[] { 2, "Um confortável cama com eláticos e molas", "Cama Casal", 1400.50m });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Produtos");
        }
    }
}
