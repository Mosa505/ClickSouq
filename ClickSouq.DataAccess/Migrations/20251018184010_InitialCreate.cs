using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace BookNest.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "categories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    DisplayOrder = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_categories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ISBN = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Author = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ListPrice = table.Column<double>(type: "float", nullable: false),
                    Price = table.Column<double>(type: "float", nullable: false),
                    Price50 = table.Column<double>(type: "float", nullable: false),
                    Price100 = table.Column<double>(type: "float", nullable: false),
                    CategoryId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Products_categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "categories",
                columns: new[] { "Id", "DisplayOrder", "Name" },
                values: new object[,]
                {
                    { 1, 1, "Political Fiction" },
                    { 2, 2, "Human Rights" },
                    { 3, 3, "Historical" },
                    { 4, 4, "Autobiography" },
                    { 5, 5, "Thought" }
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Author", "CategoryId", "Description", "ISBN", "ListPrice", "Price", "Price100", "Price50", "Title" },
                values: new object[,]
                {
                    { 1, "Ghassan Kanafani", 1, "A symbolic Palestinian novel that depicts the suffering of refugees and the harsh realities of displacement through a deeply human and tragic story.", "ARB1001001", 100.0, 90.0, 70.0, 80.0, "Men in the Sun" },
                    { 2, "Abdul Rahman Munif", 2, "A powerful novel exposing political oppression and human suffering in the Middle East, written with deep psychological and social insight.", "ARB2002002", 95.0, 85.0, 65.0, 75.0, "East of the Mediterranean" },
                    { 4, "Ibrahim al-Sakran", 5, "An analytical and philosophical book exploring how modern distractions affect human consciousness, faith, and culture.", "ARB4004004", 85.0, 80.0, 70.0, 75.0, "Al-Majriyat" },
                    { 5, "Abdelwahab Elmessiri", 4, "An autobiographical work that traces Elmessiri’s personal and intellectual development, offering reflections on modernity, identity, and faith.", "ARB5005005", 120.0, 110.0, 90.0, 100.0, "My Intellectual Journey" },
                    { 6, "Muhammad Asad", 4, "A captivating autobiography of a Western intellectual who embraces Islam, offering deep insights into faith, culture, and personal transformation.", "ARB6006006", 105.0, 95.0, 80.0, 90.0, "The Road to Mecca" },
                    { 7, "Radwa Ashour", 3, "A historical trilogy set in post-Reconquista Spain, telling the story of Muslims after the fall of Granada, filled with emotion, loss, and resistance.", "ARB7007007", 130.0, 120.0, 100.0, 110.0, "Granada Trilogy" }
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
                name: "categories");
        }
    }
}
