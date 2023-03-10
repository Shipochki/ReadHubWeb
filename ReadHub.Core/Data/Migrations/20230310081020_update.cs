using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ReadHubWeb.Data.Migrations
{
    public partial class update : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "bcb4f072-ecca-43c9-ab26-c060c6f364e4",
                columns: new[] { "ConcurrencyStamp", "CreatedTime", "PasswordHash", "SecurityStamp" },
                values: new object[] { "49ac0ada-4802-48ac-b0f8-dcc461d337cb", new DateTime(2023, 3, 10, 10, 10, 19, 637, DateTimeKind.Local).AddTicks(3461), "AQAAAAEAACcQAAAAEEKg8W5zbTIe7xpN0jDVNigtlbI2+O38twwsCnsBjawrnMGB18+IhwE29uWP2jz3Tg==", "50688457-d115-415f-90db-f343b3bb422a" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "bcb4f072-ecca-43c9-ab26-c060c6f364e4",
                columns: new[] { "ConcurrencyStamp", "CreatedTime", "PasswordHash", "SecurityStamp" },
                values: new object[] { "75b039da-323c-419a-8ce0-d09b0add3fd0", new DateTime(2023, 3, 9, 18, 23, 41, 204, DateTimeKind.Local).AddTicks(2528), "AQAAAAEAACcQAAAAEHN/hATqXkZLzQB6gCXoO9lNT09ITmn62Aw1/S8E+B6EJNEak+NDxGmKSs9+taHEog==", "aca240eb-2d64-4652-a544-d13de8c975a8" });
        }
    }
}
