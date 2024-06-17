using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class NewNavPropertyForData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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
                name: "FK_Data_WeatherData_WeatherDataId1",
                table: "Data",
                column: "WeatherDataId1",
                principalTable: "WeatherData",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Data_WeatherData_WeatherDataId1",
                table: "Data");

            migrationBuilder.DropIndex(
                name: "IX_Data_WeatherDataId1",
                table: "Data");

            migrationBuilder.DropColumn(
                name: "WeatherDataId1",
                table: "Data");
        }
    }
}
