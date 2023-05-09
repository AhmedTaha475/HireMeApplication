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
                name: "FK_projectReviews_projects_ProjectId",
                table: "projectReviews");

            migrationBuilder.AddForeignKey(
                name: "FK_projectReviews_projectPosts_ProjectId",
                table: "projectReviews",
                column: "ProjectId",
                principalTable: "projectPosts",
                principalColumn: "Pp_Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_projectReviews_projectPosts_ProjectId",
                table: "projectReviews");

            migrationBuilder.AddForeignKey(
                name: "FK_projectReviews_projects_ProjectId",
                table: "projectReviews",
                column: "ProjectId",
                principalTable: "projects",
                principalColumn: "ProjectID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
