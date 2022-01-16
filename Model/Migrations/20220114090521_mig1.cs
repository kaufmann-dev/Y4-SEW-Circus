using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Model.Migrations
{
    public partial class mig1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CIRCUS_ID",
                table: "CLOWNS",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "CIRCUSES",
                columns: table => new
                {
                    CIRCUS_ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    NAME = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CIRCUSES", x => x.CIRCUS_ID);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_CLOWNS_CIRCUS_ID",
                table: "CLOWNS",
                column: "CIRCUS_ID");

            migrationBuilder.CreateIndex(
                name: "IX_CIRCUSES_NAME",
                table: "CIRCUSES",
                column: "NAME",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_CLOWNS_CIRCUSES_CIRCUS_ID",
                table: "CLOWNS",
                column: "CIRCUS_ID",
                principalTable: "CIRCUSES",
                principalColumn: "CIRCUS_ID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CLOWNS_CIRCUSES_CIRCUS_ID",
                table: "CLOWNS");

            migrationBuilder.DropTable(
                name: "CIRCUSES");

            migrationBuilder.DropIndex(
                name: "IX_CLOWNS_CIRCUS_ID",
                table: "CLOWNS");

            migrationBuilder.DropColumn(
                name: "CIRCUS_ID",
                table: "CLOWNS");
        }
    }
}
