using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Task1_api.Migrations
{
    public partial class AddDandT : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "task_status",
                table: "todo",
                nullable: true,
                oldClrType: typeof(bool));

            migrationBuilder.AddColumn<DateTime>(
                name: "DandT",
                table: "todo",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DandT",
                table: "todo");

            migrationBuilder.AlterColumn<bool>(
                name: "task_status",
                table: "todo",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);
        }
    }
}
