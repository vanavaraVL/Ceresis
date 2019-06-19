using Microsoft.EntityFrameworkCore.Migrations;

namespace Ceresis.Repository.Migrations
{
    public partial class Stringfornoise : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Noise",
                schema: "public",
                table: "split_houses",
                nullable: true,
                oldClrType: typeof(double));

            migrationBuilder.UpdateData(
                schema: "public",
                table: "roles",
                keyColumn: "Id",
                keyValue: 1,
                column: "ConcurrencyStamp",
                value: "759ecf80-4904-44b2-b413-f746436dbd90");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<double>(
                name: "Noise",
                schema: "public",
                table: "split_houses",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.UpdateData(
                schema: "public",
                table: "roles",
                keyColumn: "Id",
                keyValue: 1,
                column: "ConcurrencyStamp",
                value: "1f189579-4ace-45e4-a305-7ee82a2426e2");
        }
    }
}
