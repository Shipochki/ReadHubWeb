using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ReadHubWeb.Data.Migrations
{
    public partial class removeUser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Books_AspNetUsers_UserId",
                table: "Books");

            migrationBuilder.DropForeignKey(
                name: "FK_Books_AspNetUsers_UserId1",
                table: "Books");

            migrationBuilder.DropForeignKey(
                name: "FK_Books_AspNetUsers_UserId2",
                table: "Books");

            migrationBuilder.DropIndex(
                name: "IX_Books_UserId",
                table: "Books");

            migrationBuilder.DropIndex(
                name: "IX_Books_UserId1",
                table: "Books");

            migrationBuilder.DropIndex(
                name: "IX_Books_UserId2",
                table: "Books");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Books");

            migrationBuilder.DropColumn(
                name: "UserId1",
                table: "Books");

            migrationBuilder.DropColumn(
                name: "UserId2",
                table: "Books");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "bcb4f072-ecca-43c9-ab26-c060c6f364e4",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "3c2990d4-0345-471d-807e-5f4a1bae553f", "AQAAAAEAACcQAAAAEC59i0zmQc3abol6px/c/eW+Crc/AwGDU/91ltgSs8e1+jGY+5MAnW9NVbyZG7oC2w==", "fd8b005e-92ff-41da-b315-5c21d20e8220" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "UserId",
                table: "Books",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UserId1",
                table: "Books",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UserId2",
                table: "Books",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "bcb4f072-ecca-43c9-ab26-c060c6f364e4",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "dea948d7-fa3d-49ec-9f57-b74469313aae", "AQAAAAEAACcQAAAAEMdXuX2rhD2u7wHPKQQPLjfeWYtvAL0N4n11SmtOmWYL820aXOSaXnKwwwR9y6Uddg==", "24df49a4-00b0-4422-8eb3-b23bdd16e030" });

            migrationBuilder.CreateIndex(
                name: "IX_Books_UserId",
                table: "Books",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Books_UserId1",
                table: "Books",
                column: "UserId1");

            migrationBuilder.CreateIndex(
                name: "IX_Books_UserId2",
                table: "Books",
                column: "UserId2");

            migrationBuilder.AddForeignKey(
                name: "FK_Books_AspNetUsers_UserId",
                table: "Books",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Books_AspNetUsers_UserId1",
                table: "Books",
                column: "UserId1",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Books_AspNetUsers_UserId2",
                table: "Books",
                column: "UserId2",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }
    }
}
