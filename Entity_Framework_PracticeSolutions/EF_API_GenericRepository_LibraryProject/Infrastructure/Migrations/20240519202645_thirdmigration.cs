using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class thirdmigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "RentedAt",
                table: "transactions",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 5, 19, 23, 26, 44, 810, DateTimeKind.Local).AddTicks(8637),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 5, 14, 20, 58, 23, 336, DateTimeKind.Local).AddTicks(4599));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "RentedAt",
                table: "transactions",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 5, 14, 20, 58, 23, 336, DateTimeKind.Local).AddTicks(4599),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 5, 19, 23, 26, 44, 810, DateTimeKind.Local).AddTicks(8637));
        }
    }
}
