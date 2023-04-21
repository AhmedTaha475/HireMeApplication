using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HireMeDAL.Migrations
{
    /// <inheritdoc />
    public partial class v5 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_projects_projectReviews_PR_Id",
                table: "projects");

            migrationBuilder.DropIndex(
                name: "IX_projects_PR_Id",
                table: "projects");

            migrationBuilder.CreateIndex(
                name: "IX_projectReviews_ProjectId",
                table: "projectReviews",
                column: "ProjectId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_projectReviews_projects_ProjectId",
                table: "projectReviews",
                column: "ProjectId",
                principalTable: "projects",
                principalColumn: "ProjectID",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_projectReviews_projects_ProjectId",
                table: "projectReviews");

            migrationBuilder.DropIndex(
                name: "IX_projectReviews_ProjectId",
                table: "projectReviews");

            migrationBuilder.CreateIndex(
                name: "IX_projects_PR_Id",
                table: "projects",
                column: "PR_Id",
                unique: true,
                filter: "[PR_Id] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_projects_projectReviews_PR_Id",
                table: "projects",
                column: "PR_Id",
                principalTable: "projectReviews",
                principalColumn: "PR_Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
