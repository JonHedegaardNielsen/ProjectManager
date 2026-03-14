using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProjectManager.Migrations
{
    /// <inheritdoc />
    public partial class new2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Teams_Tasks_CurrentTaskId",
                table: "Teams");

            migrationBuilder.DropIndex(
                name: "IX_Teams_CurrentTaskId",
                table: "Teams");

            migrationBuilder.CreateIndex(
                name: "IX_Teams_CurrentTaskId",
                table: "Teams",
                column: "CurrentTaskId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Teams_Tasks_CurrentTaskId",
                table: "Teams",
                column: "CurrentTaskId",
                principalTable: "Tasks",
                principalColumn: "TaskId",
                onDelete: ReferentialAction.SetNull);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Teams_Tasks_CurrentTaskId",
                table: "Teams");

            migrationBuilder.DropIndex(
                name: "IX_Teams_CurrentTaskId",
                table: "Teams");

            migrationBuilder.CreateIndex(
                name: "IX_Teams_CurrentTaskId",
                table: "Teams",
                column: "CurrentTaskId");

            migrationBuilder.AddForeignKey(
                name: "FK_Teams_Tasks_CurrentTaskId",
                table: "Teams",
                column: "CurrentTaskId",
                principalTable: "Tasks",
                principalColumn: "TaskId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
