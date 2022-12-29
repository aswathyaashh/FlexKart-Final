using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ECommerce.infrastructure.RepositoryLayer.Migrations
{
    /// <inheritdoc />
    public partial class logindemo6 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "password",
                table: "Login",
                newName: "Password");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Password",
                table: "Login",
                newName: "password");
        }
    }
}
