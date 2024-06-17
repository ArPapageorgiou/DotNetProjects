using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Weather",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Icon = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Code = table.Column<int>(type: "int", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Weather", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "WeatherData",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Count = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WeatherData", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Data",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    WindCdir = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Rh = table.Column<float>(type: "real", nullable: false),
                    Pod = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Lon = table.Column<double>(type: "float", nullable: false),
                    Pres = table.Column<double>(type: "float", nullable: false),
                    Timezone = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ObTime = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CountryCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Clouds = table.Column<float>(type: "real", nullable: false),
                    Vis = table.Column<float>(type: "real", nullable: false),
                    WindSpd = table.Column<double>(type: "float", nullable: false),
                    Gust = table.Column<double>(type: "float", nullable: false),
                    WindCdirFull = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AppTemp = table.Column<double>(type: "float", nullable: false),
                    StateCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Ts = table.Column<long>(type: "bigint", nullable: false),
                    HAngle = table.Column<float>(type: "real", nullable: false),
                    Dewpt = table.Column<double>(type: "float", nullable: false),
                    Uv = table.Column<float>(type: "real", nullable: false),
                    Aqi = table.Column<float>(type: "real", nullable: false),
                    Station = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Sources = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    WindDir = table.Column<float>(type: "real", nullable: false),
                    ElevAngle = table.Column<double>(type: "float", nullable: false),
                    Datetime = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Precip = table.Column<double>(type: "float", nullable: false),
                    Ghi = table.Column<double>(type: "float", nullable: false),
                    Dni = table.Column<double>(type: "float", nullable: false),
                    Dhi = table.Column<double>(type: "float", nullable: false),
                    SolarRad = table.Column<double>(type: "float", nullable: false),
                    CityName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Sunrise = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Sunset = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Temp = table.Column<double>(type: "float", nullable: false),
                    Lat = table.Column<double>(type: "float", nullable: false),
                    Slp = table.Column<double>(type: "float", nullable: false),
                    WeatherDataId = table.Column<int>(type: "int", nullable: false),
                    WeatherId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Data", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Data_WeatherData_WeatherDataId",
                        column: x => x.WeatherDataId,
                        principalTable: "WeatherData",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Data_Weather_WeatherId",
                        column: x => x.WeatherId,
                        principalTable: "Weather",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Data_WeatherDataId",
                table: "Data",
                column: "WeatherDataId");

            migrationBuilder.CreateIndex(
                name: "IX_Data_WeatherId",
                table: "Data",
                column: "WeatherId",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Data");

            migrationBuilder.DropTable(
                name: "WeatherData");

            migrationBuilder.DropTable(
                name: "Weather");
        }
    }
}
