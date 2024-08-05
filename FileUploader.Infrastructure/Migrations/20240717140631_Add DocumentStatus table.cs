using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace FileUploader.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddDocumentStatustable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "DocumentType",
                columns: table => new
                {
                    Code = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedDateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DocumentType", x => x.Code);
                });

            migrationBuilder.CreateTable(
                name: "tblDocumentStatus",
                columns: table => new
                {
                    Code = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedDateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblDocumentStatus", x => x.Code);
                });

            migrationBuilder.CreateTable(
                name: "Document",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DocumentFileName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    OutputFileName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FileExtension = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DocumentTypeCode = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    CreatedDateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedDateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Document", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Document_DocumentType_DocumentTypeCode",
                        column: x => x.DocumentTypeCode,
                        principalTable: "DocumentType",
                        principalColumn: "Code",
                        onDelete: ReferentialAction.Cascade);
                });

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

            migrationBuilder.InsertData(
                table: "tblDocumentStatus",
                columns: new[] { "Code", "CreatedDateTime", "Description", "IsDeleted" },
                values: new object[,]
                {
                    { "ATT", new DateTime(2024, 7, 17, 16, 6, 31, 524, DateTimeKind.Local).AddTicks(1321), "Document Attached", false },
                    { "ERR", new DateTime(2024, 7, 17, 16, 6, 31, 524, DateTimeKind.Local).AddTicks(1324), "Document Error", false },
                    { "SNT", new DateTime(2024, 7, 17, 16, 6, 31, 524, DateTimeKind.Local).AddTicks(1322), "Document Sent", false }
                });

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

            migrationBuilder.CreateIndex(
                name: "IX_tblFileDocument_DocumentID",
                table: "tblFileDocument",
                column: "DocumentID");

            migrationBuilder.CreateIndex(
                name: "IX_Document_DocumentTypeCode",
                table: "Document",
                column: "DocumentTypeCode");

            migrationBuilder.AddForeignKey(
                name: "FK_tblFileDocument_Document_DocumentID",
                table: "tblFileDocument",
                column: "DocumentID",
                principalTable: "Document",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_tblFileDocument_Document_DocumentID",
                table: "tblFileDocument");

            migrationBuilder.DropTable(
                name: "Document");

            migrationBuilder.DropTable(
                name: "tblDocumentStatus");

            migrationBuilder.DropTable(
                name: "DocumentType");

            migrationBuilder.DropIndex(
                name: "IX_tblFileDocument_DocumentID",
                table: "tblFileDocument");

            migrationBuilder.UpdateData(
                table: "tblClient",
                keyColumn: "ID",
                keyValue: new Guid("c307d31e-fb39-4b5b-824b-d38743485b0d"),
                columns: new[] { "CreatedDateTime", "ModifiedDateTime" },
                values: new object[] { new DateTime(2024, 7, 17, 14, 5, 58, 624, DateTimeKind.Local).AddTicks(7567), new DateTime(2024, 7, 17, 14, 5, 58, 624, DateTimeKind.Local).AddTicks(7568) });

            migrationBuilder.UpdateData(
                table: "tblClient",
                keyColumn: "ID",
                keyValue: new Guid("e5f946ea-18c4-4c18-aa6c-cc58f5266de8"),
                columns: new[] { "CreatedDateTime", "ModifiedDateTime" },
                values: new object[] { new DateTime(2024, 7, 17, 14, 5, 58, 624, DateTimeKind.Local).AddTicks(7571), new DateTime(2024, 7, 17, 14, 5, 58, 624, DateTimeKind.Local).AddTicks(7571) });

            migrationBuilder.UpdateData(
                table: "tblFileStatus",
                keyColumn: "Code",
                keyValue: "Error",
                column: "CreatedDateTime",
                value: new DateTime(2024, 7, 17, 14, 5, 58, 624, DateTimeKind.Local).AddTicks(7472));

            migrationBuilder.UpdateData(
                table: "tblFileStatus",
                keyColumn: "Code",
                keyValue: "New",
                column: "CreatedDateTime",
                value: new DateTime(2024, 7, 17, 14, 5, 58, 624, DateTimeKind.Local).AddTicks(7458));

            migrationBuilder.UpdateData(
                table: "tblFileStatus",
                keyColumn: "Code",
                keyValue: "PND",
                column: "CreatedDateTime",
                value: new DateTime(2024, 7, 17, 14, 5, 58, 624, DateTimeKind.Local).AddTicks(7470));

            migrationBuilder.UpdateData(
                table: "tblFileStatus",
                keyColumn: "Code",
                keyValue: "SNT",
                column: "CreatedDateTime",
                value: new DateTime(2024, 7, 17, 14, 5, 58, 624, DateTimeKind.Local).AddTicks(7471));
        }
    }
}
