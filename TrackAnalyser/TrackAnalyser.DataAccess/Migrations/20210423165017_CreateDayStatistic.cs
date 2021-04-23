using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TrackAnalyser.DataAccess.Migrations
{
    public partial class CreateDayStatistic : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PlayedTimes",
                table: "TrackStatistics");

            migrationBuilder.CreateTable(
                name: "DayStatistics",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Day = table.Column<DateTime>(type: "datetime2", nullable: false),
                    PlayedTimes = table.Column<int>(type: "int", nullable: false),
                    TrackStatisticId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DayStatistics", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DayStatistics_TrackStatistics_TrackStatisticId",
                        column: x => x.TrackStatisticId,
                        principalTable: "TrackStatistics",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_DayStatistics_TrackStatisticId",
                table: "DayStatistics",
                column: "TrackStatisticId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DayStatistics");

            migrationBuilder.AddColumn<int>(
                name: "PlayedTimes",
                table: "TrackStatistics",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
