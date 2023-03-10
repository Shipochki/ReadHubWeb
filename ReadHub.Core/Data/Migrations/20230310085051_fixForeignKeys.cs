using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ReadHubWeb.Data.Migrations
{
    public partial class fixForeignKeys : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "bcb4f072-ecca-43c9-ab26-c060c6f364e4",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "ac4a8f37-0572-46df-a74f-58f30afd6d94", "AQAAAAEAACcQAAAAEFbOZsU6WREQdNdINQvaD5KGhQ9gQLv2nrahukgFHyoG1aJK8aUNmsZ+X+dSZmHKQQ==", "e700bee5-b461-43fc-aee9-c608c53ce529" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "bcb4f072-ecca-43c9-ab26-c060c6f364e4",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "4adba5f2-e9c1-4a47-ae92-8c0464cab815", "AQAAAAEAACcQAAAAEEVkfjKUpnZXAlHyhpo9XadryUJ7ksSKo1jJWk+OdJthuBk6McNEHoSbd/NYiQbRqA==", "f85b9565-03bb-476a-9774-d25e874e4c32" });
        }
    }
}
