using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HireMeDAL.Migrations
{
    /// <inheritdoc />
    public partial class v2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_projects_PR_Id",
                table: "projects");

            migrationBuilder.AlterColumn<int>(
                name: "PR_Id",
                table: "projects",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.CreateIndex(
                name: "IX_projects_PR_Id",
                table: "projects",
                column: "PR_Id",
                unique: true,
                filter: "[PR_Id] IS NOT NULL");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_projects_PR_Id",
                table: "projects");

            migrationBuilder.AlterColumn<int>(
                name: "PR_Id",
                table: "projects",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_projects_PR_Id",
                table: "projects",
                column: "PR_Id",
                unique: true);
        }
    }
}
