using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class ChangePropertyName : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Data_WeatherData_WeatherDataId",
                table: "Data");

            migrationBuilder.DropForeignKey(
                name: "FK_Data_WeatherData_WeatherDataId1",
                table: "Data");

            migrationBuilder.DropIndex(
                name: "IX_Data_WeatherDataId1",
                table: "Data");

            migrationBuilder.DropColumn(
                name: "WeatherDataId1",
                table: "Data");

            migrationBuilder.RenameColumn(
                name: "WeatherDataId",
                table: "Data",
                newName: "WeatherDataForeignKey");

            migrationBuilder.RenameIndex(
                name: "IX_Data_WeatherDataId",
                table: "Data",
                newName: "IX_Data_WeatherDataForeignKey");

            migrationBuilder.AddForeignKey(
                name: "FK_Data_WeatherData_WeatherDataForeignKey",
                table: "Data",
                column: "WeatherDataForeignKey",
                principalTable: "WeatherData",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Data_WeatherData_WeatherDataForeignKey",
                table: "Data");

            migrationBuilder.RenameColumn(
                name: "WeatherDataForeignKey",
                table: "Data",
                newName: "WeatherDataId");

            migrationBuilder.RenameIndex(
                name: "IX_Data_WeatherDataForeignKey",
                table: "Data",
                newName: "IX_Data_WeatherDataId");

            migrationBuilder.AddColumn<int>(
                name: "WeatherDataId1",
                table: "Data",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Data_WeatherDataId1",
                table: "Data",
                column: "WeatherDataId1");

            migrationBuilder.AddForeignKey(
                name: "FK_Data_WeatherData_WeatherDataId",
                table: "Data",
                column: "WeatherDataId",
                principalTable: "WeatherData",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Data_WeatherData_WeatherDataId1",
                table: "Data",
                column: "WeatherDataId1",
                principalTable: "WeatherData",
                principalColumn: "Id");
        }
    }
}
