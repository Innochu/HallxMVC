using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Hallx.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class first : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    DisplayOrder = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Author = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ISBN = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Price = table.Column<double>(type: "float", nullable: false),
                    ListPrice = table.Column<double>(type: "float", nullable: false),
                    Price50 = table.Column<double>(type: "float", nullable: false),
                    Price100 = table.Column<double>(type: "float", nullable: false),
                    ImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CategoryId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Products_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "DisplayOrder", "Name" },
                values: new object[,]
                {
                    { 1, 6, "Toys" },
                    { 2, 7, "Soap" },
                    { 3, 9, "Hamper" }
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Author", "CategoryId", "Description", "ISBN", "ImageUrl", "ListPrice", "Price", "Price100", "Price50", "Title" },
                values: new object[,]
                {
                    { 1, "Eric Ries", 2, "How Today's Entrepreneurs Use Continuous Innovation to Create Radically Successful Businesses", "978-0307887894", "", 19.989999999999998, 14.99, 10.99, 12.99, "The Lean Startup" },
                    { 2, "James Clear", 2, "An Easy & Proven Way to Build Good Habits & Break Bad Ones", "978-0735211292", "", 17.989999999999998, 12.99, 9.9900000000000002, 11.99, "Atomic Habits" },
                    { 3, "Matt Haig", 1, "A Novel", "978-0525559474", "", 21.989999999999998, 16.989999999999998, 12.99, 14.99, "The Midnight Library" },
                    { 4, "Dalai Lama XIV, Howard C. Cutler", 3, "A Handbook for Living", "978-1573221801", "", 15.99, 11.99, 8.9900000000000002, 10.99, "The Art of Happiness" },
                    { 5, "Paulo Coelho", 2, "A Fable About Following Your Dream", "978-0061122416", "", 13.99, 9.9900000000000002, 7.9900000000000002, 8.9900000000000002, "The Alchemist" },
                    { 6, "Suzanne Collins", 1, "Book 1 of the Hunger Games Trilogy", "978-0439023481", "", 12.99, 8.9900000000000002, 6.9900000000000002, 7.9900000000000002, "The Hunger Games" },
                    { 7, "Mark Manson", 2, "A Counterintuitive Approach to Living a Good Life", "978-0062457714", "", 18.989999999999998, 14.99, 11.99, 13.99, "The Subtle Art of Not Giving a F*ck" },
                    { 8, "Charles Duhigg", 3, "Why We Do What We Do in Life and Business", "978-0812981605", "", 17.989999999999998, 13.99, 10.99, 12.99, "The Power of Habit" },
                    { 9, "Andy Weir", 2, "A Novel", "978-0553418026", "", 15.99, 11.99, 9.9900000000000002, 10.99, "The Martian" },
                    { 10, "Stephen R. Covey", 3, "Powerful Lessons in Personal Change", "978-0671708634", "", 22.989999999999998, 17.989999999999998, 13.99, 15.99, "The 7 Habits of Highly Effective People" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Products_CategoryId",
                table: "Products",
                column: "CategoryId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "Categories");
        }
    }
}
