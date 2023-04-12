using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HireMeDAL.Migrations
{
    /// <inheritdoc />
    public partial class v3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_lookupValues_PlanId",
                table: "AspNetUsers");

            migrationBuilder.CreateTable(
                name: "plans",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_plans", x => x.id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_PaymentMethodId",
                table: "AspNetUsers",
                column: "PaymentMethodId");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_lookupValues_PaymentMethodId",
                table: "AspNetUsers",
                column: "PaymentMethodId",
                principalTable: "lookupValues",
                principalColumn: "ValueId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_plans_PlanId",
                table: "AspNetUsers",
                column: "PlanId",
                principalTable: "plans",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_lookupValues_PaymentMethodId",
                table: "AspNetUsers");

            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_plans_PlanId",
                table: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "plans");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_PaymentMethodId",
                table: "AspNetUsers");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_lookupValues_PlanId",
                table: "AspNetUsers",
                column: "PlanId",
                principalTable: "lookupValues",
                principalColumn: "ValueId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
