using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Midis.Data.Migrations
{
    /// <inheritdoc />
    public partial class UpdateSchedule : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DataOfTheWeek",
                table: "Schedules");

            migrationBuilder.AddColumn<int>(
                name: "DayOfTheWeek",
                table: "Schedules",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DayOfTheWeek",
                table: "Schedules");

            migrationBuilder.AddColumn<DateOnly>(
                name: "DataOfTheWeek",
                table: "Schedules",
                type: "date",
                nullable: false,
                defaultValue: new DateOnly(1, 1, 1));
        }
    }
}
