using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Fall2024_Assignment3_bhnguyen2.Data.Migrations
{
    /// <inheritdoc />
    public partial class IMDb : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IMBD",
                table: "Movie");

            migrationBuilder.DropColumn(
                name: "IMBD",
                table: "Actor");

            migrationBuilder.AddColumn<string>(
                name: "IMDb",
                table: "Movie",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "IMDb",
                table: "Actor",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IMDb",
                table: "Movie");

            migrationBuilder.DropColumn(
                name: "IMDb",
                table: "Actor");

            migrationBuilder.AddColumn<string>(
                name: "IMBD",
                table: "Movie",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "IMBD",
                table: "Actor",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
