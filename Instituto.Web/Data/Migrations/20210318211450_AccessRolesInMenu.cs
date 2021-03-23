using Microsoft.EntityFrameworkCore.Migrations;

namespace Instituto.Web.Data.Migrations
{
    public partial class AccessRolesInMenu : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Menus_UserRoleMenu_UserRoleMenuID",
                table: "Menus");

            migrationBuilder.DropTable(
                name: "UserRoleMenu");

            migrationBuilder.DropIndex(
                name: "IX_Menus_UserRoleMenuID",
                table: "Menus");

            migrationBuilder.DropColumn(
                name: "UserRoleMenuID",
                table: "Menus");

            migrationBuilder.AddColumn<int>(
                name: "MenuID",
                table: "AspNetRoles",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoles_MenuID",
                table: "AspNetRoles",
                column: "MenuID");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetRoles_Menus_MenuID",
                table: "AspNetRoles",
                column: "MenuID",
                principalTable: "Menus",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetRoles_Menus_MenuID",
                table: "AspNetRoles");

            migrationBuilder.DropIndex(
                name: "IX_AspNetRoles_MenuID",
                table: "AspNetRoles");

            migrationBuilder.DropColumn(
                name: "MenuID",
                table: "AspNetRoles");

            migrationBuilder.AddColumn<int>(
                name: "UserRoleMenuID",
                table: "Menus",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "UserRoleMenu",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserRoleMenu", x => x.ID);
                    table.ForeignKey(
                        name: "FK_UserRoleMenu_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Menus_UserRoleMenuID",
                table: "Menus",
                column: "UserRoleMenuID");

            migrationBuilder.CreateIndex(
                name: "IX_UserRoleMenu_RoleId",
                table: "UserRoleMenu",
                column: "RoleId");

            migrationBuilder.AddForeignKey(
                name: "FK_Menus_UserRoleMenu_UserRoleMenuID",
                table: "Menus",
                column: "UserRoleMenuID",
                principalTable: "UserRoleMenu",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
