using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace PredictionApiChecker.Data.Access.Migrations
{
    public partial class AddPredictionsCoefficientColumnToPredictionRecordsTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<double>(
                name: "PredictionCoefficient",
                table: "PredictionRecords",
                type: "REAL",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PredictionCoefficient",
                table: "PredictionRecords");
        }
    }
}
