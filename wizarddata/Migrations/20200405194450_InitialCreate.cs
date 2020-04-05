using Microsoft.EntityFrameworkCore.Migrations;

namespace wizarddata.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Dispositions",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(maxLength: 100, nullable: true),
                    Category = table.Column<string>(nullable: true),
                    Discipline = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Dispositions", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Dispositions",
                columns: new[] { "Id", "Category", "Description", "Discipline", "Name" },
                values: new object[] { 1, "Habits", "With Initiative (Nwokeji, Stachel, & Holmes, 2019) / Self-Starter (Clear, 2017) Shows independence. Ability to assess and start activities independently without needing to be told what to do. Willing to take the lead, not waiting for others to start activities or wait for instructions.", "Information Systems", "Proactive" });

            migrationBuilder.InsertData(
                table: "Dispositions",
                columns: new[] { "Id", "Category", "Description", "Discipline", "Name" },
                values: new object[] { 2, "Qualities", "Purposefully engaged / Purposefulness (Nwokeji et al., 2019), (Clear, 2017) Goal-directed, intentionally acting and committed to achieve organizational and project goals. Reflects an attitude towards the organizational goals served by decisions, work or work products. e.g., Business acumen.", "Information Systems", "Purpose-Driven" });

            migrationBuilder.InsertData(
                table: "Dispositions",
                columns: new[] { "Id", "Category", "Description", "Discipline", "Name" },
                values: new object[] { 3, "Qualities", "Self-motivated (Clear, 2017) / Self-Directed (Nwokeji et al., 2019) Demonstrates determination to sustain efforts to continue tasks. Direction from others is not required to continue a task toward its desired ends.", "Information Systems", "Self-Directed" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Dispositions");
        }
    }
}
