using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Activity.Infrastructure.Data.Migrations
{
    /// <inheritdoc />
    public partial class UpdateDecimalPrecision : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<decimal>(
                name: "Height",
                table: "users",
                type: "decimal(5,2)"
                );
            migrationBuilder.AlterColumn<decimal>(
                name: "Weight",
                table: "users",
                type: "decimal(5,2)"
                );
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
               name: "Users");
        }
    }
}
