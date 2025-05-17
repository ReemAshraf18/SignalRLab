using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ProductCatalog.Migrations
{
    /// <inheritdoc />
    public partial class InitialMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Price = table.Column<double>(type: "float", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    ImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Comments",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Content = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ProductId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Comments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Comments_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Description", "ImageUrl", "Name", "Price", "Quantity" },
                values: new object[,]
                {
                    { 1, "High-performance laptop", "https://image.made-in-china.com/202f0j00QlWgerOzYFpL/Intel-Core-I7-6700hq-Laptop-Notebook-IPS-DDR4-256GB-SSD-8GB-15-6-Professional-for-Students-Office-Computer-Labtop-Laptop.webp", "Laptop", 1200.5, 10 },
                    { 2, "Latest smartphone model", "https://www.01net.com/app/uploads/2025/02/meilleur-smartphone-moins-300-euros-Xiaomi-Redmi-Note-14-Pro-4G.jpg", "Smartphone", 800.75, 20 },
                    { 3, "Delicious milk chocolate", "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcSfH3zZOKzb5uHUbMs02zQxFuUUdGYHTW4CpA&s", "Chocolate", 5.9900000000000002, 50 }
                });

            migrationBuilder.InsertData(
                table: "Comments",
                columns: new[] { "Id", "Content", "ProductId", "UserName" },
                values: new object[,]
                {
                    { 1, "Great laptop!", 1, "User1" },
                    { 2, "Worth the price.", 1, "User2" },
                    { 3, "Excellent camera quality", 2, "User3" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Comments_ProductId",
                table: "Comments",
                column: "ProductId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Comments");

            migrationBuilder.DropTable(
                name: "Products");
        }
    }
}
