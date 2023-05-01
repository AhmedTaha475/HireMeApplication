using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HireMeDAL.Migrations
{
    /// <inheritdoc />
    public partial class v8 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "ProjectPostDate",
                table: "projectPosts",
                type: "datetime2",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ProjectPostDate",
                table: "projectPosts");
        }
    }
}
