using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddTablGedrs : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Profiles_Gender_GenderId",
                table: "Profiles");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Gender",
                table: "Gender");

            migrationBuilder.RenameTable(
                name: "Gender",
                newName: "Genders");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Genders",
                table: "Genders",
                column: "IdGender");

            migrationBuilder.AddForeignKey(
                name: "FK_Profiles_Genders_GenderId",
                table: "Profiles",
                column: "GenderId",
                principalTable: "Genders",
                principalColumn: "IdGender",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Profiles_Genders_GenderId",
                table: "Profiles");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Genders",
                table: "Genders");

            migrationBuilder.RenameTable(
                name: "Genders",
                newName: "Gender");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Gender",
                table: "Gender",
                column: "IdGender");

            migrationBuilder.AddForeignKey(
                name: "FK_Profiles_Gender_GenderId",
                table: "Profiles",
                column: "GenderId",
                principalTable: "Gender",
                principalColumn: "IdGender",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
