using Microsoft.EntityFrameworkCore.Migrations;

namespace TrackAnalyser.DataAccess.Migrations
{
    public partial class AddTrackToTrackEmission : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "TrackId",
                table: "TrackEmissions",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_TrackEmissions_TrackId",
                table: "TrackEmissions",
                column: "TrackId");

            migrationBuilder.AddForeignKey(
                name: "FK_TrackEmissions_Tracks_TrackId",
                table: "TrackEmissions",
                column: "TrackId",
                principalTable: "Tracks",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TrackEmissions_Tracks_TrackId",
                table: "TrackEmissions");

            migrationBuilder.DropIndex(
                name: "IX_TrackEmissions_TrackId",
                table: "TrackEmissions");

            migrationBuilder.DropColumn(
                name: "TrackId",
                table: "TrackEmissions");
        }
    }
}
