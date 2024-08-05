using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FileUploader.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class Updateclienttosplitfolderstructureandfilestructure : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "FileNameStructure",
                table: "tblClient",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "tblClient",
                keyColumn: "ID",
                keyValue: new Guid("c307d31e-fb39-4b5b-824b-d38743485b0d"),
                columns: new[] { "CreatedDateTime", "FileNameStructure", "FolderStructure", "ModifiedDateTime" },
                values: new object[] { new DateTime(2024, 7, 31, 15, 50, 37, 139, DateTimeKind.Local).AddTicks(7791), "/{ DocumentType_DocumentFileName }", "Client1/Documents/{FileNumber}", new DateTime(2024, 7, 31, 15, 50, 37, 139, DateTimeKind.Local).AddTicks(7792) });

            migrationBuilder.UpdateData(
                table: "tblClient",
                keyColumn: "ID",
                keyValue: new Guid("e5f946ea-18c4-4c18-aa6c-cc58f5266de8"),
                columns: new[] { "CreatedDateTime", "FileNameStructure", "ModifiedDateTime" },
                values: new object[] { new DateTime(2024, 7, 31, 15, 50, 37, 139, DateTimeKind.Local).AddTicks(7795), "/{ DocumentType_DocumentFileName }", new DateTime(2024, 7, 31, 15, 50, 37, 139, DateTimeKind.Local).AddTicks(7796) });

            migrationBuilder.UpdateData(
                table: "tblDocumentStatus",
                keyColumn: "Code",
                keyValue: "ATT",
                column: "CreatedDateTime",
                value: new DateTime(2024, 7, 31, 15, 50, 37, 139, DateTimeKind.Local).AddTicks(7812));

            migrationBuilder.UpdateData(
                table: "tblDocumentStatus",
                keyColumn: "Code",
                keyValue: "ERR",
                column: "CreatedDateTime",
                value: new DateTime(2024, 7, 31, 15, 50, 37, 139, DateTimeKind.Local).AddTicks(7815));

            migrationBuilder.UpdateData(
                table: "tblDocumentStatus",
                keyColumn: "Code",
                keyValue: "SNT",
                column: "CreatedDateTime",
                value: new DateTime(2024, 7, 31, 15, 50, 37, 139, DateTimeKind.Local).AddTicks(7814));

            migrationBuilder.UpdateData(
                table: "tblDocumentType",
                keyColumn: "Code",
                keyValue: "BLS",
                column: "CreatedDateTime",
                value: new DateTime(2024, 7, 31, 15, 50, 37, 140, DateTimeKind.Local).AddTicks(274));

            migrationBuilder.UpdateData(
                table: "tblDocumentType",
                keyColumn: "Code",
                keyValue: "CNOTE",
                column: "CreatedDateTime",
                value: new DateTime(2024, 7, 31, 15, 50, 37, 140, DateTimeKind.Local).AddTicks(273));

            migrationBuilder.UpdateData(
                table: "tblDocumentType",
                keyColumn: "Code",
                keyValue: "INV",
                column: "CreatedDateTime",
                value: new DateTime(2024, 7, 31, 15, 50, 37, 140, DateTimeKind.Local).AddTicks(266));

            migrationBuilder.UpdateData(
                table: "tblDocumentType",
                keyColumn: "Code",
                keyValue: "MISC",
                column: "CreatedDateTime",
                value: new DateTime(2024, 7, 31, 15, 50, 37, 140, DateTimeKind.Local).AddTicks(271));

            migrationBuilder.UpdateData(
                table: "tblDocumentType",
                keyColumn: "Code",
                keyValue: "SUPINV",
                column: "CreatedDateTime",
                value: new DateTime(2024, 7, 31, 15, 50, 37, 140, DateTimeKind.Local).AddTicks(272));

            migrationBuilder.UpdateData(
                table: "tblFileStatus",
                keyColumn: "Code",
                keyValue: "Error",
                column: "CreatedDateTime",
                value: new DateTime(2024, 7, 31, 15, 50, 37, 139, DateTimeKind.Local).AddTicks(7678));

            migrationBuilder.UpdateData(
                table: "tblFileStatus",
                keyColumn: "Code",
                keyValue: "New",
                column: "CreatedDateTime",
                value: new DateTime(2024, 7, 31, 15, 50, 37, 139, DateTimeKind.Local).AddTicks(7664));

            migrationBuilder.UpdateData(
                table: "tblFileStatus",
                keyColumn: "Code",
                keyValue: "PND",
                column: "CreatedDateTime",
                value: new DateTime(2024, 7, 31, 15, 50, 37, 139, DateTimeKind.Local).AddTicks(7676));

            migrationBuilder.UpdateData(
                table: "tblFileStatus",
                keyColumn: "Code",
                keyValue: "SNT",
                column: "CreatedDateTime",
                value: new DateTime(2024, 7, 31, 15, 50, 37, 139, DateTimeKind.Local).AddTicks(7677));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FileNameStructure",
                table: "tblClient");

            migrationBuilder.UpdateData(
                table: "tblClient",
                keyColumn: "ID",
                keyValue: new Guid("c307d31e-fb39-4b5b-824b-d38743485b0d"),
                columns: new[] { "CreatedDateTime", "FolderStructure", "ModifiedDateTime" },
                values: new object[] { new DateTime(2024, 7, 31, 9, 39, 59, 463, DateTimeKind.Local).AddTicks(479), "Client1/Documents/{FileNumber}/{DocumentType_DocumentFileName}", new DateTime(2024, 7, 31, 9, 39, 59, 463, DateTimeKind.Local).AddTicks(479) });

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
                column: "CreatedDateTime",
                value: new DateTime(2024, 7, 31, 9, 39, 59, 463, DateTimeKind.Local).AddTicks(385));

            migrationBuilder.UpdateData(
                table: "tblFileStatus",
                keyColumn: "Code",
                keyValue: "SNT",
                column: "CreatedDateTime",
                value: new DateTime(2024, 7, 31, 9, 39, 59, 463, DateTimeKind.Local).AddTicks(386));
        }
    }
}
