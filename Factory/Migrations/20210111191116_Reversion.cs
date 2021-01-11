using Microsoft.EntityFrameworkCore.Migrations;

namespace Factory.Migrations
{
    public partial class Reversion : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "MachineOnlineStatus",
                table: "Machines");

            migrationBuilder.DropColumn(
                name: "EngineerWorkStatus",
                table: "Engineers");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "MachineOnlineStatus",
                table: "Machines",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "EngineerWorkStatus",
                table: "Engineers",
                nullable: true);
        }
    }
}
