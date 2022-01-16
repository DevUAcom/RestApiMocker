using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RestApiMocker.Data.Migrations
{
    public partial class ResponseHeaderRelationship2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ResponseHeadersId",
                table: "AppRule");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ResponseHeadersId",
                table: "AppRule",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
