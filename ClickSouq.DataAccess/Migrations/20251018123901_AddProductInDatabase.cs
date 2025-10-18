using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace BookNest.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class AddProductInDatabase : Migration
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
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ISBN = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Author = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ListPrice = table.Column<double>(type: "float", nullable: false),
                    Price = table.Column<double>(type: "float", nullable: false),
                    Price50 = table.Column<double>(type: "float", nullable: false),
                    Price100 = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Author", "Description", "ISBN", "ListPrice", "Price", "Price100", "Price50", "Title" },
                values: new object[,]
                {
                    { 1, "Ghassan Kanafani", "A symbolic Palestinian novel that depicts the suffering of refugees and the harsh realities of displacement through a deeply human and tragic story.", "ARB1001001", 100.0, 90.0, 70.0, 80.0, "Men in the Sun" },
                    { 2, "Abdul Rahman Munif", "A powerful novel exposing political oppression and human suffering in the Middle East, written with deep psychological and social insight.", "ARB2002002", 95.0, 85.0, 65.0, 75.0, "East of the Mediterranean" },
                    { 4, "Ibrahim al-Sakran", "An analytical and philosophical book exploring how modern distractions affect human consciousness, faith, and culture.", "ARB4004004", 85.0, 80.0, 70.0, 75.0, "Al-Majriyat" },
                    { 5, "Abdelwahab Elmessiri", "An autobiographical work that traces Elmessiri’s personal and intellectual development, offering reflections on modernity, identity, and faith.", "ARB5005005", 120.0, 110.0, 90.0, 100.0, "My Intellectual Journey" },
                    { 6, "Muhammad Asad", "A captivating autobiography of a Western intellectual who embraces Islam, offering deep insights into faith, culture, and personal transformation.", "ARB6006006", 105.0, 95.0, 80.0, 90.0, "The Road to Mecca" },
                    { 7, "Radwa Ashour", "A historical trilogy set in post-Reconquista Spain, telling the story of Muslims after the fall of Granada, filled with emotion, loss, and resistance.", "ARB7007007", 130.0, 120.0, 100.0, 110.0, "Granada Trilogy" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Products");
        }
    }
}
