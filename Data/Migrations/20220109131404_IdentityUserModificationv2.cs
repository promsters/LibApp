using Microsoft.EntityFrameworkCore.Migrations;

namespace LibApp.Data.Migrations
{
    public partial class IdentityUserModificationv2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                table: "AspNetUserClaims");

            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                table: "AspNetUserLogins");

            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                table: "AspNetUserRoles");

            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_MembershipTypes_MembershipTypeId",
                table: "AspNetUsers");

            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                table: "AspNetUserTokens");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AspNetUsers",
                table: "AspNetUsers");

            migrationBuilder.EnsureSchema(
                name: "dbo");

            migrationBuilder.RenameTable(
                name: "AspNetUsers",
                newName: "Customers",
                newSchema: "dbo");

            migrationBuilder.RenameColumn(
                name: "Id",
                schema: "dbo",
                table: "Customers",
                newName: "CustomerId");

            migrationBuilder.RenameIndex(
                name: "IX_AspNetUsers_MembershipTypeId",
                schema: "dbo",
                table: "Customers",
                newName: "IX_Customers_MembershipTypeId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Customers",
                schema: "dbo",
                table: "Customers",
                column: "CustomerId");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUserClaims_Customers_UserId",
                table: "AspNetUserClaims",
                column: "UserId",
                principalSchema: "dbo",
                principalTable: "Customers",
                principalColumn: "CustomerId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUserLogins_Customers_UserId",
                table: "AspNetUserLogins",
                column: "UserId",
                principalSchema: "dbo",
                principalTable: "Customers",
                principalColumn: "CustomerId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUserRoles_Customers_UserId",
                table: "AspNetUserRoles",
                column: "UserId",
                principalSchema: "dbo",
                principalTable: "Customers",
                principalColumn: "CustomerId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUserTokens_Customers_UserId",
                table: "AspNetUserTokens",
                column: "UserId",
                principalSchema: "dbo",
                principalTable: "Customers",
                principalColumn: "CustomerId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Customers_MembershipTypes_MembershipTypeId",
                schema: "dbo",
                table: "Customers",
                column: "MembershipTypeId",
                principalTable: "MembershipTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUserClaims_Customers_UserId",
                table: "AspNetUserClaims");

            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUserLogins_Customers_UserId",
                table: "AspNetUserLogins");

            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUserRoles_Customers_UserId",
                table: "AspNetUserRoles");

            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUserTokens_Customers_UserId",
                table: "AspNetUserTokens");

            migrationBuilder.DropForeignKey(
                name: "FK_Customers_MembershipTypes_MembershipTypeId",
                schema: "dbo",
                table: "Customers");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Customers",
                schema: "dbo",
                table: "Customers");

            migrationBuilder.RenameTable(
                name: "Customers",
                schema: "dbo",
                newName: "AspNetUsers");

            migrationBuilder.RenameColumn(
                name: "CustomerId",
                table: "AspNetUsers",
                newName: "Id");

            migrationBuilder.RenameIndex(
                name: "IX_Customers_MembershipTypeId",
                table: "AspNetUsers",
                newName: "IX_AspNetUsers_MembershipTypeId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_AspNetUsers",
                table: "AspNetUsers",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                table: "AspNetUserClaims",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                table: "AspNetUserLogins",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                table: "AspNetUserRoles",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_MembershipTypes_MembershipTypeId",
                table: "AspNetUsers",
                column: "MembershipTypeId",
                principalTable: "MembershipTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                table: "AspNetUserTokens",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
