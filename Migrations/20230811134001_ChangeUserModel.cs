using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace redimel_server.Migrations
{
    /// <inheritdoc />
    public partial class ChangeUserModel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Users_GroupWests_GroupWestId",
                table: "Users");

            migrationBuilder.DropForeignKey(
                name: "FK_Users_Redimels_RedimelId",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "CurrentUserId",
                table: "Users");

            migrationBuilder.AlterColumn<Guid>(
                name: "RedimelId",
                table: "Users",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "GroupWestId",
                table: "Users",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CurrentUserEmail",
                table: "Users",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddForeignKey(
                name: "FK_Users_GroupWests_GroupWestId",
                table: "Users",
                column: "GroupWestId",
                principalTable: "GroupWests",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Users_Redimels_RedimelId",
                table: "Users",
                column: "RedimelId",
                principalTable: "Redimels",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Users_GroupWests_GroupWestId",
                table: "Users");

            migrationBuilder.DropForeignKey(
                name: "FK_Users_Redimels_RedimelId",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "CurrentUserEmail",
                table: "Users");

            migrationBuilder.AlterColumn<Guid>(
                name: "RedimelId",
                table: "Users",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AlterColumn<Guid>(
                name: "GroupWestId",
                table: "Users",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AddColumn<string>(
                name: "CurrentUserId",
                table: "Users",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Users_GroupWests_GroupWestId",
                table: "Users",
                column: "GroupWestId",
                principalTable: "GroupWests",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Users_Redimels_RedimelId",
                table: "Users",
                column: "RedimelId",
                principalTable: "Redimels",
                principalColumn: "Id");
        }
    }
}
