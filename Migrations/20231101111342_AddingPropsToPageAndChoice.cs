using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace redimel_server.Migrations
{
    /// <inheritdoc />
    public partial class AddingPropsToPageAndChoice : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ChangeNotices",
                table: "Pages",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<bool>(
                name: "IsUniqueChoice",
                table: "Choices",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ChangeNotices",
                table: "Pages");

            migrationBuilder.DropColumn(
                name: "IsUniqueChoice",
                table: "Choices");
        }
    }
}
