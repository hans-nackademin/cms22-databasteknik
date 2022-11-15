using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WpfApp.Migrations
{
    /// <inheritdoc />
    public partial class coloraddedtoproductentity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Color",
                table: "Products",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Color",
                table: "Products");
        }
    }
}
