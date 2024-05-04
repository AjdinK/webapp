using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace itservicecenter.Migrations
{
    /// <inheritdoc />
    public partial class init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Admin_KorsnickiNalog_ID",
                table: "Admin");

            migrationBuilder.DropForeignKey(
                name: "FK_Prodavac_KorsnickiNalog_ID",
                table: "Prodavac");

            migrationBuilder.DropForeignKey(
                name: "FK_Serviser_KorsnickiNalog_ID",
                table: "Serviser");

            migrationBuilder.DeleteData(
                table: "Serviser_ServisniDio",
                keyColumns: new[] { "Datum", "ServiserID", "ServisniDioID" },
                keyValues: new object[] { new DateTime(2024, 5, 4, 12, 27, 59, 719, DateTimeKind.Local).AddTicks(3827), 2, 1 });

            migrationBuilder.DeleteData(
                table: "Serviser_ServisniDio",
                keyColumns: new[] { "Datum", "ServiserID", "ServisniDioID" },
                keyValues: new object[] { new DateTime(2024, 5, 4, 12, 27, 59, 719, DateTimeKind.Local).AddTicks(3839), 2, 2 });

            migrationBuilder.DeleteData(
                table: "Serviser_ServisniDio",
                keyColumns: new[] { "Datum", "ServiserID", "ServisniDioID" },
                keyValues: new object[] { new DateTime(2024, 5, 4, 12, 27, 59, 719, DateTimeKind.Local).AddTicks(3842), 2, 3 });

            migrationBuilder.DeleteData(
                table: "Serviser_ServisniDio",
                keyColumns: new[] { "Datum", "ServiserID", "ServisniDioID" },
                keyValues: new object[] { new DateTime(2024, 5, 4, 12, 27, 59, 719, DateTimeKind.Local).AddTicks(3845), 2, 4 });

            migrationBuilder.UpdateData(
                table: "Racun",
                keyColumn: "ID",
                keyValue: 1,
                column: "DatumPreuzimanja",
                value: new DateTime(2024, 5, 4, 12, 31, 45, 394, DateTimeKind.Local).AddTicks(7505));

            migrationBuilder.InsertData(
                table: "Serviser_ServisniDio",
                columns: new[] { "Datum", "ServiserID", "ServisniDioID", "Kolicina" },
                values: new object[,]
                {
                    { new DateTime(2024, 5, 4, 12, 31, 45, 394, DateTimeKind.Local).AddTicks(8475), 2, 1, 3 },
                    { new DateTime(2024, 5, 4, 12, 31, 45, 394, DateTimeKind.Local).AddTicks(8488), 2, 2, 3 },
                    { new DateTime(2024, 5, 4, 12, 31, 45, 394, DateTimeKind.Local).AddTicks(8491), 2, 3, 2 },
                    { new DateTime(2024, 5, 4, 12, 31, 45, 394, DateTimeKind.Local).AddTicks(8493), 2, 4, 1 }
                });

            migrationBuilder.UpdateData(
                table: "ServisniNalog",
                keyColumn: "ID",
                keyValue: 1,
                columns: new[] { "DatumPredaje", "DatumZaprimanja" },
                values: new object[] { new DateTime(2024, 5, 6, 12, 31, 45, 394, DateTimeKind.Local).AddTicks(8817), new DateTime(2024, 5, 4, 12, 31, 45, 394, DateTimeKind.Local).AddTicks(8812) });

            migrationBuilder.UpdateData(
                table: "ServisniNalog",
                keyColumn: "ID",
                keyValue: 2,
                columns: new[] { "DatumPredaje", "DatumZaprimanja" },
                values: new object[] { new DateTime(2024, 5, 6, 12, 31, 45, 394, DateTimeKind.Local).AddTicks(8827), new DateTime(2024, 5, 4, 12, 31, 45, 394, DateTimeKind.Local).AddTicks(8825) });

            migrationBuilder.UpdateData(
                table: "ServisniNalog",
                keyColumn: "ID",
                keyValue: 3,
                columns: new[] { "DatumPredaje", "DatumZaprimanja" },
                values: new object[] { new DateTime(2024, 5, 6, 12, 31, 45, 394, DateTimeKind.Local).AddTicks(8831), new DateTime(2024, 5, 4, 12, 31, 45, 394, DateTimeKind.Local).AddTicks(8830) });

            migrationBuilder.UpdateData(
                table: "ServisniNalog",
                keyColumn: "ID",
                keyValue: 4,
                columns: new[] { "DatumPredaje", "DatumZaprimanja" },
                values: new object[] { new DateTime(2024, 5, 6, 12, 31, 45, 394, DateTimeKind.Local).AddTicks(8836), new DateTime(2024, 5, 4, 12, 31, 45, 394, DateTimeKind.Local).AddTicks(8834) });

            migrationBuilder.UpdateData(
                table: "ServisniNalog",
                keyColumn: "ID",
                keyValue: 5,
                columns: new[] { "DatumPredaje", "DatumZaprimanja" },
                values: new object[] { new DateTime(2024, 5, 6, 12, 31, 45, 394, DateTimeKind.Local).AddTicks(8840), new DateTime(2024, 5, 4, 12, 31, 45, 394, DateTimeKind.Local).AddTicks(8838) });

            migrationBuilder.AddForeignKey(
                name: "FK_Admin_KorsnickiNalog_ID",
                table: "Admin",
                column: "ID",
                principalTable: "KorsnickiNalog",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Prodavac_KorsnickiNalog_ID",
                table: "Prodavac",
                column: "ID",
                principalTable: "KorsnickiNalog",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Serviser_KorsnickiNalog_ID",
                table: "Serviser",
                column: "ID",
                principalTable: "KorsnickiNalog",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Admin_KorsnickiNalog_ID",
                table: "Admin");

            migrationBuilder.DropForeignKey(
                name: "FK_Prodavac_KorsnickiNalog_ID",
                table: "Prodavac");

            migrationBuilder.DropForeignKey(
                name: "FK_Serviser_KorsnickiNalog_ID",
                table: "Serviser");

            migrationBuilder.DeleteData(
                table: "Serviser_ServisniDio",
                keyColumns: new[] { "Datum", "ServiserID", "ServisniDioID" },
                keyValues: new object[] { new DateTime(2024, 5, 4, 12, 31, 45, 394, DateTimeKind.Local).AddTicks(8475), 2, 1 });

            migrationBuilder.DeleteData(
                table: "Serviser_ServisniDio",
                keyColumns: new[] { "Datum", "ServiserID", "ServisniDioID" },
                keyValues: new object[] { new DateTime(2024, 5, 4, 12, 31, 45, 394, DateTimeKind.Local).AddTicks(8488), 2, 2 });

            migrationBuilder.DeleteData(
                table: "Serviser_ServisniDio",
                keyColumns: new[] { "Datum", "ServiserID", "ServisniDioID" },
                keyValues: new object[] { new DateTime(2024, 5, 4, 12, 31, 45, 394, DateTimeKind.Local).AddTicks(8491), 2, 3 });

            migrationBuilder.DeleteData(
                table: "Serviser_ServisniDio",
                keyColumns: new[] { "Datum", "ServiserID", "ServisniDioID" },
                keyValues: new object[] { new DateTime(2024, 5, 4, 12, 31, 45, 394, DateTimeKind.Local).AddTicks(8493), 2, 4 });

            migrationBuilder.UpdateData(
                table: "Racun",
                keyColumn: "ID",
                keyValue: 1,
                column: "DatumPreuzimanja",
                value: new DateTime(2024, 5, 4, 12, 27, 59, 719, DateTimeKind.Local).AddTicks(2917));

            migrationBuilder.InsertData(
                table: "Serviser_ServisniDio",
                columns: new[] { "Datum", "ServiserID", "ServisniDioID", "Kolicina" },
                values: new object[,]
                {
                    { new DateTime(2024, 5, 4, 12, 27, 59, 719, DateTimeKind.Local).AddTicks(3827), 2, 1, 3 },
                    { new DateTime(2024, 5, 4, 12, 27, 59, 719, DateTimeKind.Local).AddTicks(3839), 2, 2, 3 },
                    { new DateTime(2024, 5, 4, 12, 27, 59, 719, DateTimeKind.Local).AddTicks(3842), 2, 3, 2 },
                    { new DateTime(2024, 5, 4, 12, 27, 59, 719, DateTimeKind.Local).AddTicks(3845), 2, 4, 1 }
                });

            migrationBuilder.UpdateData(
                table: "ServisniNalog",
                keyColumn: "ID",
                keyValue: 1,
                columns: new[] { "DatumPredaje", "DatumZaprimanja" },
                values: new object[] { new DateTime(2024, 5, 6, 12, 27, 59, 719, DateTimeKind.Local).AddTicks(4221), new DateTime(2024, 5, 4, 12, 27, 59, 719, DateTimeKind.Local).AddTicks(4215) });

            migrationBuilder.UpdateData(
                table: "ServisniNalog",
                keyColumn: "ID",
                keyValue: 2,
                columns: new[] { "DatumPredaje", "DatumZaprimanja" },
                values: new object[] { new DateTime(2024, 5, 6, 12, 27, 59, 719, DateTimeKind.Local).AddTicks(4231), new DateTime(2024, 5, 4, 12, 27, 59, 719, DateTimeKind.Local).AddTicks(4229) });

            migrationBuilder.UpdateData(
                table: "ServisniNalog",
                keyColumn: "ID",
                keyValue: 3,
                columns: new[] { "DatumPredaje", "DatumZaprimanja" },
                values: new object[] { new DateTime(2024, 5, 6, 12, 27, 59, 719, DateTimeKind.Local).AddTicks(4236), new DateTime(2024, 5, 4, 12, 27, 59, 719, DateTimeKind.Local).AddTicks(4234) });

            migrationBuilder.UpdateData(
                table: "ServisniNalog",
                keyColumn: "ID",
                keyValue: 4,
                columns: new[] { "DatumPredaje", "DatumZaprimanja" },
                values: new object[] { new DateTime(2024, 5, 6, 12, 27, 59, 719, DateTimeKind.Local).AddTicks(4241), new DateTime(2024, 5, 4, 12, 27, 59, 719, DateTimeKind.Local).AddTicks(4239) });

            migrationBuilder.UpdateData(
                table: "ServisniNalog",
                keyColumn: "ID",
                keyValue: 5,
                columns: new[] { "DatumPredaje", "DatumZaprimanja" },
                values: new object[] { new DateTime(2024, 5, 6, 12, 27, 59, 719, DateTimeKind.Local).AddTicks(4246), new DateTime(2024, 5, 4, 12, 27, 59, 719, DateTimeKind.Local).AddTicks(4244) });

            migrationBuilder.AddForeignKey(
                name: "FK_Admin_KorsnickiNalog_ID",
                table: "Admin",
                column: "ID",
                principalTable: "KorsnickiNalog",
                principalColumn: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_Prodavac_KorsnickiNalog_ID",
                table: "Prodavac",
                column: "ID",
                principalTable: "KorsnickiNalog",
                principalColumn: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_Serviser_KorsnickiNalog_ID",
                table: "Serviser",
                column: "ID",
                principalTable: "KorsnickiNalog",
                principalColumn: "ID");
        }
    }
}
