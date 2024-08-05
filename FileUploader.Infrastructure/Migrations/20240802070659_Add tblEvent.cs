using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FileUploader.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddtblEvent : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "tblEvent",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "newsequentialid()"),
                    EventDescription = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedDateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UserID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblEvent", x => x.ID);
                });

            migrationBuilder.UpdateData(
                table: "tblClient",
                keyColumn: "ID",
                keyValue: new Guid("c307d31e-fb39-4b5b-824b-d38743485b0d"),
                columns: new[] { "CreatedDateTime", "FileNameStructure", "ModifiedDateTime" },
                values: new object[] { new DateTime(2024, 8, 2, 9, 6, 57, 507, DateTimeKind.Local).AddTicks(7130), "/{DocumentType_DocumentFileName}", new DateTime(2024, 8, 2, 9, 6, 57, 507, DateTimeKind.Local).AddTicks(7130) });

            migrationBuilder.UpdateData(
                table: "tblClient",
                keyColumn: "ID",
                keyValue: new Guid("e5f946ea-18c4-4c18-aa6c-cc58f5266de8"),
                columns: new[] { "CreatedDateTime", "FileNameStructure", "ModifiedDateTime" },
                values: new object[] { new DateTime(2024, 8, 2, 9, 6, 57, 507, DateTimeKind.Local).AddTicks(7134), "/{DocumentType_DocumentFileName}", new DateTime(2024, 8, 2, 9, 6, 57, 507, DateTimeKind.Local).AddTicks(7135) });

            migrationBuilder.UpdateData(
                table: "tblDocumentStatus",
                keyColumn: "Code",
                keyValue: "ATT",
                column: "CreatedDateTime",
                value: new DateTime(2024, 8, 2, 9, 6, 57, 507, DateTimeKind.Local).AddTicks(7150));

            migrationBuilder.UpdateData(
                table: "tblDocumentStatus",
                keyColumn: "Code",
                keyValue: "ERR",
                column: "CreatedDateTime",
                value: new DateTime(2024, 8, 2, 9, 6, 57, 507, DateTimeKind.Local).AddTicks(7153));

            migrationBuilder.UpdateData(
                table: "tblDocumentStatus",
                keyColumn: "Code",
                keyValue: "SNT",
                column: "CreatedDateTime",
                value: new DateTime(2024, 8, 2, 9, 6, 57, 507, DateTimeKind.Local).AddTicks(7151));

            migrationBuilder.UpdateData(
                table: "tblDocumentType",
                keyColumn: "Code",
                keyValue: "BLS",
                column: "CreatedDateTime",
                value: new DateTime(2024, 8, 2, 9, 6, 57, 507, DateTimeKind.Local).AddTicks(8039));

            migrationBuilder.UpdateData(
                table: "tblDocumentType",
                keyColumn: "Code",
                keyValue: "CNOTE",
                column: "CreatedDateTime",
                value: new DateTime(2024, 8, 2, 9, 6, 57, 507, DateTimeKind.Local).AddTicks(8038));

            migrationBuilder.UpdateData(
                table: "tblDocumentType",
                keyColumn: "Code",
                keyValue: "INV",
                column: "CreatedDateTime",
                value: new DateTime(2024, 8, 2, 9, 6, 57, 507, DateTimeKind.Local).AddTicks(8034));

            migrationBuilder.UpdateData(
                table: "tblDocumentType",
                keyColumn: "Code",
                keyValue: "MISC",
                column: "CreatedDateTime",
                value: new DateTime(2024, 8, 2, 9, 6, 57, 507, DateTimeKind.Local).AddTicks(8036));

            migrationBuilder.UpdateData(
                table: "tblDocumentType",
                keyColumn: "Code",
                keyValue: "SUPINV",
                column: "CreatedDateTime",
                value: new DateTime(2024, 8, 2, 9, 6, 57, 507, DateTimeKind.Local).AddTicks(8037));

            migrationBuilder.UpdateData(
                table: "tblFileStatus",
                keyColumn: "Code",
                keyValue: "Error",
                column: "CreatedDateTime",
                value: new DateTime(2024, 8, 2, 9, 6, 57, 507, DateTimeKind.Local).AddTicks(7016));

            migrationBuilder.UpdateData(
                table: "tblFileStatus",
                keyColumn: "Code",
                keyValue: "New",
                column: "CreatedDateTime",
                value: new DateTime(2024, 8, 2, 9, 6, 57, 507, DateTimeKind.Local).AddTicks(7002));

            migrationBuilder.UpdateData(
                table: "tblFileStatus",
                keyColumn: "Code",
                keyValue: "PND",
                column: "CreatedDateTime",
                value: new DateTime(2024, 8, 2, 9, 6, 57, 507, DateTimeKind.Local).AddTicks(7014));

            migrationBuilder.UpdateData(
                table: "tblFileStatus",
                keyColumn: "Code",
                keyValue: "SNT",
                column: "CreatedDateTime",
                value: new DateTime(2024, 8, 2, 9, 6, 57, 507, DateTimeKind.Local).AddTicks(7015));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "tblEvent");

            migrationBuilder.UpdateData(
                table: "tblClient",
                keyColumn: "ID",
                keyValue: new Guid("c307d31e-fb39-4b5b-824b-d38743485b0d"),
                columns: new[] { "CreatedDateTime", "FileNameStructure", "ModifiedDateTime" },
                values: new object[] { new DateTime(2024, 7, 31, 15, 50, 37, 139, DateTimeKind.Local).AddTicks(7791), "/{ DocumentType_DocumentFileName }", new DateTime(2024, 7, 31, 15, 50, 37, 139, DateTimeKind.Local).AddTicks(7792) });

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
    }
}
