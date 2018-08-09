using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace dateOptimizer.data.Migrations
{
    public partial class AppraisalPercentages : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AppraisalPercentages",
                columns: table => new
                {
                    Fip = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    Day0 = table.Column<double>(nullable: false),
                    Day1 = table.Column<double>(nullable: false),
                    Day2 = table.Column<double>(nullable: false),
                    Day3 = table.Column<double>(nullable: false),
                    Day4 = table.Column<double>(nullable: false),
                    Day5 = table.Column<double>(nullable: false),
                    Day6 = table.Column<double>(nullable: false),
                    Day7 = table.Column<double>(nullable: false),
                    Day8 = table.Column<double>(nullable: false),
                    Day9 = table.Column<double>(nullable: false),
                    Day10 = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AppraisalPercentages", x => x.Fip);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AppraisalPercentages");
        }
    }
}
