using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace Ceresis.Repository.Migrations
{
    public partial class AddSplitHouse : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "split_houses",
                schema: "public",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    Model = table.Column<string>(nullable: true),
                    Power = table.Column<string>(nullable: true),
                    PowerRealty = table.Column<string>(nullable: true),
                    EnergoEfficienty = table.Column<string>(nullable: true),
                    Noise = table.Column<double>(nullable: false),
                    SizeExternal = table.Column<string>(nullable: true),
                    SizeInternal = table.Column<string>(nullable: true),
                    Price = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_split_houses", x => x.Id);
                });

            migrationBuilder.UpdateData(
                schema: "public",
                table: "roles",
                keyColumn: "Id",
                keyValue: 1,
                column: "ConcurrencyStamp",
                value: "1b2c0bb6-07e9-4589-ac38-d07093fc95cf");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "split_houses",
                schema: "public");

            migrationBuilder.UpdateData(
                schema: "public",
                table: "roles",
                keyColumn: "Id",
                keyValue: 1,
                column: "ConcurrencyStamp",
                value: "a5763258-29aa-421f-bd3b-1e6e19f902c0");
        }
    }
}
