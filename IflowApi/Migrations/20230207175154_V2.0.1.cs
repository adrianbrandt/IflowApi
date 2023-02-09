using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace IflowApi.Migrations
{
    /// <inheritdoc />
    public partial class V201 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Ansatte",
                table: "Ansatte");

            migrationBuilder.RenameTable(
                name: "Ansatte",
                newName: "Ansatt");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Ansatt",
                table: "Ansatt",
                column: "id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Ansatt",
                table: "Ansatt");

            migrationBuilder.RenameTable(
                name: "Ansatt",
                newName: "Ansatte");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Ansatte",
                table: "Ansatte",
                column: "id");
        }
    }
}
