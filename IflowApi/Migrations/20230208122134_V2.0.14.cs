using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace IflowApi.Migrations
{
    /// <inheritdoc />
    public partial class V2014 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "userId",
                table: "Brukere");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "userId",
                table: "Brukere",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
