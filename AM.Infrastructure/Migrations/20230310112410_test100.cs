using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AM.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class test100 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "fullName_LastName",
                table: "passengers",
                newName: "LastName");

            migrationBuilder.RenameColumn(
                name: "fullName_FirstName",
                table: "passengers",
                newName: "FirstName");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "LastName",
                table: "passengers",
                newName: "fullName_LastName");

            migrationBuilder.RenameColumn(
                name: "FirstName",
                table: "passengers",
                newName: "fullName_FirstName");
        }
    }
}
