using Microsoft.EntityFrameworkCore.Migrations;

namespace PredictionApiChecker.Data.Access.Migrations
{
    public partial class RenameLastUpdateColumnFromPredictionRecordsTableToLastUpdateAt : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "LastUpdateDate",
                table: "PredictionRecords",
                newName: "LastUpdateAt");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "LastUpdateAt",
                table: "PredictionRecords",
                newName: "LastUpdateDate");
        }
    }
}
