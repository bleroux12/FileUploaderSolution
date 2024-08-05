using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FileUploader.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class IntialCreationofFileUploadDBandseedingthetables : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "tblClient",
                keyColumn: "ID",
                keyValue: new Guid("c307d31e-fb39-4b5b-824b-d38743485b0d"),
                columns: new[] { "CreatedDateTime", "ModifiedDateTime" },
                values: new object[] { new DateTime(2024, 7, 15, 13, 27, 15, 398, DateTimeKind.Local).AddTicks(8926), new DateTime(2024, 7, 15, 13, 27, 15, 398, DateTimeKind.Local).AddTicks(8927) });

            migrationBuilder.UpdateData(
                table: "tblClient",
                keyColumn: "ID",
                keyValue: new Guid("e5f946ea-18c4-4c18-aa6c-cc58f5266de8"),
                columns: new[] { "CreatedDateTime", "ModifiedDateTime" },
                values: new object[] { new DateTime(2024, 7, 15, 13, 27, 15, 398, DateTimeKind.Local).AddTicks(8929), new DateTime(2024, 7, 15, 13, 27, 15, 398, DateTimeKind.Local).AddTicks(8930) });

            migrationBuilder.UpdateData(
                table: "tblFileStatus",
                keyColumn: "Code",
                keyValue: "Error",
                column: "CreatedDateTime",
                value: new DateTime(2024, 7, 15, 13, 27, 15, 398, DateTimeKind.Local).AddTicks(8799));

            migrationBuilder.UpdateData(
                table: "tblFileStatus",
                keyColumn: "Code",
                keyValue: "New",
                column: "CreatedDateTime",
                value: new DateTime(2024, 7, 15, 13, 27, 15, 398, DateTimeKind.Local).AddTicks(8787));

            migrationBuilder.UpdateData(
                table: "tblFileStatus",
                keyColumn: "Code",
                keyValue: "PND",
                column: "CreatedDateTime",
                value: new DateTime(2024, 7, 15, 13, 27, 15, 398, DateTimeKind.Local).AddTicks(8797));

            migrationBuilder.UpdateData(
                table: "tblFileStatus",
                keyColumn: "Code",
                keyValue: "SNT",
                column: "CreatedDateTime",
                value: new DateTime(2024, 7, 15, 13, 27, 15, 398, DateTimeKind.Local).AddTicks(8798));
        }
    }
}
