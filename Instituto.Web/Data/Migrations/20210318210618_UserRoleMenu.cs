using Microsoft.EntityFrameworkCore.Migrations;

namespace Instituto.Web.Data.Migrations
{
    public partial class UserRoleMenu : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "UserRoleMenuID",
                table: "Menus",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "UsersRolesMenus",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UsersRolesMenus", x => x.ID);
                    table.ForeignKey(
                        name: "FK_UsersRolesMenus_AspNetRoles_RoleId",
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
                name: "IX_UsersRolesMenus_RoleId",
                table: "UsersRolesMenus",
                column: "RoleId");

            migrationBuilder.AddForeignKey(
                name: "FK_Menus_UsersRolesMenus_UserRoleMenuID",
                table: "Menus",
                column: "UserRoleMenuID",
                principalTable: "UsersRolesMenus",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Menus_UsersRolesMenus_UserRoleMenuID",
                table: "Menus");

            migrationBuilder.DropTable(
                name: "UsersRolesMenus");

            migrationBuilder.DropIndex(
                name: "IX_Menus_UserRoleMenuID",
                table: "Menus");

            migrationBuilder.DropColumn(
                name: "UserRoleMenuID",
                table: "Menus");
        }
    }
}
