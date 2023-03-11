using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ReadHubWeb.Data.Migrations
{
    public partial class OrderIdInBook : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Books_Orders_OrderId",
                table: "Books");

            migrationBuilder.RenameColumn(
                name: "OrderId",
                table: "Books",
                newName: "OrderIrd");

            migrationBuilder.RenameIndex(
                name: "IX_Books_OrderId",
                table: "Books",
                newName: "IX_Books_OrderIrd");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "bcb4f072-ecca-43c9-ab26-c060c6f364e4",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "77ec0d50-1a4d-46b0-8abc-7a3b42b79048", "AQAAAAEAACcQAAAAECIA9eKp9NyYBGjjO+aN2t0lJjCu1/Ud6sILHgO38lSkdZXOCMOtWYh8p8YmugxJtQ==", "52b2d117-0000-497c-93ae-0b9dc7a71e20" });

            migrationBuilder.AddForeignKey(
                name: "FK_Books_Orders_OrderIrd",
                table: "Books",
                column: "OrderIrd",
                principalTable: "Orders",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Books_Orders_OrderIrd",
                table: "Books");

            migrationBuilder.RenameColumn(
                name: "OrderIrd",
                table: "Books",
                newName: "OrderId");

            migrationBuilder.RenameIndex(
                name: "IX_Books_OrderIrd",
                table: "Books",
                newName: "IX_Books_OrderId");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "bcb4f072-ecca-43c9-ab26-c060c6f364e4",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "9b2fc615-eaa2-4826-bf8a-ffb7403b1246", "AQAAAAEAACcQAAAAEB4eFkrpi7vBl69UXMsKD3+vxM+5lfF4PJ2emzn447g0eV3+VkGg5zLrPK0IFt3adQ==", "b9fbfe8c-379c-4cda-91a9-dccda8b3bd94" });

            migrationBuilder.AddForeignKey(
                name: "FK_Books_Orders_OrderId",
                table: "Books",
                column: "OrderId",
                principalTable: "Orders",
                principalColumn: "Id");
        }
    }
}
