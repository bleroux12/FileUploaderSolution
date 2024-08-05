using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FileUploader.Infrastructure.Migrations.LogDb
{
    /// <inheritdoc />
    public partial class AddApplicationNametoEventLog : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ApplicationName",
                table: "tblEventLog",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ApplicationName",
                table: "tblEventLog");
        }
    }
}
