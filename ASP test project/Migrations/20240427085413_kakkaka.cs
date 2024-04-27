using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ASP_test_project.Migrations
{
    /// <inheritdoc />
    public partial class kakkaka : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "EmailAddres",
                table: "Users",
                newName: "EmailAddress");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "EmailAddress",
                table: "Users",
                newName: "EmailAddres");
        }
    }
}
