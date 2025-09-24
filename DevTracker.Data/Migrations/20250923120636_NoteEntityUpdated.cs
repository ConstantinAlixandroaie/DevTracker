using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DevTracker.Data.Migrations
{
    /// <inheritdoc />
    public partial class NoteEntityUpdated : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<long>(
                name: "UpdatedById",
                table: "Notes",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.CreateIndex(
                name: "IX_Tags_Name_Colour",
                table: "Tags",
                columns: new[] { "Name", "Colour" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Notes_UpdatedById",
                table: "Notes",
                column: "UpdatedById");

            migrationBuilder.AddForeignKey(
                name: "FK_Notes_AspNetUsers_UpdatedById",
                table: "Notes",
                column: "UpdatedById",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Notes_AspNetUsers_UpdatedById",
                table: "Notes");

            migrationBuilder.DropIndex(
                name: "IX_Tags_Name_Colour",
                table: "Tags");

            migrationBuilder.DropIndex(
                name: "IX_Notes_UpdatedById",
                table: "Notes");

            migrationBuilder.DropColumn(
                name: "UpdatedById",
                table: "Notes");
        }
    }
}
