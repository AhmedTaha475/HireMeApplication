using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HireMeDAL.Migrations
{
    /// <inheritdoc />
    public partial class v6 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_portfolios_FreelancerId",
                table: "portfolios");

            migrationBuilder.DropColumn(
                name: "PR_Id",
                table: "projects");

            migrationBuilder.DropColumn(
                name: "PortfolioId",
                table: "AspNetUsers");

            migrationBuilder.AlterColumn<string>(
                name: "FreelancerId",
                table: "portfolios",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_portfolios_FreelancerId",
                table: "portfolios",
                column: "FreelancerId",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_portfolios_FreelancerId",
                table: "portfolios");

            migrationBuilder.AddColumn<int>(
                name: "PR_Id",
                table: "projects",
                type: "int",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "FreelancerId",
                table: "portfolios",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AddColumn<int>(
                name: "PortfolioId",
                table: "AspNetUsers",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_portfolios_FreelancerId",
                table: "portfolios",
                column: "FreelancerId",
                unique: true,
                filter: "[FreelancerId] IS NOT NULL");
        }
    }
}
