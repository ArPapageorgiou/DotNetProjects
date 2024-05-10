using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class rentedAtnewDefault : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "RentedAt",
                table: "RentalTransactions",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 5, 11, 2, 10, 50, 240, DateTimeKind.Local).AddTicks(1631),
                oldClrType: typeof(DateTime),
                oldType: "datetime2");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "RentedAt",
                table: "RentalTransactions",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 5, 11, 2, 10, 50, 240, DateTimeKind.Local).AddTicks(1631));
        }
    }
}
