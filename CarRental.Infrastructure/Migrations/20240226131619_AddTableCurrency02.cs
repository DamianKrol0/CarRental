using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CarRental.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddTableCurrency02 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Currencies",
                table: "Cars");

            migrationBuilder.AddColumn<string>(
                name: "CurrencyId",
                table: "Cars",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Currencies",
                columns: table => new
                {
                    CurrencyId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Code = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Currencies", x => x.CurrencyId);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Cars_CurrencyId",
                table: "Cars",
                column: "CurrencyId");

            migrationBuilder.AddForeignKey(
                name: "FK_Cars_Currencies_CurrencyId",
                table: "Cars",
                column: "CurrencyId",
                principalTable: "Currencies",
                principalColumn: "CurrencyId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cars_Currencies_CurrencyId",
                table: "Cars");

            migrationBuilder.DropTable(
                name: "Currencies");

            migrationBuilder.DropIndex(
                name: "IX_Cars_CurrencyId",
                table: "Cars");

            migrationBuilder.DropColumn(
                name: "CurrencyId",
                table: "Cars");

            migrationBuilder.AddColumn<string>(
                name: "Currencies",
                table: "Cars",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
