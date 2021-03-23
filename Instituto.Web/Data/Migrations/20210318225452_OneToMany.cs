using Microsoft.EntityFrameworkCore.Migrations;

namespace Instituto.Web.Data.Migrations
{
    public partial class OneToMany : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_CUIT",
                table: "Empresas",
                column: "CUIT",
                unique: true,
                filter: "[CUIT] IS NOT NULL");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_CUIT",
                table: "Empresas");
        }
    }
}
