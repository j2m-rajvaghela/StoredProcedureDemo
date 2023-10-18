using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace StoredProcedureDemo.WebApp.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "product_sp_demo",
                columns: table => new
                {
                    product_id = table.Column<long>(type: "Bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "varchar(50)", nullable: false),
                    price = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_product_sp_demo", x => x.product_id);
                });
            migrationBuilder.Sql(@"
                CREATE PROCEDURE GetProductsByPrice
                @Price decimal
                AS
                BEGIN
                    SELECT * FROM product_sp_demo WHERE Price = @Price;
                END
            ");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "product_sp_demo");
        }
    }
}
