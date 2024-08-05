using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace FileUploader.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class FileUploadDBCreationAndSeeding : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "tblClient",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ClientName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FolderStructure = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FTPServer = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FTPUsername = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FTPPassword = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedDateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedDateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblClient", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "tblFile",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FileNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    InvoiceNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    InvoiceDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ClientID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    NumberOfDocs = table.Column<int>(type: "int", nullable: false),
                    CreatedDateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedDateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    FileStatusCode = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblFile", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "tblFileStatus",
                columns: table => new
                {
                    Code = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedDateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedDateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblFileStatus", x => x.Code);
                });

            migrationBuilder.InsertData(
                table: "tblClient",
                columns: new[] { "ID", "ClientName", "CreatedDateTime", "FTPPassword", "FTPServer", "FTPUsername", "FolderStructure", "IsDeleted", "ModifiedDateTime" },
                values: new object[,]
                {
                    { new Guid("c307d31e-fb39-4b5b-824b-d38743485b0d"), "Client1", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Client1", "ftp.test.com", "Client1", "Client1/Documents/{FileNumber}/{DocumentType_DocumentFileName}", false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("e5f946ea-18c4-4c18-aa6c-cc58f5266de8"), "Client2", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Client2", "ftp.test.com", "Client2", "Client1/Documents/{FileNumber}/{DocumentType_DocumentFileName}", false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.InsertData(
                table: "tblFileStatus",
                columns: new[] { "Code", "CreatedDateTime", "Description", "IsDeleted", "ModifiedDateTime" },
                values: new object[,]
                {
                    { "Error", new DateTime(2024, 7, 15, 13, 22, 33, 609, DateTimeKind.Local).AddTicks(8438), "File has an error and not all files attached have been sent to FTP", false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { "New", new DateTime(2024, 7, 15, 13, 22, 33, 609, DateTimeKind.Local).AddTicks(8425), "New File with no documents attached", false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { "PND", new DateTime(2024, 7, 15, 13, 22, 33, 609, DateTimeKind.Local).AddTicks(8436), "File has documents attached that are pending sending to FTP", false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { "SNT", new DateTime(2024, 7, 15, 13, 22, 33, 609, DateTimeKind.Local).AddTicks(8437), "All documents attached to the file have been sent to FTP", false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "tblClient");

            migrationBuilder.DropTable(
                name: "tblFile");

            migrationBuilder.DropTable(
                name: "tblFileStatus");
        }
    }
}
