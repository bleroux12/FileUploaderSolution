using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FileUploader.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddFileDownloadtable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "tblFileDocument",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DocumentID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DocumentStatusCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedDateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedDateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblFileDocument", x => x.ID);
                });

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

            migrationBuilder.CreateIndex(
                name: "IX_tblFile_ClientID",
                table: "tblFile",
                column: "ClientID");

            migrationBuilder.AddForeignKey(
                name: "FK_tblFile_tblClient_ClientID",
                table: "tblFile",
                column: "ClientID",
                principalTable: "tblClient",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_tblFile_tblClient_ClientID",
                table: "tblFile");

            migrationBuilder.DropTable(
                name: "tblFileDocument");

            migrationBuilder.DropIndex(
                name: "IX_tblFile_ClientID",
                table: "tblFile");

            migrationBuilder.UpdateData(
                table: "tblClient",
                keyColumn: "ID",
                keyValue: new Guid("c307d31e-fb39-4b5b-824b-d38743485b0d"),
                columns: new[] { "CreatedDateTime", "ModifiedDateTime" },
                values: new object[] { new DateTime(2024, 7, 15, 13, 31, 1, 466, DateTimeKind.Local).AddTicks(8192), new DateTime(2024, 7, 15, 13, 31, 1, 466, DateTimeKind.Local).AddTicks(8192) });

            migrationBuilder.UpdateData(
                table: "tblClient",
                keyColumn: "ID",
                keyValue: new Guid("e5f946ea-18c4-4c18-aa6c-cc58f5266de8"),
                columns: new[] { "CreatedDateTime", "ModifiedDateTime" },
                values: new object[] { new DateTime(2024, 7, 15, 13, 31, 1, 466, DateTimeKind.Local).AddTicks(8196), new DateTime(2024, 7, 15, 13, 31, 1, 466, DateTimeKind.Local).AddTicks(8197) });

            migrationBuilder.UpdateData(
                table: "tblFileStatus",
                keyColumn: "Code",
                keyValue: "Error",
                column: "CreatedDateTime",
                value: new DateTime(2024, 7, 15, 13, 31, 1, 466, DateTimeKind.Local).AddTicks(8080));

            migrationBuilder.UpdateData(
                table: "tblFileStatus",
                keyColumn: "Code",
                keyValue: "New",
                column: "CreatedDateTime",
                value: new DateTime(2024, 7, 15, 13, 31, 1, 466, DateTimeKind.Local).AddTicks(8066));

            migrationBuilder.UpdateData(
                table: "tblFileStatus",
                keyColumn: "Code",
                keyValue: "PND",
                column: "CreatedDateTime",
                value: new DateTime(2024, 7, 15, 13, 31, 1, 466, DateTimeKind.Local).AddTicks(8077));

            migrationBuilder.UpdateData(
                table: "tblFileStatus",
                keyColumn: "Code",
                keyValue: "SNT",
                column: "CreatedDateTime",
                value: new DateTime(2024, 7, 15, 13, 31, 1, 466, DateTimeKind.Local).AddTicks(8079));
        }
    }
}
