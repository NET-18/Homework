using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ApiWithEF.Migrations
{
    public partial class ProductCount : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ProductCount",
                table: "OrderProduct",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ProductCount",
                table: "OrderProduct");
        }
    }
}
