using Microsoft.EntityFrameworkCore.Migrations;

namespace LibApp.Data.Migrations
{
    public partial class IdentityUserModificationv3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                table: "AspNetUserRoles");

            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUserRoles_Customers_UserId",
                table: "AspNetUserRoles");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AspNetUserRoles",
                table: "AspNetUserRoles");

            migrationBuilder.RenameTable(
                name: "AspNetUserRoles",
                newName: "CustomerRoles");

            migrationBuilder.RenameIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "CustomerRoles",
                newName: "IX_CustomerRoles_RoleId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CustomerRoles",
                table: "CustomerRoles",
                columns: new[] { "UserId", "RoleId" });

            migrationBuilder.AddForeignKey(
                name: "FK_CustomerRoles_AspNetRoles_RoleId",
                table: "CustomerRoles",
                column: "RoleId",
                principalTable: "AspNetRoles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CustomerRoles_Customers_UserId",
                table: "CustomerRoles",
                column: "UserId",
                principalSchema: "dbo",
                principalTable: "Customers",
                principalColumn: "CustomerId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CustomerRoles_AspNetRoles_RoleId",
                table: "CustomerRoles");

            migrationBuilder.DropForeignKey(
                name: "FK_CustomerRoles_Customers_UserId",
                table: "CustomerRoles");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CustomerRoles",
                table: "CustomerRoles");

            migrationBuilder.RenameTable(
                name: "CustomerRoles",
                newName: "AspNetUserRoles");

            migrationBuilder.RenameIndex(
                name: "IX_CustomerRoles_RoleId",
                table: "AspNetUserRoles",
                newName: "IX_AspNetUserRoles_RoleId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_AspNetUserRoles",
                table: "AspNetUserRoles",
                columns: new[] { "UserId", "RoleId" });

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId",
                principalTable: "AspNetRoles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUserRoles_Customers_UserId",
                table: "AspNetUserRoles",
                column: "UserId",
                principalSchema: "dbo",
                principalTable: "Customers",
                principalColumn: "CustomerId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
