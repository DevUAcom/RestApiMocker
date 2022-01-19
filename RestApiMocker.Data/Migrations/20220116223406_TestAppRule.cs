using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RestApiMocker.Data.Migrations
{
    public partial class TestAppRule : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ResponseHeaders_AppRule_AppRuleId",
                table: "ResponseHeaders");

            migrationBuilder.AlterColumn<int>(
                name: "AppRuleId",
                table: "ResponseHeaders",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Path",
                table: "AppRule",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100);

            migrationBuilder.AlterColumn<string>(
                name: "Method",
                table: "AppRule",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(10)",
                oldMaxLength: 10);

            migrationBuilder.AddForeignKey(
                name: "FK_ResponseHeaders_AppRule_AppRuleId",
                table: "ResponseHeaders",
                column: "AppRuleId",
                principalTable: "AppRule",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ResponseHeaders_AppRule_AppRuleId",
                table: "ResponseHeaders");

            migrationBuilder.AlterColumn<int>(
                name: "AppRuleId",
                table: "ResponseHeaders",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<string>(
                name: "Path",
                table: "AppRule",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Method",
                table: "AppRule",
                type: "nvarchar(10)",
                maxLength: 10,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_ResponseHeaders_AppRule_AppRuleId",
                table: "ResponseHeaders",
                column: "AppRuleId",
                principalTable: "AppRule",
                principalColumn: "Id");
        }
    }
}
