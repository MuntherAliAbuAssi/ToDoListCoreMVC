using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ToDoList.Web.Data.Migrations
{
    public partial class updated_Todo3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsComplete",
                table: "ToDoLists");

            migrationBuilder.AddColumn<int>(
                name: "InProgress",
                table: "ToDoLists",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "InProgress",
                table: "ToDoLists");

            migrationBuilder.AddColumn<bool>(
                name: "IsComplete",
                table: "ToDoLists",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }
    }
}
