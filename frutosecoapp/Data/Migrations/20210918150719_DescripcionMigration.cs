using Microsoft.EntityFrameworkCore.Migrations;

namespace frutosecoapp.Data.Migrations
{
    public partial class DescripcionMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "descripcion",
                table: "t_product",
                type: "text",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "descripcion",
                table: "t_product");
        }
    }
}
