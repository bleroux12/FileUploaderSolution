using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FileUploader.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class RelationshipchangesfortblFileDocument : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_tblFileDocument",
                table: "tblFileDocument");

            migrationBuilder.AddColumn<Guid>(
                name: "FileID",
                table: "tblFileDocument",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddPrimaryKey(
                name: "PK_tblFileDocument",
                table: "tblFileDocument",
                columns: new[] { "FileID", "DocumentID" });

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
                column: "CreatedDateTime",
                value: new DateTime(2024, 7, 17, 16, 39, 53, 162, DateTimeKind.Local).AddTicks(919));

            migrationBuilder.UpdateData(
                table: "tblFileStatus",
                keyColumn: "Code",
                keyValue: "SNT",
                column: "CreatedDateTime",
                value: new DateTime(2024, 7, 17, 16, 39, 53, 162, DateTimeKind.Local).AddTicks(920));

            migrationBuilder.AddForeignKey(
                name: "FK_tblFileDocument_tblFile_FileID",
                table: "tblFileDocument",
                column: "FileID",
                principalTable: "tblFile",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_tblFileDocument_tblFile_FileID",
                table: "tblFileDocument");

            migrationBuilder.DropPrimaryKey(
                name: "PK_tblFileDocument",
                table: "tblFileDocument");

            migrationBuilder.DropColumn(
                name: "FileID",
                table: "tblFileDocument");

            migrationBuilder.AddPrimaryKey(
                name: "PK_tblFileDocument",
                table: "tblFileDocument",
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

            migrationBuilder.UpdateData(
                table: "tblDocumentType",
                keyColumn: "Code",
                keyValue: "BLS",
                column: "CreatedDateTime",
                value: new DateTime(2024, 7, 17, 16, 17, 40, 706, DateTimeKind.Local).AddTicks(6843));

            migrationBuilder.UpdateData(
                table: "tblDocumentType",
                keyColumn: "Code",
                keyValue: "CNOTE",
                column: "CreatedDateTime",
                value: new DateTime(2024, 7, 17, 16, 17, 40, 706, DateTimeKind.Local).AddTicks(6842));

            migrationBuilder.UpdateData(
                table: "tblDocumentType",
                keyColumn: "Code",
                keyValue: "INV",
                column: "CreatedDateTime",
                value: new DateTime(2024, 7, 17, 16, 17, 40, 706, DateTimeKind.Local).AddTicks(6838));

            migrationBuilder.UpdateData(
                table: "tblDocumentType",
                keyColumn: "Code",
                keyValue: "MISC",
                column: "CreatedDateTime",
                value: new DateTime(2024, 7, 17, 16, 17, 40, 706, DateTimeKind.Local).AddTicks(6840));

            migrationBuilder.UpdateData(
                table: "tblDocumentType",
                keyColumn: "Code",
                keyValue: "SUPINV",
                column: "CreatedDateTime",
                value: new DateTime(2024, 7, 17, 16, 17, 40, 706, DateTimeKind.Local).AddTicks(6841));

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
        }
    }
}
