using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RestApiMocker.Data.Migrations
{
    public partial class ResponseHeader : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ResponseHeaders",
                table: "AppRule");

            migrationBuilder.CreateTable(
                name: "ResponseHeader",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ResponseHeader");

            migrationBuilder.AddColumn<string>(
                name: "ResponseHeaders",
                table: "AppRule",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
