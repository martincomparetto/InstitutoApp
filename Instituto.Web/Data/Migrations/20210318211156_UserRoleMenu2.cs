using Microsoft.EntityFrameworkCore.Migrations;

namespace Instituto.Web.Data.Migrations
{
    public partial class UserRoleMenu2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Menus_UsersRolesMenus_UserRoleMenuID",
                table: "Menus");

            migrationBuilder.DropForeignKey(
                name: "FK_UsersRolesMenus_AspNetRoles_RoleId",
                table: "UsersRolesMenus");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UsersRolesMenus",
                table: "UsersRolesMenus");

            migrationBuilder.RenameTable(
                name: "UsersRolesMenus",
                newName: "UserRoleMenu");

            migrationBuilder.RenameIndex(
                name: "IX_UsersRolesMenus_RoleId",
                table: "UserRoleMenu",
                newName: "IX_UserRoleMenu_RoleId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_UserRoleMenu",
                table: "UserRoleMenu",
                column: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_Menus_UserRoleMenu_UserRoleMenuID",
                table: "Menus",
                column: "UserRoleMenuID",
                principalTable: "UserRoleMenu",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_UserRoleMenu_AspNetRoles_RoleId",
                table: "UserRoleMenu",
                column: "RoleId",
                principalTable: "AspNetRoles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Menus_UserRoleMenu_UserRoleMenuID",
                table: "Menus");

            migrationBuilder.DropForeignKey(
                name: "FK_UserRoleMenu_AspNetRoles_RoleId",
                table: "UserRoleMenu");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UserRoleMenu",
                table: "UserRoleMenu");

            migrationBuilder.RenameTable(
                name: "UserRoleMenu",
                newName: "UsersRolesMenus");

            migrationBuilder.RenameIndex(
                name: "IX_UserRoleMenu_RoleId",
                table: "UsersRolesMenus",
                newName: "IX_UsersRolesMenus_RoleId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_UsersRolesMenus",
                table: "UsersRolesMenus",
                column: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_Menus_UsersRolesMenus_UserRoleMenuID",
                table: "Menus",
                column: "UserRoleMenuID",
                principalTable: "UsersRolesMenus",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_UsersRolesMenus_AspNetRoles_RoleId",
                table: "UsersRolesMenus",
                column: "RoleId",
                principalTable: "AspNetRoles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
