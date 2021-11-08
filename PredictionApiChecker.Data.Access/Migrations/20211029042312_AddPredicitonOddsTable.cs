using Microsoft.EntityFrameworkCore.Migrations;

namespace PredictionApiChecker.Data.Access.Migrations
{
    public partial class AddPredicitonOddsTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsExpired",
                table: "PredictionRecords",
                type: "INTEGER",
                nullable: false,
                defaultValue: false);

            migrationBuilder.CreateTable(
                name: "PredicitonOdds",
                columns: table => new
                {
                    Id = table.Column<long>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    PredictionRecordId = table.Column<long>(type: "INTEGER", nullable: false),
                    OddType = table.Column<byte>(type: "INTEGER", nullable: false),
                    Coefficient = table.Column<double>(type: "REAL", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PredicitonOdds", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PredicitonOdds");

            migrationBuilder.DropColumn(
                name: "IsExpired",
                table: "PredictionRecords");
        }
    }
}
