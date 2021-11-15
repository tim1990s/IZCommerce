using Microsoft.EntityFrameworkCore.Migrations;

namespace IZCommerce.API.Migrations
{
    public partial class CreateDatabase : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    CategoryId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CategoryName = table.Column<string>(maxLength: 100, nullable: false),
                    Description = table.Column<string>(maxLength: 100, nullable: false),
                    Picture = table.Column<string>(maxLength: 100, nullable: false),
                    Active = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.CategoryId);
                });

            migrationBuilder.CreateTable(
                name: "Suppliers",
                columns: table => new
                {
                    SupplierId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CompanyName = table.Column<string>(maxLength: 50, nullable: true),
                    ContactFName = table.Column<string>(maxLength: 30, nullable: true),
                    ContactLName = table.Column<string>(maxLength: 50, nullable: true),
                    ContactTitle = table.Column<string>(maxLength: 30, nullable: true),
                    Address1 = table.Column<string>(maxLength: 60, nullable: true),
                    Address2 = table.Column<string>(maxLength: 50, nullable: true),
                    City = table.Column<string>(maxLength: 15, nullable: true),
                    State = table.Column<string>(maxLength: 25, nullable: true),
                    PostalCode = table.Column<string>(maxLength: 15, nullable: true),
                    Country = table.Column<string>(maxLength: 50, nullable: true),
                    Phone = table.Column<string>(maxLength: 25, nullable: true),
                    Fax = table.Column<string>(maxLength: 25, nullable: true),
                    Email = table.Column<string>(maxLength: 75, nullable: true),
                    WebSite = table.Column<string>(maxLength: 100, nullable: true),
                    PaymentMethods = table.Column<string>(maxLength: 100, nullable: true),
                    DiscountType = table.Column<string>(nullable: true),
                    DiscountRate = table.Column<double>(nullable: false),
                    TypeGoods = table.Column<string>(maxLength: 255, nullable: true),
                    DiscountAvailable = table.Column<bool>(nullable: false),
                    CurrentOrder = table.Column<bool>(nullable: false),
                    CustomerID = table.Column<string>(maxLength: 50, nullable: true),
                    SizeURL = table.Column<string>(maxLength: 100, nullable: true),
                    Logo = table.Column<string>(maxLength: 100, nullable: true),
                    Ranking = table.Column<int>(maxLength: 75, nullable: false),
                    Note = table.Column<string>(maxLength: 255, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Suppliers", x => x.SupplierId);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    ProductId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SKU = table.Column<string>(maxLength: 50, nullable: true),
                    ProductName = table.Column<string>(maxLength: 100, nullable: false),
                    ProductDescription = table.Column<string>(maxLength: 100, nullable: false),
                    QuantityPerUnit = table.Column<int>(nullable: false),
                    UnitSize = table.Column<string>(maxLength: 20, nullable: true),
                    MSRP = table.Column<double>(nullable: false),
                    AvailableSize = table.Column<string>(maxLength: 50, nullable: true),
                    AvailableColors = table.Column<string>(maxLength: 50, nullable: true),
                    SizeID = table.Column<int>(nullable: false),
                    ColorID = table.Column<int>(nullable: false),
                    Discount = table.Column<double>(nullable: false),
                    UnitWeight = table.Column<double>(nullable: false),
                    UnitsInStock = table.Column<int>(nullable: false),
                    UnitsOnOrder = table.Column<int>(nullable: false),
                    ReorderLevel = table.Column<int>(nullable: false),
                    ProductAvailable = table.Column<bool>(nullable: false),
                    DiscountAvailable = table.Column<bool>(nullable: false),
                    CurrentOrder = table.Column<bool>(nullable: false),
                    Picture = table.Column<string>(maxLength: 100, nullable: true),
                    Ranking = table.Column<string>(nullable: true),
                    Note = table.Column<string>(maxLength: 255, nullable: true),
                    SupplierId = table.Column<int>(nullable: false),
                    CategoryId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.ProductId);
                    table.ForeignKey(
                        name: "FK_Products_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "CategoryId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Products_Suppliers_SupplierId",
                        column: x => x.SupplierId,
                        principalTable: "Suppliers",
                        principalColumn: "SupplierId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Products_CategoryId",
                table: "Products",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Products_SupplierId",
                table: "Products",
                column: "SupplierId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "Categories");

            migrationBuilder.DropTable(
                name: "Suppliers");
        }
    }
}
