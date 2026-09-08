using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ToDoApp.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddedTaskCategories : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "TaskCategoriesId",
                table: "Tasks",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Work" },
                    { 2, "Personal" },
                    { 3, "Shopping" },
                    { 4, "Health" },
                    { 5, "Finance" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Tasks_TaskCategoriesId",
                table: "Tasks",
                column: "TaskCategoriesId");

            migrationBuilder.AddForeignKey(
                name: "FK_Tasks_Categories_TaskCategoriesId",
                table: "Tasks",
                column: "TaskCategoriesId",
                principalTable: "Categories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tasks_Categories_TaskCategoriesId",
                table: "Tasks");

            migrationBuilder.DropTable(
                name: "Categories");

            migrationBuilder.DropIndex(
                name: "IX_Tasks_TaskCategoriesId",
                table: "Tasks");

            migrationBuilder.DropColumn(
                name: "TaskCategoriesId",
                table: "Tasks");
        }
    }
}
