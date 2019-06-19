using Microsoft.EntityFrameworkCore.Migrations;

namespace Ceresis.Repository.Migrations
{
    public partial class AddDefaultWork : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                schema: "public",
                table: "work_prices",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                schema: "public",
                table: "work_prices",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                schema: "public",
                table: "work_prices",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                schema: "public",
                table: "work_prices",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                schema: "public",
                table: "work_prices",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                schema: "public",
                table: "work_prices",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                schema: "public",
                table: "work_prices",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                schema: "public",
                table: "work_prices",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                schema: "public",
                table: "work_prices",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                schema: "public",
                table: "work_prices",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                schema: "public",
                table: "work_prices",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                schema: "public",
                table: "work_prices",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                schema: "public",
                table: "work_prices",
                keyColumn: "Id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                schema: "public",
                table: "work_prices",
                keyColumn: "Id",
                keyValue: 14);

            migrationBuilder.DeleteData(
                schema: "public",
                table: "work_prices",
                keyColumn: "Id",
                keyValue: 15);

            migrationBuilder.DeleteData(
                schema: "public",
                table: "work_prices",
                keyColumn: "Id",
                keyValue: 16);

            migrationBuilder.DeleteData(
                schema: "public",
                table: "work_prices",
                keyColumn: "Id",
                keyValue: 17);

            migrationBuilder.DeleteData(
                schema: "public",
                table: "work_prices",
                keyColumn: "Id",
                keyValue: 18);

            migrationBuilder.DeleteData(
                schema: "public",
                table: "work_prices",
                keyColumn: "Id",
                keyValue: 19);

            migrationBuilder.DeleteData(
                schema: "public",
                table: "work_prices",
                keyColumn: "Id",
                keyValue: 20);

            migrationBuilder.DeleteData(
                schema: "public",
                table: "work_prices",
                keyColumn: "Id",
                keyValue: 21);

            migrationBuilder.DeleteData(
                schema: "public",
                table: "work_prices",
                keyColumn: "Id",
                keyValue: 22);

            migrationBuilder.DeleteData(
                schema: "public",
                table: "work_prices",
                keyColumn: "Id",
                keyValue: 23);

            migrationBuilder.UpdateData(
                schema: "public",
                table: "roles",
                keyColumn: "Id",
                keyValue: 1,
                column: "ConcurrencyStamp",
                value: "1f189579-4ace-45e4-a305-7ee82a2426e2");

            migrationBuilder.InsertData(
                schema: "public",
                table: "work_prices",
                columns: new[] { "Id", "ContactPrice", "ExactPrice", "Name", "Price", "Unity" },
                values: new object[,]
                {
                    { -21, false, false, "Демонтаж настенной сплит-системы (модель 36) свыше 7.0КВт", 3000.0, "шт" },
                    { -20, false, false, "Демонтаж настенной сплит-системы (модель 24) до 7.0КВт", 2500.0, "шт" },
                    { -19, false, false, "Демонтаж настенной сплит-системы (модель 18) до 5.5КВт", 2000.0, "шт" },
                    { -18, false, false, "Демонтаж настенной сплит-системы (модель 12) до 3.5КВт", 1500.0, "шт" },
                    { -17, false, false, "Демонтаж настенной сплит-системы (модель 07, 09) до 2.8КВт", 1200.0, "шт" },
                    { -16, false, false, "Демонтаж оконного кондиционера", 1000.0, "шт" },
                    { -15, true, false, "Техническое обслуживание кассетных, канальных, напольно-потолочных, колонных и др. сплит-систем", null, "шт" },
                    { -14, false, false, "Техническое обслуживание настенной сплит-системы (модель 07, 09) свыше 7.0КВт", 3000.0, "шт" },
                    { -13, false, true, "Техническое обслуживание настенной сплит-системы (модель 24) до 7.0КВт", 2500.0, "шт" },
                    { -12, false, true, "Техническое обслуживание настенной сплит-системы (модель 18) до 5.5КВт", 2000.0, "шт" },
                    { -11, false, true, "Техническое обслуживание настенной сплит-системы (модель 12) до 3.5КВт", 1500.0, "шт" },
                    { -10, false, true, "Техническое обслуживание настенной сплит-системы (модель 07, 09) до 2.8КВт", 1200.0, "шт" },
                    { -9, false, false, "Техническое обслуживание оконного кондиционера", 1500.0, "шт" },
                    { -8, true, false, "Монтаж кассетных, канальных, напольно-потолочных, колонных и др. сплит-систем", null, "шт" },
                    { -7, false, false, "Монтаж мульти-сплит-системы с тремя внутреннеми блоками", 12000.0, "шт" },
                    { -6, false, false, "Монтаж мульти-сплит-системы с двумя внутреннеми блоками", 8000.0, "шт" },
                    { -5, false, false, "Монтаж настенной сплит-системы (модель 36) свыше 7.0КВт", 7000.0, "шт" },
                    { -4, false, false, "Монтаж настенной сплит-системы (модель 24) до 7.0КВт", 6000.0, "шт" },
                    { -3, false, false, "Монтаж настенной сплит-системы (модель 18) до 5.5КВт", 5500.0, "шт" },
                    { -2, false, false, "Монтаж настенной сплит-системы (модель 12) до 3.5КВт", 4500.0, "шт" },
                    { -1, false, false, "Монтаж настенной сплит-системы (модель 07, 09) до 2.8КВт", 4000.0, "шт" },
                    { -22, false, false, "Диагностика неисправности сплит-системы", 700.0, "шт" },
                    { -23, false, true, "Дополнительная межблочная коммуникация (для систем 07 и 09)", 500.0, "м" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                schema: "public",
                table: "work_prices",
                keyColumn: "Id",
                keyValue: -23);

            migrationBuilder.DeleteData(
                schema: "public",
                table: "work_prices",
                keyColumn: "Id",
                keyValue: -22);

            migrationBuilder.DeleteData(
                schema: "public",
                table: "work_prices",
                keyColumn: "Id",
                keyValue: -21);

            migrationBuilder.DeleteData(
                schema: "public",
                table: "work_prices",
                keyColumn: "Id",
                keyValue: -20);

            migrationBuilder.DeleteData(
                schema: "public",
                table: "work_prices",
                keyColumn: "Id",
                keyValue: -19);

            migrationBuilder.DeleteData(
                schema: "public",
                table: "work_prices",
                keyColumn: "Id",
                keyValue: -18);

            migrationBuilder.DeleteData(
                schema: "public",
                table: "work_prices",
                keyColumn: "Id",
                keyValue: -17);

            migrationBuilder.DeleteData(
                schema: "public",
                table: "work_prices",
                keyColumn: "Id",
                keyValue: -16);

            migrationBuilder.DeleteData(
                schema: "public",
                table: "work_prices",
                keyColumn: "Id",
                keyValue: -15);

            migrationBuilder.DeleteData(
                schema: "public",
                table: "work_prices",
                keyColumn: "Id",
                keyValue: -14);

            migrationBuilder.DeleteData(
                schema: "public",
                table: "work_prices",
                keyColumn: "Id",
                keyValue: -13);

            migrationBuilder.DeleteData(
                schema: "public",
                table: "work_prices",
                keyColumn: "Id",
                keyValue: -12);

            migrationBuilder.DeleteData(
                schema: "public",
                table: "work_prices",
                keyColumn: "Id",
                keyValue: -11);

            migrationBuilder.DeleteData(
                schema: "public",
                table: "work_prices",
                keyColumn: "Id",
                keyValue: -10);

            migrationBuilder.DeleteData(
                schema: "public",
                table: "work_prices",
                keyColumn: "Id",
                keyValue: -9);

            migrationBuilder.DeleteData(
                schema: "public",
                table: "work_prices",
                keyColumn: "Id",
                keyValue: -8);

            migrationBuilder.DeleteData(
                schema: "public",
                table: "work_prices",
                keyColumn: "Id",
                keyValue: -7);

            migrationBuilder.DeleteData(
                schema: "public",
                table: "work_prices",
                keyColumn: "Id",
                keyValue: -6);

            migrationBuilder.DeleteData(
                schema: "public",
                table: "work_prices",
                keyColumn: "Id",
                keyValue: -5);

            migrationBuilder.DeleteData(
                schema: "public",
                table: "work_prices",
                keyColumn: "Id",
                keyValue: -4);

            migrationBuilder.DeleteData(
                schema: "public",
                table: "work_prices",
                keyColumn: "Id",
                keyValue: -3);

            migrationBuilder.DeleteData(
                schema: "public",
                table: "work_prices",
                keyColumn: "Id",
                keyValue: -2);

            migrationBuilder.DeleteData(
                schema: "public",
                table: "work_prices",
                keyColumn: "Id",
                keyValue: -1);

            migrationBuilder.UpdateData(
                schema: "public",
                table: "roles",
                keyColumn: "Id",
                keyValue: 1,
                column: "ConcurrencyStamp",
                value: "a29b5f32-5895-4899-a42a-ab092c71c64f");

            migrationBuilder.InsertData(
                schema: "public",
                table: "work_prices",
                columns: new[] { "Id", "ContactPrice", "ExactPrice", "Name", "Price", "Unity" },
                values: new object[,]
                {
                    { 21, false, false, "Демонтаж настенной сплит-системы (модель 36) свыше 7.0КВт", 3000.0, "шт" },
                    { 20, false, false, "Демонтаж настенной сплит-системы (модель 24) до 7.0КВт", 2500.0, "шт" },
                    { 19, false, false, "Демонтаж настенной сплит-системы (модель 18) до 5.5КВт", 2000.0, "шт" },
                    { 18, false, false, "Демонтаж настенной сплит-системы (модель 12) до 3.5КВт", 1500.0, "шт" },
                    { 17, false, false, "Демонтаж настенной сплит-системы (модель 07, 09) до 2.8КВт", 1200.0, "шт" },
                    { 16, false, false, "Демонтаж оконного кондиционера", 1000.0, "шт" },
                    { 15, true, false, "Техническое обслуживание кассетных, канальных, напольно-потолочных, колонных и др. сплит-систем", null, "шт" },
                    { 14, false, false, "Техническое обслуживание настенной сплит-системы (модель 07, 09) свыше 7.0КВт", 3000.0, "шт" },
                    { 13, false, true, "Техническое обслуживание настенной сплит-системы (модель 24) до 7.0КВт", 2500.0, "шт" },
                    { 12, false, true, "Техническое обслуживание настенной сплит-системы (модель 18) до 5.5КВт", 2000.0, "шт" },
                    { 11, false, true, "Техническое обслуживание настенной сплит-системы (модель 12) до 3.5КВт", 1500.0, "шт" },
                    { 10, false, true, "Техническое обслуживание настенной сплит-системы (модель 07, 09) до 2.8КВт", 1200.0, "шт" },
                    { 9, false, false, "Техническое обслуживание оконного кондиционера", 1500.0, "шт" },
                    { 8, true, false, "Монтаж кассетных, канальных, напольно-потолочных, колонных и др. сплит-систем", null, "шт" },
                    { 7, false, false, "Монтаж мульти-сплит-системы с тремя внутреннеми блоками", 12000.0, "шт" },
                    { 6, false, false, "Монтаж мульти-сплит-системы с двумя внутреннеми блоками", 8000.0, "шт" },
                    { 5, false, false, "Монтаж настенной сплит-системы (модель 36) свыше 7.0КВт", 7000.0, "шт" },
                    { 4, false, false, "Монтаж настенной сплит-системы (модель 24) до 7.0КВт", 6000.0, "шт" },
                    { 3, false, false, "Монтаж настенной сплит-системы (модель 18) до 5.5КВт", 5500.0, "шт" },
                    { 2, false, false, "Монтаж настенной сплит-системы (модель 12) до 3.5КВт", 4500.0, "шт" },
                    { 1, false, false, "Монтаж настенной сплит-системы (модель 07, 09) до 2.8КВт", 4000.0, "шт" },
                    { 22, false, false, "Диагностика неисправности сплит-системы", 700.0, "шт" },
                    { 23, false, true, "Дополнительная межблочная коммуникация (для систем 07 и 09)", 500.0, "м" }
                });
        }
    }
}
