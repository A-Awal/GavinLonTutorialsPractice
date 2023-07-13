using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ClubMembershipApplication.Migrations
{
    /// <inheritdoc />
    public partial class AddedEmailAddress : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "AddressSecondtLine",
                table: "Users",
                newName: "EmailAddress");

            migrationBuilder.AddColumn<string>(
                name: "AddressSecondLine",
                table: "Users",
                type: "TEXT",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AddressSecondLine",
                table: "Users");

            migrationBuilder.RenameColumn(
                name: "EmailAddress",
                table: "Users",
                newName: "AddressSecondtLine");
        }
    }
}
