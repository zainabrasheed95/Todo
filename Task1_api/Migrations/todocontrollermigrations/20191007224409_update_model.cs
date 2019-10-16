using Microsoft.EntityFrameworkCore.Migrations;

namespace Task1_api.Migrations
{
    public partial class update_model : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "task_status",
                table: "todo");

            migrationBuilder.AddColumn<bool>(
                name: "is_completed",
                table: "todo",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "is_deleted",
                table: "todo",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "is_completed",
                table: "todo");

            migrationBuilder.DropColumn(
                name: "is_deleted",
                table: "todo");

            migrationBuilder.AddColumn<string>(
                name: "task_status",
                table: "todo",
                nullable: true);
        }
    }
}
