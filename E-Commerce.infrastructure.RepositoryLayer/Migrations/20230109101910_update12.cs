using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ECommerce.infrastructure.RepositoryLayer.Migrations
{
    /// <inheritdoc />
    public partial class update12 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ProductName",
                table: "Order");

            migrationBuilder.RenameColumn(
                name: "SalesForceId",
                table: "Order",
                newName: "SalesforceOrderId");

            migrationBuilder.RenameColumn(
                name: "Date",
                table: "Order",
                newName: "OrderDate");

            migrationBuilder.RenameColumn(
                name: "SalesForceId",
                table: "Customer",
                newName: "SalesForceCustomerId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "SalesforceOrderId",
                table: "Order",
                newName: "SalesForceId");

            migrationBuilder.RenameColumn(
                name: "OrderDate",
                table: "Order",
                newName: "Date");

            migrationBuilder.RenameColumn(
                name: "SalesForceCustomerId",
                table: "Customer",
                newName: "SalesForceId");

            migrationBuilder.AddColumn<string>(
                name: "ProductName",
                table: "Order",
                type: "nvarchar(30)",
                maxLength: 30,
                nullable: true);
        }
    }
}
