using Microsoft.EntityFrameworkCore.Migrations;

namespace WebShop.Infrastructure.Migrations
{
    public partial class CreateRoleTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "RoleHolderId",
                table: "Accounts",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Role",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserRole = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Role", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Accounts_RoleHolderId",
                table: "Accounts",
                column: "RoleHolderId");

            migrationBuilder.AddForeignKey(
                name: "FK_Accounts_Role_RoleHolderId",
                table: "Accounts",
                column: "RoleHolderId",
                principalTable: "Role",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Accounts_Role_RoleHolderId",
                table: "Accounts");

            migrationBuilder.DropTable(
                name: "Role");

            migrationBuilder.DropIndex(
                name: "IX_Accounts_RoleHolderId",
                table: "Accounts");

            migrationBuilder.DropColumn(
                name: "RoleHolderId",
                table: "Accounts");
        }
    }
}
