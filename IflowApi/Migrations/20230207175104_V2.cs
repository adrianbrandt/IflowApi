using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace IflowApi.Migrations
{
    /// <inheritdoc />
    public partial class V2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Masiner",
                table: "Masiner");

            migrationBuilder.RenameTable(
                name: "Masiner",
                newName: "Maskin");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Maskin",
                table: "Maskin",
                column: "id");

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Ansatte");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Maskin",
                table: "Maskin");

            migrationBuilder.RenameTable(
                name: "Maskin",
                newName: "Masiner");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Masiner",
                table: "Masiner",
                column: "id");
        }
    }
}
