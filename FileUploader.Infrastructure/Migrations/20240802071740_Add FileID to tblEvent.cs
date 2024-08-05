using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FileUploader.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddFileIDtotblEvent : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "FileID",
                table: "tblEvent",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.UpdateData(
                table: "tblClient",
                keyColumn: "ID",
                keyValue: new Guid("c307d31e-fb39-4b5b-824b-d38743485b0d"),
                columns: new[] { "CreatedDateTime", "ModifiedDateTime" },
                values: new object[] { new DateTime(2024, 8, 2, 9, 17, 39, 908, DateTimeKind.Local).AddTicks(7944), new DateTime(2024, 8, 2, 9, 17, 39, 908, DateTimeKind.Local).AddTicks(7944) });

            migrationBuilder.UpdateData(
                table: "tblClient",
                keyColumn: "ID",
                keyValue: new Guid("e5f946ea-18c4-4c18-aa6c-cc58f5266de8"),
                columns: new[] { "CreatedDateTime", "ModifiedDateTime" },
                values: new object[] { new DateTime(2024, 8, 2, 9, 17, 39, 908, DateTimeKind.Local).AddTicks(7947), new DateTime(2024, 8, 2, 9, 17, 39, 908, DateTimeKind.Local).AddTicks(7948) });

            migrationBuilder.UpdateData(
                table: "tblDocumentStatus",
                keyColumn: "Code",
                keyValue: "ATT",
                column: "CreatedDateTime",
                value: new DateTime(2024, 8, 2, 9, 17, 39, 908, DateTimeKind.Local).AddTicks(7964));

            migrationBuilder.UpdateData(
                table: "tblDocumentStatus",
                keyColumn: "Code",
                keyValue: "ERR",
                column: "CreatedDateTime",
                value: new DateTime(2024, 8, 2, 9, 17, 39, 908, DateTimeKind.Local).AddTicks(7966));

            migrationBuilder.UpdateData(
                table: "tblDocumentStatus",
                keyColumn: "Code",
                keyValue: "SNT",
                column: "CreatedDateTime",
                value: new DateTime(2024, 8, 2, 9, 17, 39, 908, DateTimeKind.Local).AddTicks(7965));

            migrationBuilder.UpdateData(
                table: "tblDocumentType",
                keyColumn: "Code",
                keyValue: "BLS",
                column: "CreatedDateTime",
                value: new DateTime(2024, 8, 2, 9, 17, 39, 908, DateTimeKind.Local).AddTicks(8874));

            migrationBuilder.UpdateData(
                table: "tblDocumentType",
                keyColumn: "Code",
                keyValue: "CNOTE",
                column: "CreatedDateTime",
                value: new DateTime(2024, 8, 2, 9, 17, 39, 908, DateTimeKind.Local).AddTicks(8873));

            migrationBuilder.UpdateData(
                table: "tblDocumentType",
                keyColumn: "Code",
                keyValue: "INV",
                column: "CreatedDateTime",
                value: new DateTime(2024, 8, 2, 9, 17, 39, 908, DateTimeKind.Local).AddTicks(8868));

            migrationBuilder.UpdateData(
                table: "tblDocumentType",
                keyColumn: "Code",
                keyValue: "MISC",
                column: "CreatedDateTime",
                value: new DateTime(2024, 8, 2, 9, 17, 39, 908, DateTimeKind.Local).AddTicks(8871));

            migrationBuilder.UpdateData(
                table: "tblDocumentType",
                keyColumn: "Code",
                keyValue: "SUPINV",
                column: "CreatedDateTime",
                value: new DateTime(2024, 8, 2, 9, 17, 39, 908, DateTimeKind.Local).AddTicks(8872));

            migrationBuilder.UpdateData(
                table: "tblFileStatus",
                keyColumn: "Code",
                keyValue: "Error",
                column: "CreatedDateTime",
                value: new DateTime(2024, 8, 2, 9, 17, 39, 908, DateTimeKind.Local).AddTicks(7845));

            migrationBuilder.UpdateData(
                table: "tblFileStatus",
                keyColumn: "Code",
                keyValue: "New",
                column: "CreatedDateTime",
                value: new DateTime(2024, 8, 2, 9, 17, 39, 908, DateTimeKind.Local).AddTicks(7829));

            migrationBuilder.UpdateData(
                table: "tblFileStatus",
                keyColumn: "Code",
                keyValue: "PND",
                column: "CreatedDateTime",
                value: new DateTime(2024, 8, 2, 9, 17, 39, 908, DateTimeKind.Local).AddTicks(7842));

            migrationBuilder.UpdateData(
                table: "tblFileStatus",
                keyColumn: "Code",
                keyValue: "SNT",
                column: "CreatedDateTime",
                value: new DateTime(2024, 8, 2, 9, 17, 39, 908, DateTimeKind.Local).AddTicks(7844));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FileID",
                table: "tblEvent");

            migrationBuilder.UpdateData(
                table: "tblClient",
                keyColumn: "ID",
                keyValue: new Guid("c307d31e-fb39-4b5b-824b-d38743485b0d"),
                columns: new[] { "CreatedDateTime", "ModifiedDateTime" },
                values: new object[] { new DateTime(2024, 8, 2, 9, 6, 57, 507, DateTimeKind.Local).AddTicks(7130), new DateTime(2024, 8, 2, 9, 6, 57, 507, DateTimeKind.Local).AddTicks(7130) });

            migrationBuilder.UpdateData(
                table: "tblClient",
                keyColumn: "ID",
                keyValue: new Guid("e5f946ea-18c4-4c18-aa6c-cc58f5266de8"),
                columns: new[] { "CreatedDateTime", "ModifiedDateTime" },
                values: new object[] { new DateTime(2024, 8, 2, 9, 6, 57, 507, DateTimeKind.Local).AddTicks(7134), new DateTime(2024, 8, 2, 9, 6, 57, 507, DateTimeKind.Local).AddTicks(7135) });

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
    }
}
