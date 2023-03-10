using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ReadHubWeb.Data.Migrations
{
    public partial class addKeys : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "bcb4f072-ecca-43c9-ab26-c060c6f364e4",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "534e0e7d-c932-46c2-8b19-18404eaebb85", "AQAAAAEAACcQAAAAEJQu+IRJ1djZVWbU/vhbWP+53n9hDWJpA5skOoMcRBw6ij4DAMTQtHd4IdMVDKOP6Q==", "e2c9aaf6-dcc2-4650-b9e8-1c486bcf25bd" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "bcb4f072-ecca-43c9-ab26-c060c6f364e4",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "dc76c68a-2e0a-4b47-9acc-da11073fc483", "AQAAAAEAACcQAAAAENWyzqD9yAxShXE4l7dQc7HjVOLWDftNz44PrP9dL4w41jMZ3u+3cJuAXbyXnV6QJQ==", "76fce687-f0a5-4e95-a75f-305588ececf1" });
        }
    }
}
