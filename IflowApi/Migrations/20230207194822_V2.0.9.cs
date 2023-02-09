using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace IflowApi.Migrations
{
    /// <inheritdoc />
    public partial class V209 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Brukere");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "UserId",
                table: "Brukere",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
