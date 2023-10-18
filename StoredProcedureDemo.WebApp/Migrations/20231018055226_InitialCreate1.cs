using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace StoredProcedureDemo.WebApp.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"
                CREATE PROCEDURE GetAllProducts
                AS
                BEGIN
                    SELECT * FROM product_sp_demo;
                END
            ");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
