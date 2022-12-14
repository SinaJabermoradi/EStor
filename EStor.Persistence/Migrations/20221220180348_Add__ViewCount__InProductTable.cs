using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EStor.Persistence.Migrations
{
    public partial class Add__ViewCount__InProductTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<long>(
                name: "ViewCount",
                table: "Products",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ViewCount",
                table: "Products");
        }
    }
}
