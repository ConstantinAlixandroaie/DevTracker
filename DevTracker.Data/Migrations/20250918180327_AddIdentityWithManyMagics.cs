using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DevTracker.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddIdentityWithManyMagics : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tags_TaskItems_TaskItemId",
                table: "Tags");

            migrationBuilder.AlterColumn<string>(
                name: "Title",
                table: "TaskItems",
                type: "nvarchar(255)",
                maxLength: 255,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<long>(
                name: "AssigneeId",
                table: "TaskItems",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<long>(
                name: "CreatedById",
                table: "TaskItems",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "TaskItems",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AlterColumn<long>(
                name: "TaskItemId",
                table: "Tags",
                type: "bigint",
                nullable: true,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Tags",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<string>(
                name: "Colour",
                table: "Tags",
                type: "nvarchar(9)",
                maxLength: 9,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<long>(
                name: "CreatedById",
                table: "Notes",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AlterColumn<string>(
                name: "Title",
                table: "Boards",
                type: "nvarchar(255)",
                maxLength: 255,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<long>(
                name: "CreatedById",
                table: "Boards",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<long>(
                name: "OwnerId",
                table: "Boards",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<long>(
                name: "BoardId",
                table: "AspNetUsers",
                type: "bigint",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_TaskItems_AssigneeId",
                table: "TaskItems",
                column: "AssigneeId");

            migrationBuilder.CreateIndex(
                name: "IX_TaskItems_CreatedById",
                table: "TaskItems",
                column: "CreatedById");

            migrationBuilder.CreateIndex(
                name: "IX_Notes_CreatedById",
                table: "Notes",
                column: "CreatedById");

            migrationBuilder.CreateIndex(
                name: "IX_Boards_CreatedById",
                table: "Boards",
                column: "CreatedById");

            migrationBuilder.CreateIndex(
                name: "IX_Boards_OwnerId",
                table: "Boards",
                column: "OwnerId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_BoardId",
                table: "AspNetUsers",
                column: "BoardId");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_Boards_BoardId",
                table: "AspNetUsers",
                column: "BoardId",
                principalTable: "Boards",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Boards_AspNetUsers_CreatedById",
                table: "Boards",
                column: "CreatedById",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Boards_AspNetUsers_OwnerId",
                table: "Boards",
                column: "OwnerId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Notes_AspNetUsers_CreatedById",
                table: "Notes",
                column: "CreatedById",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Tags_TaskItems_TaskItemId",
                table: "Tags",
                column: "TaskItemId",
                principalTable: "TaskItems",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_TaskItems_AspNetUsers_AssigneeId",
                table: "TaskItems",
                column: "AssigneeId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_TaskItems_AspNetUsers_CreatedById",
                table: "TaskItems",
                column: "CreatedById",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_Boards_BoardId",
                table: "AspNetUsers");

            migrationBuilder.DropForeignKey(
                name: "FK_Boards_AspNetUsers_CreatedById",
                table: "Boards");

            migrationBuilder.DropForeignKey(
                name: "FK_Boards_AspNetUsers_OwnerId",
                table: "Boards");

            migrationBuilder.DropForeignKey(
                name: "FK_Notes_AspNetUsers_CreatedById",
                table: "Notes");

            migrationBuilder.DropForeignKey(
                name: "FK_Tags_TaskItems_TaskItemId",
                table: "Tags");

            migrationBuilder.DropForeignKey(
                name: "FK_TaskItems_AspNetUsers_AssigneeId",
                table: "TaskItems");

            migrationBuilder.DropForeignKey(
                name: "FK_TaskItems_AspNetUsers_CreatedById",
                table: "TaskItems");

            migrationBuilder.DropIndex(
                name: "IX_TaskItems_AssigneeId",
                table: "TaskItems");

            migrationBuilder.DropIndex(
                name: "IX_TaskItems_CreatedById",
                table: "TaskItems");

            migrationBuilder.DropIndex(
                name: "IX_Notes_CreatedById",
                table: "Notes");

            migrationBuilder.DropIndex(
                name: "IX_Boards_CreatedById",
                table: "Boards");

            migrationBuilder.DropIndex(
                name: "IX_Boards_OwnerId",
                table: "Boards");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_BoardId",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "AssigneeId",
                table: "TaskItems");

            migrationBuilder.DropColumn(
                name: "CreatedById",
                table: "TaskItems");

            migrationBuilder.DropColumn(
                name: "Description",
                table: "TaskItems");

            migrationBuilder.DropColumn(
                name: "Colour",
                table: "Tags");

            migrationBuilder.DropColumn(
                name: "CreatedById",
                table: "Notes");

            migrationBuilder.DropColumn(
                name: "CreatedById",
                table: "Boards");

            migrationBuilder.DropColumn(
                name: "OwnerId",
                table: "Boards");

            migrationBuilder.DropColumn(
                name: "BoardId",
                table: "AspNetUsers");

            migrationBuilder.AlterColumn<string>(
                name: "Title",
                table: "TaskItems",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(255)",
                oldMaxLength: 255);

            migrationBuilder.AlterColumn<long>(
                name: "TaskItemId",
                table: "Tags",
                type: "bigint",
                nullable: false,
                defaultValue: 0L,
                oldClrType: typeof(long),
                oldType: "bigint",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Tags",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50);

            migrationBuilder.AlterColumn<string>(
                name: "Title",
                table: "Boards",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(255)",
                oldMaxLength: 255);

            migrationBuilder.AddForeignKey(
                name: "FK_Tags_TaskItems_TaskItemId",
                table: "Tags",
                column: "TaskItemId",
                principalTable: "TaskItems",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
