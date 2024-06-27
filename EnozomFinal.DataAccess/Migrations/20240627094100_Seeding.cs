using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace EnozomFinal.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class Seeding : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Books",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Clean Code" },
                    { 2, "Algorithms" }
                });

            migrationBuilder.InsertData(
                table: "CopyStatus",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Good" },
                    { 2, "Damaged" },
                    { 3, "Lost" },
                    { 4, "Borrowed" }
                });

            migrationBuilder.InsertData(
                table: "Students",
                columns: new[] { "Id", "Email", "Name", "PhoneNumber", "StNumber" },
                values: new object[,]
                {
                    { 1, "Ali@Enozom.com", "Ali", "0122224400", "1" },
                    { 2, "Mohamed@Enozom.com", "Mohamed", "0111155000", "2" },
                    { 3, "Ahmed@Enozom.com", "Ahmed", "0155553311", "3" }
                });

            migrationBuilder.InsertData(
                table: "Copies",
                columns: new[] { "Id", "BookId" },
                values: new object[,]
                {
                    { 1, 1 },
                    { 2, 2 },
                    { 3, 1 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Copies",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Copies",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Copies",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "CopyStatus",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "CopyStatus",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "CopyStatus",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "CopyStatus",
                keyColumn: "Id",
                keyValue: 1);
        }
    }
}
