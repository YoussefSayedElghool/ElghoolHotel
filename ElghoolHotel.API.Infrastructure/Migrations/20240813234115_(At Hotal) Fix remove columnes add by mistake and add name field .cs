using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ElghoolHotel.API.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AtHotalFixremovecolumnesaddbymistakeandaddnamefield : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UserImageUrl",
                table: "Hotels");

            migrationBuilder.RenameColumn(
                name: "UserReview",
                table: "Hotels",
                newName: "Name");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Hotels",
                newName: "UserReview");

            migrationBuilder.AddColumn<string>(
                name: "UserImageUrl",
                table: "Hotels",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
