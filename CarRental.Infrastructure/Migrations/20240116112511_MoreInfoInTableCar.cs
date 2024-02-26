using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CarRental.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class MoreInfoInTableCar : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<decimal>(
                name: "Price",
                table: "Cars",
                type: "decimal(18,2)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<int>(
                name: "BoxCapacity",
                table: "Cars",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Brand",
                table: "Cars",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<decimal>(
                name: "Consumption",
                table: "Cars",
                type: "decimal(18,2)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Currencies",
                table: "Cars",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "Persons",
                table: "Cars",
                type: "int",
                nullable: true);
            migrationBuilder.AlterColumn<decimal>(
               name: "Price",
               table: "Cars",
               type: "decimal(5,2)",
               precision: 2,
               nullable: false,
               oldClrType: typeof(decimal),
               oldType: "decimal(18,2)");

            migrationBuilder.AlterColumn<decimal>(
                name: "Consumption",
                table: "Cars",
                type: "decimal(5,2)",
                precision: 1,
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)",
                oldNullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BoxCapacity",
                table: "Cars");

            migrationBuilder.DropColumn(
                name: "Brand",
                table: "Cars");

            migrationBuilder.DropColumn(
                name: "Consumption",
                table: "Cars");

            migrationBuilder.DropColumn(
                name: "Currencies",
                table: "Cars");

            migrationBuilder.DropColumn(
                name: "Persons",
                table: "Cars");

            migrationBuilder.AlterColumn<string>(
                name: "Price",
                table: "Cars",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)");
            migrationBuilder.AlterColumn<decimal>(
              name: "Price",
              table: "Cars",
              type: "decimal(18,2)",
              nullable: false,
              oldClrType: typeof(decimal),
              oldType: "decimal(5,2)",
              oldPrecision: 2);

            migrationBuilder.AlterColumn<decimal>(
                name: "Consumption",
                table: "Cars",
                type: "decimal(18,2)",
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "decimal(5,2)",
                oldPrecision: 1,
                oldNullable: true);
        }
    }
}
