using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace IflowApi.Migrations
{
    /// <inheritdoc />
    public partial class V206 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Ansatte");

            migrationBuilder.RenameColumn(
                name: "user",
                table: "Maskiner",
                newName: "Bruker");

            migrationBuilder.CreateTable(
                name: "Brukere",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Brukere", x => x.id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Brukere");

            migrationBuilder.RenameColumn(
                name: "Bruker",
                table: "Maskiner",
                newName: "user");

            migrationBuilder.CreateTable(
                name: "Ansatte",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ansatte", x => x.id);
                });
        }
    }
}
