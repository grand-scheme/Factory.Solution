using Microsoft.EntityFrameworkCore.Migrations;

namespace Factory.Migrations
{
    public partial class Descriptions : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "MachineDescription",
                table: "Machines",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "EngineerDescription",
                table: "Engineers",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "MachineDescription",
                table: "Machines");

            migrationBuilder.DropColumn(
                name: "EngineerDescription",
                table: "Engineers");
        }
    }
}
