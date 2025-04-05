using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace task_manager.Migrations
{
    /// <inheritdoc />
    public partial class TaskTableUpdate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "Completo",
                table: "Tasks",
                type: "INTEGER",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Completo",
                table: "Tasks");
        }
    }
}
