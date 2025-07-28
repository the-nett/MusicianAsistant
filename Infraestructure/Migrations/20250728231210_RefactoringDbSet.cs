using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class RefactoringDbSet : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AuditLogs_ActionTypes_ActionTypeId",
                table: "AuditLogs");

            migrationBuilder.DropForeignKey(
                name: "FK_Profiles_Genders_GenderId",
                table: "Profiles");

            migrationBuilder.DropForeignKey(
                name: "FK_Songs_Profiles_CreatedBy",
                table: "Songs");

            migrationBuilder.DropForeignKey(
                name: "FK_SongVersionInstrumentPdfs_Instruments_InstrumentId",
                table: "SongVersionInstrumentPdfs");

            migrationBuilder.DropForeignKey(
                name: "FK_SongVersionInstrumentPdfs_SongVersions_VersionId",
                table: "SongVersionInstrumentPdfs");

            migrationBuilder.DropForeignKey(
                name: "FK_SongVersionInstrumentVideos_Instruments_InstrumentId",
                table: "SongVersionInstrumentVideos");

            migrationBuilder.DropForeignKey(
                name: "FK_SongVersions_Profiles_CreatedBy",
                table: "SongVersions");

            migrationBuilder.DropForeignKey(
                name: "FK_UserInstrument_Instruments_InstrumentId",
                table: "UserInstrument");

            migrationBuilder.DropForeignKey(
                name: "FK_UserInstrument_Profiles_UserId",
                table: "UserInstrument");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UserInstrument",
                table: "UserInstrument");

            migrationBuilder.RenameTable(
                name: "UserInstrument",
                newName: "UserInstruments");

            migrationBuilder.RenameIndex(
                name: "IX_UserInstrument_InstrumentId",
                table: "UserInstruments",
                newName: "IX_UserInstruments_InstrumentId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_UserInstruments",
                table: "UserInstruments",
                columns: new[] { "UserId", "InstrumentId" });

            migrationBuilder.AddForeignKey(
                name: "FK_AuditLogs_ActionTypes_ActionTypeId",
                table: "AuditLogs",
                column: "ActionTypeId",
                principalTable: "ActionTypes",
                principalColumn: "ActionTypeId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Profiles_Genders_GenderId",
                table: "Profiles",
                column: "GenderId",
                principalTable: "Genders",
                principalColumn: "IdGender",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Songs_Profiles_CreatedBy",
                table: "Songs",
                column: "CreatedBy",
                principalTable: "Profiles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_SongVersionInstrumentPdfs_Instruments_InstrumentId",
                table: "SongVersionInstrumentPdfs",
                column: "InstrumentId",
                principalTable: "Instruments",
                principalColumn: "InstrumentId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_SongVersionInstrumentPdfs_SongVersions_VersionId",
                table: "SongVersionInstrumentPdfs",
                column: "VersionId",
                principalTable: "SongVersions",
                principalColumn: "VersionId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_SongVersionInstrumentVideos_Instruments_InstrumentId",
                table: "SongVersionInstrumentVideos",
                column: "InstrumentId",
                principalTable: "Instruments",
                principalColumn: "InstrumentId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_SongVersions_Profiles_CreatedBy",
                table: "SongVersions",
                column: "CreatedBy",
                principalTable: "Profiles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_UserInstruments_Instruments_InstrumentId",
                table: "UserInstruments",
                column: "InstrumentId",
                principalTable: "Instruments",
                principalColumn: "InstrumentId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_UserInstruments_Profiles_UserId",
                table: "UserInstruments",
                column: "UserId",
                principalTable: "Profiles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AuditLogs_ActionTypes_ActionTypeId",
                table: "AuditLogs");

            migrationBuilder.DropForeignKey(
                name: "FK_Profiles_Genders_GenderId",
                table: "Profiles");

            migrationBuilder.DropForeignKey(
                name: "FK_Songs_Profiles_CreatedBy",
                table: "Songs");

            migrationBuilder.DropForeignKey(
                name: "FK_SongVersionInstrumentPdfs_Instruments_InstrumentId",
                table: "SongVersionInstrumentPdfs");

            migrationBuilder.DropForeignKey(
                name: "FK_SongVersionInstrumentPdfs_SongVersions_VersionId",
                table: "SongVersionInstrumentPdfs");

            migrationBuilder.DropForeignKey(
                name: "FK_SongVersionInstrumentVideos_Instruments_InstrumentId",
                table: "SongVersionInstrumentVideos");

            migrationBuilder.DropForeignKey(
                name: "FK_SongVersions_Profiles_CreatedBy",
                table: "SongVersions");

            migrationBuilder.DropForeignKey(
                name: "FK_UserInstruments_Instruments_InstrumentId",
                table: "UserInstruments");

            migrationBuilder.DropForeignKey(
                name: "FK_UserInstruments_Profiles_UserId",
                table: "UserInstruments");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UserInstruments",
                table: "UserInstruments");

            migrationBuilder.RenameTable(
                name: "UserInstruments",
                newName: "UserInstrument");

            migrationBuilder.RenameIndex(
                name: "IX_UserInstruments_InstrumentId",
                table: "UserInstrument",
                newName: "IX_UserInstrument_InstrumentId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_UserInstrument",
                table: "UserInstrument",
                columns: new[] { "UserId", "InstrumentId" });

            migrationBuilder.AddForeignKey(
                name: "FK_AuditLogs_ActionTypes_ActionTypeId",
                table: "AuditLogs",
                column: "ActionTypeId",
                principalTable: "ActionTypes",
                principalColumn: "ActionTypeId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Profiles_Genders_GenderId",
                table: "Profiles",
                column: "GenderId",
                principalTable: "Genders",
                principalColumn: "IdGender",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Songs_Profiles_CreatedBy",
                table: "Songs",
                column: "CreatedBy",
                principalTable: "Profiles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_SongVersionInstrumentPdfs_Instruments_InstrumentId",
                table: "SongVersionInstrumentPdfs",
                column: "InstrumentId",
                principalTable: "Instruments",
                principalColumn: "InstrumentId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_SongVersionInstrumentPdfs_SongVersions_VersionId",
                table: "SongVersionInstrumentPdfs",
                column: "VersionId",
                principalTable: "SongVersions",
                principalColumn: "VersionId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_SongVersionInstrumentVideos_Instruments_InstrumentId",
                table: "SongVersionInstrumentVideos",
                column: "InstrumentId",
                principalTable: "Instruments",
                principalColumn: "InstrumentId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_SongVersions_Profiles_CreatedBy",
                table: "SongVersions",
                column: "CreatedBy",
                principalTable: "Profiles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserInstrument_Instruments_InstrumentId",
                table: "UserInstrument",
                column: "InstrumentId",
                principalTable: "Instruments",
                principalColumn: "InstrumentId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserInstrument_Profiles_UserId",
                table: "UserInstrument",
                column: "UserId",
                principalTable: "Profiles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
