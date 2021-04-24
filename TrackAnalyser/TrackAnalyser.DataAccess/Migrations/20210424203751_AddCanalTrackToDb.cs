using Microsoft.EntityFrameworkCore.Migrations;

namespace TrackAnalyser.DataAccess.Migrations
{
    public partial class AddCanalTrackToDb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CanalTracks",
                columns: table => new
                {
                    CanalId = table.Column<int>(type: "int", nullable: false),
                    TrackId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CanalTracks", x => new { x.CanalId, x.TrackId });
                    table.ForeignKey(
                        name: "FK_CanalTracks_Canals_CanalId",
                        column: x => x.CanalId,
                        principalTable: "Canals",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CanalTracks_Tracks_TrackId",
                        column: x => x.TrackId,
                        principalTable: "Tracks",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CanalTracks_TrackId",
                table: "CanalTracks",
                column: "TrackId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CanalTracks");
        }
    }
}
