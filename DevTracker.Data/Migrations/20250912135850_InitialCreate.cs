using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DevTracker.Data.Migrations;

/// <inheritdoc />
public partial class InitialCreate : Migration
{
    /// <inheritdoc />
    protected override void Up(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.CreateTable(
            name: "TaskItems",
            columns: table => new
            {
                Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                Status = table.Column<int>(type: "int", nullable: false),
                Tags = table.Column<string>(type: "nvarchar(max)", nullable: false),
                CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_TaskItems", x => x.Id);
            });

        migrationBuilder.CreateTable(
            name: "Notes",
            columns: table => new
            {
                Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                Content = table.Column<string>(type: "nvarchar(max)", nullable: true),
                CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                TaskItemId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_Notes", x => x.Id);
                table.ForeignKey(
                    name: "FK_Notes_TaskItems_TaskItemId",
                    column: x => x.TaskItemId,
                    principalTable: "TaskItems",
                    principalColumn: "Id");
            });

        migrationBuilder.CreateIndex(
            name: "IX_Notes_TaskItemId",
            table: "Notes",
            column: "TaskItemId");
    }

    /// <inheritdoc />
    protected override void Down(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.DropTable(
            name: "Notes");

        migrationBuilder.DropTable(
            name: "TaskItems");
    }
}
