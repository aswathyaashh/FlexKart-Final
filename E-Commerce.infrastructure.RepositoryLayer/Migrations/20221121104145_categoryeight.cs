using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ECommerce.infrastructure.RepositoryLayer.Migrations
{
    /// <inheritdoc />
    public partial class categoryeight : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Status",
                table: "Category"); 
            migrationBuilder.AddColumn<int>(
                name: "Status",
                table: "Category",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Status",
                table: "Category");
            migrationBuilder.DropColumn(
           name: "Status",
           table: "Category");
        }
    }
    }
