using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ReadHubWeb.Data.Migrations
{
    public partial class removeSomeProps : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "bcb4f072-ecca-43c9-ab26-c060c6f364e4",
                columns: new[] { "ConcurrencyStamp", "CreatedTime", "PasswordHash", "SecurityStamp" },
                values: new object[] { "75b039da-323c-419a-8ce0-d09b0add3fd0", new DateTime(2023, 3, 9, 18, 23, 41, 204, DateTimeKind.Local).AddTicks(2528), "AQAAAAEAACcQAAAAEHN/hATqXkZLzQB6gCXoO9lNT09ITmn62Aw1/S8E+B6EJNEak+NDxGmKSs9+taHEog==", "aca240eb-2d64-4652-a544-d13de8c975a8" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "bcb4f072-ecca-43c9-ab26-c060c6f364e4",
                columns: new[] { "ConcurrencyStamp", "CreatedTime", "PasswordHash", "SecurityStamp" },
                values: new object[] { "1e5042d0-ba1d-400e-803f-8ac576e0f7c3", new DateTime(2023, 3, 8, 17, 12, 26, 401, DateTimeKind.Local).AddTicks(7304), "AQAAAAEAACcQAAAAEOyl/49FeWpUAnNSakbic9O2NIfy9kfEgX8+zRCxjnJfRCiwQJkQpYRcTBMgpBy5hw==", "689e005a-64de-47ef-8b5b-aabb5252ac74" });
        }
    }
}
