using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProjectManager.Migrations
{
    /// <inheritdoc />
    public partial class new3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Teams_Tasks_CurrentTaskId",
                table: "Teams");

            migrationBuilder.DropForeignKey(
                name: "FK_Workers_Todos_currentTodoTodoId",
                table: "Workers");

            migrationBuilder.DropIndex(
                name: "IX_Teams_CurrentTaskId",
                table: "Teams");

            migrationBuilder.RenameColumn(
                name: "currentTodoTodoId",
                table: "Workers",
                newName: "CurrentTodoTodoId");

            migrationBuilder.RenameIndex(
                name: "IX_Workers_currentTodoTodoId",
                table: "Workers",
                newName: "IX_Workers_CurrentTodoTodoId");

            migrationBuilder.RenameColumn(
                name: "CurrentTaskId",
                table: "Teams",
                newName: "CurrentTaskTaskId");

            migrationBuilder.CreateIndex(
                name: "IX_Teams_CurrentTaskTaskId",
                table: "Teams",
                column: "CurrentTaskTaskId");

            migrationBuilder.AddForeignKey(
                name: "FK_Teams_Tasks_CurrentTaskTaskId",
                table: "Teams",
                column: "CurrentTaskTaskId",
                principalTable: "Tasks",
                principalColumn: "TaskId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Workers_Todos_CurrentTodoTodoId",
                table: "Workers",
                column: "CurrentTodoTodoId",
                principalTable: "Todos",
                principalColumn: "TodoId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Teams_Tasks_CurrentTaskTaskId",
                table: "Teams");

            migrationBuilder.DropForeignKey(
                name: "FK_Workers_Todos_CurrentTodoTodoId",
                table: "Workers");

            migrationBuilder.DropIndex(
                name: "IX_Teams_CurrentTaskTaskId",
                table: "Teams");

            migrationBuilder.RenameColumn(
                name: "CurrentTodoTodoId",
                table: "Workers",
                newName: "currentTodoTodoId");

            migrationBuilder.RenameIndex(
                name: "IX_Workers_CurrentTodoTodoId",
                table: "Workers",
                newName: "IX_Workers_currentTodoTodoId");

            migrationBuilder.RenameColumn(
                name: "CurrentTaskTaskId",
                table: "Teams",
                newName: "CurrentTaskId");

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

            migrationBuilder.AddForeignKey(
                name: "FK_Workers_Todos_currentTodoTodoId",
                table: "Workers",
                column: "currentTodoTodoId",
                principalTable: "Todos",
                principalColumn: "TodoId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
