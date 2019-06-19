using Microsoft.EntityFrameworkCore.Migrations;

namespace Ceresis.Repository.Migrations
{
    public partial class AddImageUrlToSplit : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ImageUrl",
                schema: "public",
                table: "split_houses",
                nullable: true);

            migrationBuilder.UpdateData(
                schema: "public",
                table: "roles",
                keyColumn: "Id",
                keyValue: 1,
                column: "ConcurrencyStamp",
                value: "00b23b00-a3fe-4509-adab-c6cbf5f6153e");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ImageUrl",
                schema: "public",
                table: "split_houses");

            migrationBuilder.UpdateData(
                schema: "public",
                table: "roles",
                keyColumn: "Id",
                keyValue: 1,
                column: "ConcurrencyStamp",
                value: "1b2c0bb6-07e9-4589-ac38-d07093fc95cf");
        }
    }
}
