using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RestApiMocker.Data.Migrations
{
    public partial class ResponseHeaderRelationship : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameTable(
                name: "ResponseHeader",
                newName: "ResponseHeaders");

            migrationBuilder.AddColumn<int>(
                name: "ResponseHeadersId",
                table: "AppRule",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<string>(
                name: "Id",
                table: "ResponseHeaders",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "AppRuleId",
                table: "ResponseHeaders",
                type: "int",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_ResponseHeaders",
                table: "ResponseHeaders",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_ResponseHeaders_AppRuleId",
                table: "ResponseHeaders",
                column: "AppRuleId");

            migrationBuilder.AddForeignKey(
                name: "FK_ResponseHeaders_AppRule_AppRuleId",
                table: "ResponseHeaders",
                column: "AppRuleId",
                principalTable: "AppRule",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ResponseHeaders_AppRule_AppRuleId",
                table: "ResponseHeaders");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ResponseHeaders",
                table: "ResponseHeaders");

            migrationBuilder.DropIndex(
                name: "IX_ResponseHeaders_AppRuleId",
                table: "ResponseHeaders");

            migrationBuilder.DropColumn(
                name: "ResponseHeadersId",
                table: "AppRule");

            migrationBuilder.DropColumn(
                name: "AppRuleId",
                table: "ResponseHeaders");

            migrationBuilder.RenameTable(
                name: "ResponseHeaders",
                newName: "ResponseHeader");

            migrationBuilder.AlterColumn<string>(
                name: "Id",
                table: "ResponseHeader",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");
        }
    }
}
