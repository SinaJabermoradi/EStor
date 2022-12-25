using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EStor.Persistence.Migrations
{
    public partial class UpdateSliderTable__And__AddHomePageSliderImagesTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ImageSrc",
                table: "Slider");

            migrationBuilder.CreateTable(
                name: "SliderImages",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ImageSrc = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SliderId = table.Column<long>(type: "bigint", nullable: false),
                    InsertRecordTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdateRecordTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsRemoved = table.Column<bool>(type: "bit", nullable: false),
                    RemoveRecordTime = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SliderImages", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SliderImages_Slider_SliderId",
                        column: x => x.SliderId,
                        principalTable: "Slider",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_SliderImages_SliderId",
                table: "SliderImages",
                column: "SliderId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SliderImages");

            migrationBuilder.AddColumn<string>(
                name: "ImageSrc",
                table: "Slider",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
