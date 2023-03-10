using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ReadHubWeb.Data.Migrations
{
    public partial class createNew : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "bcb4f072-ecca-43c9-ab26-c060c6f364e4",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "dea948d7-fa3d-49ec-9f57-b74469313aae", "AQAAAAEAACcQAAAAEMdXuX2rhD2u7wHPKQQPLjfeWYtvAL0N4n11SmtOmWYL820aXOSaXnKwwwR9y6Uddg==", "24df49a4-00b0-4422-8eb3-b23bdd16e030" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "bcb4f072-ecca-43c9-ab26-c060c6f364e4",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "d6be869b-74de-48f1-b597-98de11388b9c", "AQAAAAEAACcQAAAAEOSWsMwwkgmVZn4CjVJBoZmFrEAiobHHv10/VeMwoMKGLyS9zF77jXRxA/jayd+zmg==", "ee37b372-521f-49b5-b88b-6b77340c8035" });
        }
    }
}
