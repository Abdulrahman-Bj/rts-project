using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class hote_room : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CoverImage",
                table: "Hotels");

            migrationBuilder.DropColumn(
                name: "Images",
                table: "Hotels");

            migrationBuilder.AddColumn<Guid>(
                name: "CoverImageId",
                table: "Hotels",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateTable(
                name: "HotelImages",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    HotelId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HotelImages", x => x.Id);
                    table.ForeignKey(
                        name: "FK_HotelImages_Hotels_HotelId",
                        column: x => x.HotelId,
                        principalTable: "Hotels",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_HotelImages_HotelId",
                table: "HotelImages",
                column: "HotelId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "HotelImages");

            migrationBuilder.DropColumn(
                name: "CoverImageId",
                table: "Hotels");

            migrationBuilder.AddColumn<string>(
                name: "CoverImage",
                table: "Hotels",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Images",
                table: "Hotels",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
