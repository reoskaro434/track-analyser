using Microsoft.EntityFrameworkCore.Migrations;

namespace TrackAnalyser.DataAccess.Migrations
{
    public partial class UpdateForeignKeysForTables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DayStatistics_TrackStatistics_TrackStatisticId",
                table: "DayStatistics");

            migrationBuilder.DropForeignKey(
                name: "FK_TrackEmissions_Canals_CanalId",
                table: "TrackEmissions");

            migrationBuilder.DropForeignKey(
                name: "FK_TrackEmissions_Tracks_TrackId",
                table: "TrackEmissions");

            migrationBuilder.DropForeignKey(
                name: "FK_Tracks_Artists_ArtistId",
                table: "Tracks");

            migrationBuilder.DropForeignKey(
                name: "FK_TrackStatistics_Canals_CanalId",
                table: "TrackStatistics");

            migrationBuilder.DropForeignKey(
                name: "FK_TrackStatistics_Tracks_TrackId",
                table: "TrackStatistics");

            migrationBuilder.AlterColumn<int>(
                name: "TrackId",
                table: "TrackStatistics",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "CanalId",
                table: "TrackStatistics",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "ArtistId",
                table: "Tracks",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "TrackId",
                table: "TrackEmissions",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "CanalId",
                table: "TrackEmissions",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "TrackStatisticId",
                table: "DayStatistics",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_DayStatistics_TrackStatistics_TrackStatisticId",
                table: "DayStatistics",
                column: "TrackStatisticId",
                principalTable: "TrackStatistics",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TrackEmissions_Canals_CanalId",
                table: "TrackEmissions",
                column: "CanalId",
                principalTable: "Canals",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TrackEmissions_Tracks_TrackId",
                table: "TrackEmissions",
                column: "TrackId",
                principalTable: "Tracks",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Tracks_Artists_ArtistId",
                table: "Tracks",
                column: "ArtistId",
                principalTable: "Artists",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TrackStatistics_Canals_CanalId",
                table: "TrackStatistics",
                column: "CanalId",
                principalTable: "Canals",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TrackStatistics_Tracks_TrackId",
                table: "TrackStatistics",
                column: "TrackId",
                principalTable: "Tracks",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DayStatistics_TrackStatistics_TrackStatisticId",
                table: "DayStatistics");

            migrationBuilder.DropForeignKey(
                name: "FK_TrackEmissions_Canals_CanalId",
                table: "TrackEmissions");

            migrationBuilder.DropForeignKey(
                name: "FK_TrackEmissions_Tracks_TrackId",
                table: "TrackEmissions");

            migrationBuilder.DropForeignKey(
                name: "FK_Tracks_Artists_ArtistId",
                table: "Tracks");

            migrationBuilder.DropForeignKey(
                name: "FK_TrackStatistics_Canals_CanalId",
                table: "TrackStatistics");

            migrationBuilder.DropForeignKey(
                name: "FK_TrackStatistics_Tracks_TrackId",
                table: "TrackStatistics");

            migrationBuilder.AlterColumn<int>(
                name: "TrackId",
                table: "TrackStatistics",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "CanalId",
                table: "TrackStatistics",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "ArtistId",
                table: "Tracks",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "TrackId",
                table: "TrackEmissions",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "CanalId",
                table: "TrackEmissions",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "TrackStatisticId",
                table: "DayStatistics",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_DayStatistics_TrackStatistics_TrackStatisticId",
                table: "DayStatistics",
                column: "TrackStatisticId",
                principalTable: "TrackStatistics",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_TrackEmissions_Canals_CanalId",
                table: "TrackEmissions",
                column: "CanalId",
                principalTable: "Canals",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_TrackEmissions_Tracks_TrackId",
                table: "TrackEmissions",
                column: "TrackId",
                principalTable: "Tracks",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Tracks_Artists_ArtistId",
                table: "Tracks",
                column: "ArtistId",
                principalTable: "Artists",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_TrackStatistics_Canals_CanalId",
                table: "TrackStatistics",
                column: "CanalId",
                principalTable: "Canals",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_TrackStatistics_Tracks_TrackId",
                table: "TrackStatistics",
                column: "TrackId",
                principalTable: "Tracks",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
