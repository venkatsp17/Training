using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace KeyVaultTest.Migrations
{
    public partial class first : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    ProductID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    PictureURL = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.ProductID);
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "ProductID", "Name", "PictureURL", "Price" },
                values: new object[] { 1, "Product A", "https://vbucket.blob.core.windows.net/product-img/1.jpg", 100m });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "ProductID", "Name", "PictureURL", "Price" },
                values: new object[] { 2, "Product B", "https://vbucket.blob.core.windows.net/product-img/2.jfif", 200m });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "ProductID", "Name", "PictureURL", "Price" },
                values: new object[] { 3, "Product C", "https://vbucket.blob.core.windows.net/product-img/3.jfif", 300m });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Products");
        }
    }
}
