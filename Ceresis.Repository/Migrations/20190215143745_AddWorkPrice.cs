using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace Ceresis.Repository.Migrations
{
    public partial class AddWorkPrice : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "work_prices",
                schema: "public",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    Name = table.Column<string>(nullable: true),
                    Unity = table.Column<string>(nullable: true),
                    ExactPrice = table.Column<bool>(nullable: false),
                    ContactPrice = table.Column<bool>(nullable: false),
                    Price = table.Column<double>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_work_prices", x => x.Id);
                });

            migrationBuilder.UpdateData(
                schema: "public",
                table: "roles",
                keyColumn: "Id",
                keyValue: 1,
                column: "ConcurrencyStamp",
                value: "a29b5f32-5895-4899-a42a-ab092c71c64f");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "work_prices",
                schema: "public");

            migrationBuilder.UpdateData(
                schema: "public",
                table: "roles",
                keyColumn: "Id",
                keyValue: 1,
                column: "ConcurrencyStamp",
                value: "bc15fc0c-f62e-4538-ba22-cea88185232b");
        }
    }
}
