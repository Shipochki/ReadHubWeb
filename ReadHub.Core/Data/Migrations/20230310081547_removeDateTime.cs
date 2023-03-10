using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ReadHubWeb.Data.Migrations
{
    public partial class removeDateTime : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreatedTime",
                table: "Reviews");

            migrationBuilder.DropColumn(
                name: "DeletedTime",
                table: "Reviews");

            migrationBuilder.DropColumn(
                name: "UpdatedTime",
                table: "Reviews");

            migrationBuilder.DropColumn(
                name: "CreatedTime",
                table: "Publisher");

            migrationBuilder.DropColumn(
                name: "UpdatedTime",
                table: "Publisher");

            migrationBuilder.DropColumn(
                name: "CreatedTime",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "DeletedTime",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "CreatedTime",
                table: "Books");

            migrationBuilder.DropColumn(
                name: "DeletedTime",
                table: "Books");

            migrationBuilder.DropColumn(
                name: "UpdatedTime",
                table: "Books");

            migrationBuilder.DropColumn(
                name: "CreatedTime",
                table: "Authors");

            migrationBuilder.DropColumn(
                name: "UpdatedTime",
                table: "Authors");

            migrationBuilder.DropColumn(
                name: "CreatedTime",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "DeletedTime",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "UpdatedTime",
                table: "AspNetUsers");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "bcb4f072-ecca-43c9-ab26-c060c6f364e4",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "dc76c68a-2e0a-4b47-9acc-da11073fc483", "AQAAAAEAACcQAAAAENWyzqD9yAxShXE4l7dQc7HjVOLWDftNz44PrP9dL4w41jMZ3u+3cJuAXbyXnV6QJQ==", "76fce687-f0a5-4e95-a75f-305588ececf1" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedTime",
                table: "Reviews",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletedTime",
                table: "Reviews",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdatedTime",
                table: "Reviews",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedTime",
                table: "Publisher",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdatedTime",
                table: "Publisher",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedTime",
                table: "Orders",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletedTime",
                table: "Orders",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedTime",
                table: "Books",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletedTime",
                table: "Books",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdatedTime",
                table: "Books",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedTime",
                table: "Authors",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdatedTime",
                table: "Authors",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedTime",
                table: "AspNetUsers",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletedTime",
                table: "AspNetUsers",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdatedTime",
                table: "AspNetUsers",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "bcb4f072-ecca-43c9-ab26-c060c6f364e4",
                columns: new[] { "ConcurrencyStamp", "CreatedTime", "PasswordHash", "SecurityStamp" },
                values: new object[] { "49ac0ada-4802-48ac-b0f8-dcc461d337cb", new DateTime(2023, 3, 10, 10, 10, 19, 637, DateTimeKind.Local).AddTicks(3461), "AQAAAAEAACcQAAAAEEKg8W5zbTIe7xpN0jDVNigtlbI2+O38twwsCnsBjawrnMGB18+IhwE29uWP2jz3Tg==", "50688457-d115-415f-90db-f343b3bb422a" });
        }
    }
}
