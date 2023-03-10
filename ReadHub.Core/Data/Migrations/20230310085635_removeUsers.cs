using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ReadHubWeb.Data.Migrations
{
    public partial class removeUsers : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "bcb4f072-ecca-43c9-ab26-c060c6f364e4",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "d6be869b-74de-48f1-b597-98de11388b9c", "AQAAAAEAACcQAAAAEOSWsMwwkgmVZn4CjVJBoZmFrEAiobHHv10/VeMwoMKGLyS9zF77jXRxA/jayd+zmg==", "ee37b372-521f-49b5-b88b-6b77340c8035" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "bcb4f072-ecca-43c9-ab26-c060c6f364e4",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "ac4a8f37-0572-46df-a74f-58f30afd6d94", "AQAAAAEAACcQAAAAEFbOZsU6WREQdNdINQvaD5KGhQ9gQLv2nrahukgFHyoG1aJK8aUNmsZ+X+dSZmHKQQ==", "e700bee5-b461-43fc-aee9-c608c53ce529" });
        }
    }
}
