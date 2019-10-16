using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Task1_api.Migrations
{
    public partial class UpdateMigration1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "creation_time",
                table: "tasks",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "deletion_time",
                table: "tasks",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "updation_time",
                table: "tasks",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "creation_time",
                table: "tasks");

            migrationBuilder.DropColumn(
                name: "deletion_time",
                table: "tasks");

            migrationBuilder.DropColumn(
                name: "updation_time",
                table: "tasks");
        }
    }
}
