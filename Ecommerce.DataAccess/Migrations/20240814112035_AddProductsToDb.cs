using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Ecommerce.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class AddProductsToDb : Migration
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
                    Title = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ISBN = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Author = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ListPrice = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Author", "Description", "ISBN", "ListPrice", "Title" },
                values: new object[,]
                {
                    { 1, "Jane Austen", "A romantic novel of manners written by Jane Austen.", "9780141040349", 7.4900000000000002, "Pride and Prejudice" },
                    { 2, "George Orwell", "A dystopian social science fiction novel and cautionary tale.", "9780451524935", 9.9900000000000002, "1984" },
                    { 3, "Harper Lee", "A novel about the serious issues of rape and racial inequality.", "9780061120084", 8.9900000000000002, "To Kill a Mockingbird" },
                    { 4, "F. Scott Fitzgerald", "A novel about the American dream and the roaring twenties.", "9780743273565", 10.99, "The Great Gatsby" },
                    { 5, "Herman Melville", "A novel about the voyage of the whaling ship Pequod.", "9781503280786", 11.99, "Moby Dick" },
                    { 6, "Leo Tolstoy", "A historical novel that tells the story of five families.", "9780140447934", 12.99, "War and Peace" },
                    { 7, "J.D. Salinger", "A story about adolescent alienation and loss of innocence.", "9780316769488", 7.9900000000000002, "The Catcher in the Rye" },
                    { 8, "J.R.R. Tolkien", "A fantasy novel about the journey of Bilbo Baggins.", "9780547928227", 10.99, "The Hobbit" },
                    { 9, "Homer", "An ancient Greek epic poem attributed to Homer.", "9780140268867", 9.4900000000000002, "The Odyssey" },
                    { 10, "Fyodor Dostoevsky", "A novel about the mental anguish and moral dilemmas of a poor ex-student.", "9780140449136", 11.49, "Crime and Punishment" }
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
