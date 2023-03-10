using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ReadHubWeb.Data.Migrations
{
    public partial class updateDescription : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Books",
                type: "nvarchar(1000)",
                maxLength: 1000,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "bcb4f072-ecca-43c9-ab26-c060c6f364e4",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "9b2fc615-eaa2-4826-bf8a-ffb7403b1246", "AQAAAAEAACcQAAAAEB4eFkrpi7vBl69UXMsKD3+vxM+5lfF4PJ2emzn447g0eV3+VkGg5zLrPK0IFt3adQ==", "b9fbfe8c-379c-4cda-91a9-dccda8b3bd94" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Books",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(1000)",
                oldMaxLength: 1000);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "bcb4f072-ecca-43c9-ab26-c060c6f364e4",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "3c2990d4-0345-471d-807e-5f4a1bae553f", "AQAAAAEAACcQAAAAEC59i0zmQc3abol6px/c/eW+Crc/AwGDU/91ltgSs8e1+jGY+5MAnW9NVbyZG7oC2w==", "fd8b005e-92ff-41da-b315-5c21d20e8220" });
        }
    }
}
