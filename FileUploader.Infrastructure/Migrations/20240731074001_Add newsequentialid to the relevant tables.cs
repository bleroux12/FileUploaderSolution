using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FileUploader.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class Addnewsequentialidtotherelevanttables : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<Guid>(
                name: "ID",
                table: "tblFileDocument",
                type: "uniqueidentifier",
                nullable: false,
                defaultValueSql: "newsequentialid()",
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AlterColumn<Guid>(
                name: "ID",
                table: "tblFile",
                type: "uniqueidentifier",
                nullable: false,
                defaultValueSql: "newsequentialid()",
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AlterColumn<Guid>(
                name: "ID",
                table: "tblDocument",
                type: "uniqueidentifier",
                nullable: false,
                defaultValueSql: "newsequentialid()",
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AlterColumn<Guid>(
                name: "ID",
                table: "tblClient",
                type: "uniqueidentifier",
                nullable: false,
                defaultValueSql: "newsequentialid()",
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.UpdateData(
                table: "tblClient",
                keyColumn: "ID",
                keyValue: new Guid("c307d31e-fb39-4b5b-824b-d38743485b0d"),
                columns: new[] { "CreatedDateTime", "ModifiedDateTime" },
                values: new object[] { new DateTime(2024, 7, 31, 9, 39, 59, 463, DateTimeKind.Local).AddTicks(479), new DateTime(2024, 7, 31, 9, 39, 59, 463, DateTimeKind.Local).AddTicks(479) });

            migrationBuilder.UpdateData(
                table: "tblClient",
                keyColumn: "ID",
                keyValue: new Guid("e5f946ea-18c4-4c18-aa6c-cc58f5266de8"),
                columns: new[] { "CreatedDateTime", "ModifiedDateTime" },
                values: new object[] { new DateTime(2024, 7, 31, 9, 39, 59, 463, DateTimeKind.Local).AddTicks(482), new DateTime(2024, 7, 31, 9, 39, 59, 463, DateTimeKind.Local).AddTicks(483) });

            migrationBuilder.UpdateData(
                table: "tblDocumentStatus",
                keyColumn: "Code",
                keyValue: "ATT",
                column: "CreatedDateTime",
                value: new DateTime(2024, 7, 31, 9, 39, 59, 463, DateTimeKind.Local).AddTicks(497));

            migrationBuilder.UpdateData(
                table: "tblDocumentStatus",
                keyColumn: "Code",
                keyValue: "ERR",
                column: "CreatedDateTime",
                value: new DateTime(2024, 7, 31, 9, 39, 59, 463, DateTimeKind.Local).AddTicks(499));

            migrationBuilder.UpdateData(
                table: "tblDocumentStatus",
                keyColumn: "Code",
                keyValue: "SNT",
                column: "CreatedDateTime",
                value: new DateTime(2024, 7, 31, 9, 39, 59, 463, DateTimeKind.Local).AddTicks(498));

            migrationBuilder.UpdateData(
                table: "tblDocumentType",
                keyColumn: "Code",
                keyValue: "BLS",
                column: "CreatedDateTime",
                value: new DateTime(2024, 7, 31, 9, 39, 59, 463, DateTimeKind.Local).AddTicks(1296));

            migrationBuilder.UpdateData(
                table: "tblDocumentType",
                keyColumn: "Code",
                keyValue: "CNOTE",
                column: "CreatedDateTime",
                value: new DateTime(2024, 7, 31, 9, 39, 59, 463, DateTimeKind.Local).AddTicks(1295));

            migrationBuilder.UpdateData(
                table: "tblDocumentType",
                keyColumn: "Code",
                keyValue: "INV",
                column: "CreatedDateTime",
                value: new DateTime(2024, 7, 31, 9, 39, 59, 463, DateTimeKind.Local).AddTicks(1291));

            migrationBuilder.UpdateData(
                table: "tblDocumentType",
                keyColumn: "Code",
                keyValue: "MISC",
                column: "CreatedDateTime",
                value: new DateTime(2024, 7, 31, 9, 39, 59, 463, DateTimeKind.Local).AddTicks(1293));

            migrationBuilder.UpdateData(
                table: "tblDocumentType",
                keyColumn: "Code",
                keyValue: "SUPINV",
                column: "CreatedDateTime",
                value: new DateTime(2024, 7, 31, 9, 39, 59, 463, DateTimeKind.Local).AddTicks(1294));

            migrationBuilder.UpdateData(
                table: "tblFileStatus",
                keyColumn: "Code",
                keyValue: "Error",
                column: "CreatedDateTime",
                value: new DateTime(2024, 7, 31, 9, 39, 59, 463, DateTimeKind.Local).AddTicks(387));

            migrationBuilder.UpdateData(
                table: "tblFileStatus",
                keyColumn: "Code",
                keyValue: "New",
                column: "CreatedDateTime",
                value: new DateTime(2024, 7, 31, 9, 39, 59, 463, DateTimeKind.Local).AddTicks(372));

            migrationBuilder.UpdateData(
                table: "tblFileStatus",
                keyColumn: "Code",
                keyValue: "PND",
                columns: new[] { "CreatedDateTime", "Description" },
                values: new object[] { new DateTime(2024, 7, 31, 9, 39, 59, 463, DateTimeKind.Local).AddTicks(385), "File has documents attached that are ready to be sent to FTP" });

            migrationBuilder.UpdateData(
                table: "tblFileStatus",
                keyColumn: "Code",
                keyValue: "SNT",
                column: "CreatedDateTime",
                value: new DateTime(2024, 7, 31, 9, 39, 59, 463, DateTimeKind.Local).AddTicks(386));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<Guid>(
                name: "ID",
                table: "tblFileDocument",
                type: "uniqueidentifier",
                nullable: false,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldDefaultValueSql: "newsequentialid()");

            migrationBuilder.AlterColumn<Guid>(
                name: "ID",
                table: "tblFile",
                type: "uniqueidentifier",
                nullable: false,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldDefaultValueSql: "newsequentialid()");

            migrationBuilder.AlterColumn<Guid>(
                name: "ID",
                table: "tblDocument",
                type: "uniqueidentifier",
                nullable: false,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldDefaultValueSql: "newsequentialid()");

            migrationBuilder.AlterColumn<Guid>(
                name: "ID",
                table: "tblClient",
                type: "uniqueidentifier",
                nullable: false,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldDefaultValueSql: "newsequentialid()");

            migrationBuilder.UpdateData(
                table: "tblClient",
                keyColumn: "ID",
                keyValue: new Guid("c307d31e-fb39-4b5b-824b-d38743485b0d"),
                columns: new[] { "CreatedDateTime", "ModifiedDateTime" },
                values: new object[] { new DateTime(2024, 7, 17, 16, 39, 53, 162, DateTimeKind.Local).AddTicks(1015), new DateTime(2024, 7, 17, 16, 39, 53, 162, DateTimeKind.Local).AddTicks(1016) });

            migrationBuilder.UpdateData(
                table: "tblClient",
                keyColumn: "ID",
                keyValue: new Guid("e5f946ea-18c4-4c18-aa6c-cc58f5266de8"),
                columns: new[] { "CreatedDateTime", "ModifiedDateTime" },
                values: new object[] { new DateTime(2024, 7, 17, 16, 39, 53, 162, DateTimeKind.Local).AddTicks(1019), new DateTime(2024, 7, 17, 16, 39, 53, 162, DateTimeKind.Local).AddTicks(1019) });

            migrationBuilder.UpdateData(
                table: "tblDocumentStatus",
                keyColumn: "Code",
                keyValue: "ATT",
                column: "CreatedDateTime",
                value: new DateTime(2024, 7, 17, 16, 39, 53, 162, DateTimeKind.Local).AddTicks(1035));

            migrationBuilder.UpdateData(
                table: "tblDocumentStatus",
                keyColumn: "Code",
                keyValue: "ERR",
                column: "CreatedDateTime",
                value: new DateTime(2024, 7, 17, 16, 39, 53, 162, DateTimeKind.Local).AddTicks(1038));

            migrationBuilder.UpdateData(
                table: "tblDocumentStatus",
                keyColumn: "Code",
                keyValue: "SNT",
                column: "CreatedDateTime",
                value: new DateTime(2024, 7, 17, 16, 39, 53, 162, DateTimeKind.Local).AddTicks(1037));

            migrationBuilder.UpdateData(
                table: "tblDocumentType",
                keyColumn: "Code",
                keyValue: "BLS",
                column: "CreatedDateTime",
                value: new DateTime(2024, 7, 17, 16, 39, 53, 162, DateTimeKind.Local).AddTicks(1298));

            migrationBuilder.UpdateData(
                table: "tblDocumentType",
                keyColumn: "Code",
                keyValue: "CNOTE",
                column: "CreatedDateTime",
                value: new DateTime(2024, 7, 17, 16, 39, 53, 162, DateTimeKind.Local).AddTicks(1297));

            migrationBuilder.UpdateData(
                table: "tblDocumentType",
                keyColumn: "Code",
                keyValue: "INV",
                column: "CreatedDateTime",
                value: new DateTime(2024, 7, 17, 16, 39, 53, 162, DateTimeKind.Local).AddTicks(1293));

            migrationBuilder.UpdateData(
                table: "tblDocumentType",
                keyColumn: "Code",
                keyValue: "MISC",
                column: "CreatedDateTime",
                value: new DateTime(2024, 7, 17, 16, 39, 53, 162, DateTimeKind.Local).AddTicks(1295));

            migrationBuilder.UpdateData(
                table: "tblDocumentType",
                keyColumn: "Code",
                keyValue: "SUPINV",
                column: "CreatedDateTime",
                value: new DateTime(2024, 7, 17, 16, 39, 53, 162, DateTimeKind.Local).AddTicks(1296));

            migrationBuilder.UpdateData(
                table: "tblFileStatus",
                keyColumn: "Code",
                keyValue: "Error",
                column: "CreatedDateTime",
                value: new DateTime(2024, 7, 17, 16, 39, 53, 162, DateTimeKind.Local).AddTicks(921));

            migrationBuilder.UpdateData(
                table: "tblFileStatus",
                keyColumn: "Code",
                keyValue: "New",
                column: "CreatedDateTime",
                value: new DateTime(2024, 7, 17, 16, 39, 53, 162, DateTimeKind.Local).AddTicks(907));

            migrationBuilder.UpdateData(
                table: "tblFileStatus",
                keyColumn: "Code",
                keyValue: "PND",
                columns: new[] { "CreatedDateTime", "Description" },
                values: new object[] { new DateTime(2024, 7, 17, 16, 39, 53, 162, DateTimeKind.Local).AddTicks(919), "File has documents attached that are pending sending to FTP" });

            migrationBuilder.UpdateData(
                table: "tblFileStatus",
                keyColumn: "Code",
                keyValue: "SNT",
                column: "CreatedDateTime",
                value: new DateTime(2024, 7, 17, 16, 39, 53, 162, DateTimeKind.Local).AddTicks(920));
        }
    }
}
