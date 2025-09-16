using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DevTracker.Data.Migrations
{
    /// <inheritdoc />
    public partial class _202501609_Updates : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Notes_TaskItems_TaskItemId",
                table: "Notes");

            migrationBuilder.AlterColumn<long>(
                name: "TaskItemId",
                table: "Notes",
                type: "bigint",
                nullable: false,
                defaultValue: 0L,
                oldClrType: typeof(long),
                oldType: "bigint",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Content",
                table: "Notes",
                type: "nvarchar(2000)",
                maxLength: 2000,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Notes_TaskItems_TaskItemId",
                table: "Notes",
                column: "TaskItemId",
                principalTable: "TaskItems",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Notes_TaskItems_TaskItemId",
                table: "Notes");

            migrationBuilder.AlterColumn<long>(
                name: "TaskItemId",
                table: "Notes",
                type: "bigint",
                nullable: true,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.AlterColumn<string>(
                name: "Content",
                table: "Notes",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(2000)",
                oldMaxLength: 2000);

            migrationBuilder.AddForeignKey(
                name: "FK_Notes_TaskItems_TaskItemId",
                table: "Notes",
                column: "TaskItemId",
                principalTable: "TaskItems",
                principalColumn: "Id");
        }
    }
}
