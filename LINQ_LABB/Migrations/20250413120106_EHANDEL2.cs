using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LINQ_LABB.Migrations
{
    /// <inheritdoc />
    public partial class EHANDEL2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 2,
                column: "TotalAmount",
                value: 9695);

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 7,
                column: "TotalAmount",
                value: 2546);

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 8,
                column: "TotalAmount",
                value: 3496);

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 9,
                column: "TotalAmount",
                value: 11896);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 2,
                column: "TotalAmount",
                value: 9798);

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 7,
                column: "TotalAmount",
                value: 2498);

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 8,
                column: "TotalAmount",
                value: 1598);

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 9,
                column: "TotalAmount",
                value: 5794);
        }
    }
}
