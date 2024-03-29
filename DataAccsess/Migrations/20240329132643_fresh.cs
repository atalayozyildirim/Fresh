using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccsess.Migrations
{
    /// <inheritdoc />
    public partial class fresh : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "image",
                table: "Post",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "url",
                table: "Post",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "image",
                table: "Post");

            migrationBuilder.DropColumn(
                name: "url",
                table: "Post");
        }
    }
}
