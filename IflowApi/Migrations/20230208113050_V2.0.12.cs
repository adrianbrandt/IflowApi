using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace IflowApi.Migrations
{
    /// <inheritdoc />
    public partial class V2012 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Bruker",
                table: "Maskiner",
                newName: "bruker");

            migrationBuilder.AddColumn<string>(
                name: "passord",
                table: "Brukere",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "passord",
                table: "Brukere");

            migrationBuilder.RenameColumn(
                name: "bruker",
                table: "Maskiner",
                newName: "Bruker");
        }
    }
}
