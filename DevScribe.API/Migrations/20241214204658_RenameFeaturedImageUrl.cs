using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DevScribe.API.Migrations
{
    /// <inheritdoc />
    public partial class RenameFeaturedImageUrl : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "FeaturedUImageUrl",
                table: "BlogPosts",
                newName: "FeaturedImageUrl");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "FeaturedImageUrl",
                table: "BlogPosts",
                newName: "FeaturedUImageUrl");
        }
    }
}
