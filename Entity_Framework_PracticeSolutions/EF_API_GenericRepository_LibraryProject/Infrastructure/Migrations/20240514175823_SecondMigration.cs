using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class SecondMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "ReturnedAt",
                table: "transactions",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AlterColumn<DateTime>(
                name: "RentedAt",
                table: "transactions",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 5, 14, 20, 58, 23, 336, DateTimeKind.Local).AddTicks(4599),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 5, 14, 20, 51, 7, 140, DateTimeKind.Local).AddTicks(4923));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "ReturnedAt",
                table: "transactions",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "RentedAt",
                table: "transactions",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 5, 14, 20, 51, 7, 140, DateTimeKind.Local).AddTicks(4923),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 5, 14, 20, 58, 23, 336, DateTimeKind.Local).AddTicks(4599));
        }
    }
}
