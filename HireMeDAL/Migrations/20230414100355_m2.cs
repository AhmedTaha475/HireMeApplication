using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HireMeDAL.Migrations
{
    /// <inheritdoc />
    public partial class m2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_lookupValues_PaymentMethodId",
                table: "AspNetUsers");

            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_plans_PlanId",
                table: "AspNetUsers");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_lookupValues_PaymentMethodId",
                table: "AspNetUsers",
                column: "PaymentMethodId",
                principalTable: "lookupValues",
                principalColumn: "ValueId");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_plans_PlanId",
                table: "AspNetUsers",
                column: "PlanId",
                principalTable: "plans",
                principalColumn: "id");
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
    }
}
