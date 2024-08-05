using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace FileUploader.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddDocumentandDocumentStatus : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Document_DocumentType_DocumentTypeCode",
                table: "Document");

            migrationBuilder.DropForeignKey(
                name: "FK_tblFileDocument_Document_DocumentID",
                table: "tblFileDocument");

            migrationBuilder.DropPrimaryKey(
                name: "PK_DocumentType",
                table: "DocumentType");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Document",
                table: "Document");

            migrationBuilder.RenameTable(
                name: "DocumentType",
                newName: "tblDocumentType");

            migrationBuilder.RenameTable(
                name: "Document",
                newName: "tblDocument");

            migrationBuilder.RenameIndex(
                name: "IX_Document_DocumentTypeCode",
                table: "tblDocument",
                newName: "IX_tblDocument_DocumentTypeCode");

            migrationBuilder.AddPrimaryKey(
                name: "PK_tblDocumentType",
                table: "tblDocumentType",
                column: "Code");

            migrationBuilder.AddPrimaryKey(
                name: "PK_tblDocument",
                table: "tblDocument",
                column: "ID");

            migrationBuilder.UpdateData(
                table: "tblClient",
                keyColumn: "ID",
                keyValue: new Guid("c307d31e-fb39-4b5b-824b-d38743485b0d"),
                columns: new[] { "CreatedDateTime", "ModifiedDateTime" },
                values: new object[] { new DateTime(2024, 7, 17, 16, 17, 40, 706, DateTimeKind.Local).AddTicks(6589), new DateTime(2024, 7, 17, 16, 17, 40, 706, DateTimeKind.Local).AddTicks(6590) });

            migrationBuilder.UpdateData(
                table: "tblClient",
                keyColumn: "ID",
                keyValue: new Guid("e5f946ea-18c4-4c18-aa6c-cc58f5266de8"),
                columns: new[] { "CreatedDateTime", "ModifiedDateTime" },
                values: new object[] { new DateTime(2024, 7, 17, 16, 17, 40, 706, DateTimeKind.Local).AddTicks(6593), new DateTime(2024, 7, 17, 16, 17, 40, 706, DateTimeKind.Local).AddTicks(6594) });

            migrationBuilder.UpdateData(
                table: "tblDocumentStatus",
                keyColumn: "Code",
                keyValue: "ATT",
                column: "CreatedDateTime",
                value: new DateTime(2024, 7, 17, 16, 17, 40, 706, DateTimeKind.Local).AddTicks(6610));

            migrationBuilder.UpdateData(
                table: "tblDocumentStatus",
                keyColumn: "Code",
                keyValue: "ERR",
                column: "CreatedDateTime",
                value: new DateTime(2024, 7, 17, 16, 17, 40, 706, DateTimeKind.Local).AddTicks(6613));

            migrationBuilder.UpdateData(
                table: "tblDocumentStatus",
                keyColumn: "Code",
                keyValue: "SNT",
                column: "CreatedDateTime",
                value: new DateTime(2024, 7, 17, 16, 17, 40, 706, DateTimeKind.Local).AddTicks(6611));

            migrationBuilder.InsertData(
                table: "tblDocumentType",
                columns: new[] { "Code", "CreatedDateTime", "Description", "IsDeleted" },
                values: new object[,]
                {
                    { "BLS", new DateTime(2024, 7, 17, 16, 17, 40, 706, DateTimeKind.Local).AddTicks(6843), "Billing Sheet", false },
                    { "CNOTE", new DateTime(2024, 7, 17, 16, 17, 40, 706, DateTimeKind.Local).AddTicks(6842), "CreditNote", false },
                    { "INV", new DateTime(2024, 7, 17, 16, 17, 40, 706, DateTimeKind.Local).AddTicks(6838), "Invoice", false },
                    { "MISC", new DateTime(2024, 7, 17, 16, 17, 40, 706, DateTimeKind.Local).AddTicks(6840), "Miscellaneous Document", false },
                    { "SUPINV", new DateTime(2024, 7, 17, 16, 17, 40, 706, DateTimeKind.Local).AddTicks(6841), "Supplier Invoice", false }
                });

            migrationBuilder.UpdateData(
                table: "tblFileStatus",
                keyColumn: "Code",
                keyValue: "Error",
                column: "CreatedDateTime",
                value: new DateTime(2024, 7, 17, 16, 17, 40, 706, DateTimeKind.Local).AddTicks(6472));

            migrationBuilder.UpdateData(
                table: "tblFileStatus",
                keyColumn: "Code",
                keyValue: "New",
                column: "CreatedDateTime",
                value: new DateTime(2024, 7, 17, 16, 17, 40, 706, DateTimeKind.Local).AddTicks(6455));

            migrationBuilder.UpdateData(
                table: "tblFileStatus",
                keyColumn: "Code",
                keyValue: "PND",
                column: "CreatedDateTime",
                value: new DateTime(2024, 7, 17, 16, 17, 40, 706, DateTimeKind.Local).AddTicks(6470));

            migrationBuilder.UpdateData(
                table: "tblFileStatus",
                keyColumn: "Code",
                keyValue: "SNT",
                column: "CreatedDateTime",
                value: new DateTime(2024, 7, 17, 16, 17, 40, 706, DateTimeKind.Local).AddTicks(6471));

            migrationBuilder.AddForeignKey(
                name: "FK_tblDocument_tblDocumentType_DocumentTypeCode",
                table: "tblDocument",
                column: "DocumentTypeCode",
                principalTable: "tblDocumentType",
                principalColumn: "Code",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_tblFileDocument_tblDocument_DocumentID",
                table: "tblFileDocument",
                column: "DocumentID",
                principalTable: "tblDocument",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_tblDocument_tblDocumentType_DocumentTypeCode",
                table: "tblDocument");

            migrationBuilder.DropForeignKey(
                name: "FK_tblFileDocument_tblDocument_DocumentID",
                table: "tblFileDocument");

            migrationBuilder.DropPrimaryKey(
                name: "PK_tblDocumentType",
                table: "tblDocumentType");

            migrationBuilder.DropPrimaryKey(
                name: "PK_tblDocument",
                table: "tblDocument");

            migrationBuilder.DeleteData(
                table: "tblDocumentType",
                keyColumn: "Code",
                keyValue: "BLS");

            migrationBuilder.DeleteData(
                table: "tblDocumentType",
                keyColumn: "Code",
                keyValue: "CNOTE");

            migrationBuilder.DeleteData(
                table: "tblDocumentType",
                keyColumn: "Code",
                keyValue: "INV");

            migrationBuilder.DeleteData(
                table: "tblDocumentType",
                keyColumn: "Code",
                keyValue: "MISC");

            migrationBuilder.DeleteData(
                table: "tblDocumentType",
                keyColumn: "Code",
                keyValue: "SUPINV");

            migrationBuilder.RenameTable(
                name: "tblDocumentType",
                newName: "DocumentType");

            migrationBuilder.RenameTable(
                name: "tblDocument",
                newName: "Document");

            migrationBuilder.RenameIndex(
                name: "IX_tblDocument_DocumentTypeCode",
                table: "Document",
                newName: "IX_Document_DocumentTypeCode");

            migrationBuilder.AddPrimaryKey(
                name: "PK_DocumentType",
                table: "DocumentType",
                column: "Code");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Document",
                table: "Document",
                column: "ID");

            migrationBuilder.UpdateData(
                table: "tblClient",
                keyColumn: "ID",
                keyValue: new Guid("c307d31e-fb39-4b5b-824b-d38743485b0d"),
                columns: new[] { "CreatedDateTime", "ModifiedDateTime" },
                values: new object[] { new DateTime(2024, 7, 17, 16, 6, 31, 524, DateTimeKind.Local).AddTicks(1304), new DateTime(2024, 7, 17, 16, 6, 31, 524, DateTimeKind.Local).AddTicks(1305) });

            migrationBuilder.UpdateData(
                table: "tblClient",
                keyColumn: "ID",
                keyValue: new Guid("e5f946ea-18c4-4c18-aa6c-cc58f5266de8"),
                columns: new[] { "CreatedDateTime", "ModifiedDateTime" },
                values: new object[] { new DateTime(2024, 7, 17, 16, 6, 31, 524, DateTimeKind.Local).AddTicks(1308), new DateTime(2024, 7, 17, 16, 6, 31, 524, DateTimeKind.Local).AddTicks(1309) });

            migrationBuilder.UpdateData(
                table: "tblDocumentStatus",
                keyColumn: "Code",
                keyValue: "ATT",
                column: "CreatedDateTime",
                value: new DateTime(2024, 7, 17, 16, 6, 31, 524, DateTimeKind.Local).AddTicks(1321));

            migrationBuilder.UpdateData(
                table: "tblDocumentStatus",
                keyColumn: "Code",
                keyValue: "ERR",
                column: "CreatedDateTime",
                value: new DateTime(2024, 7, 17, 16, 6, 31, 524, DateTimeKind.Local).AddTicks(1324));

            migrationBuilder.UpdateData(
                table: "tblDocumentStatus",
                keyColumn: "Code",
                keyValue: "SNT",
                column: "CreatedDateTime",
                value: new DateTime(2024, 7, 17, 16, 6, 31, 524, DateTimeKind.Local).AddTicks(1322));

            migrationBuilder.UpdateData(
                table: "tblFileStatus",
                keyColumn: "Code",
                keyValue: "Error",
                column: "CreatedDateTime",
                value: new DateTime(2024, 7, 17, 16, 6, 31, 524, DateTimeKind.Local).AddTicks(1178));

            migrationBuilder.UpdateData(
                table: "tblFileStatus",
                keyColumn: "Code",
                keyValue: "New",
                column: "CreatedDateTime",
                value: new DateTime(2024, 7, 17, 16, 6, 31, 524, DateTimeKind.Local).AddTicks(1163));

            migrationBuilder.UpdateData(
                table: "tblFileStatus",
                keyColumn: "Code",
                keyValue: "PND",
                column: "CreatedDateTime",
                value: new DateTime(2024, 7, 17, 16, 6, 31, 524, DateTimeKind.Local).AddTicks(1175));

            migrationBuilder.UpdateData(
                table: "tblFileStatus",
                keyColumn: "Code",
                keyValue: "SNT",
                column: "CreatedDateTime",
                value: new DateTime(2024, 7, 17, 16, 6, 31, 524, DateTimeKind.Local).AddTicks(1177));

            migrationBuilder.AddForeignKey(
                name: "FK_Document_DocumentType_DocumentTypeCode",
                table: "Document",
                column: "DocumentTypeCode",
                principalTable: "DocumentType",
                principalColumn: "Code",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_tblFileDocument_Document_DocumentID",
                table: "tblFileDocument",
                column: "DocumentID",
                principalTable: "Document",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
