using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ReadHubWeb.Data.Migrations
{
    public partial class addAuthorAndPublisher : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "bcb4f072-ecca-43c9-ab26-c060c6f364e4",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "4adba5f2-e9c1-4a47-ae92-8c0464cab815", "AQAAAAEAACcQAAAAEEVkfjKUpnZXAlHyhpo9XadryUJ7ksSKo1jJWk+OdJthuBk6McNEHoSbd/NYiQbRqA==", "f85b9565-03bb-476a-9774-d25e874e4c32" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "bcb4f072-ecca-43c9-ab26-c060c6f364e4",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "534e0e7d-c932-46c2-8b19-18404eaebb85", "AQAAAAEAACcQAAAAEJQu+IRJ1djZVWbU/vhbWP+53n9hDWJpA5skOoMcRBw6ij4DAMTQtHd4IdMVDKOP6Q==", "e2c9aaf6-dcc2-4650-b9e8-1c486bcf25bd" });
        }
    }
}
