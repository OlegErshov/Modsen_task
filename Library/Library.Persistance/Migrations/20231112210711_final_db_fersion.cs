using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Library.Persistance.Migrations
{
    /// <inheritdoc />
    public partial class final_db_fersion : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Authors",
                columns: new[] { "Id", "FirstName", "Surname" },
                values: new object[,]
                {
                    { new Guid("5d836356-e43b-421d-985e-add2a4b341db"), "Stiven", "King" },
                    { new Guid("f209ef7c-5537-4c17-a5ad-b0584b55a0d9"), "Dmitriy", "Emec" }
                });

            migrationBuilder.InsertData(
                table: "Genres",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("90e31958-2608-4563-adb9-20bd73833033"), "Fiction" },
                    { new Guid("aafe849b-ac4f-4075-8700-7f315ef1c7d1"), "Detective" }
                });

            migrationBuilder.InsertData(
                table: "Books",
                columns: new[] { "Id", "authorId", "Description", "genreId", "ISBN", "RecieveDate", "ReturnDate", "Title" },
                values: new object[,]
                {
                    { new Guid("295dbecc-3bac-4b46-934a-1b4dabdab24e"), new Guid("f209ef7c-5537-4c17-a5ad-b0584b55a0d9"), "Cool book about romance, fighting and fascinating turning points in plot", new Guid("90e31958-2608-4563-adb9-20bd73833033"), "978-5-699-91155-4", new DateTime(2023, 11, 13, 0, 7, 10, 789, DateTimeKind.Local).AddTicks(2970), new DateTime(2023, 11, 13, 0, 7, 10, 789, DateTimeKind.Local).AddTicks(2980), "Valkuries Revenge" },
                    { new Guid("b0bbcaf3-5b56-48b5-a2e6-4ed00050826f"), new Guid("5d836356-e43b-421d-985e-add2a4b341db"), "Great book from a great author", new Guid("90e31958-2608-4563-adb9-20bd73833033"), "133-7-657-91110-7", new DateTime(2023, 11, 13, 0, 7, 10, 789, DateTimeKind.Local).AddTicks(2984), new DateTime(2023, 11, 13, 0, 7, 10, 789, DateTimeKind.Local).AddTicks(2985), "Dark Tower" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: new Guid("295dbecc-3bac-4b46-934a-1b4dabdab24e"));

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: new Guid("b0bbcaf3-5b56-48b5-a2e6-4ed00050826f"));

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: new Guid("aafe849b-ac4f-4075-8700-7f315ef1c7d1"));

            migrationBuilder.DeleteData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: new Guid("5d836356-e43b-421d-985e-add2a4b341db"));

            migrationBuilder.DeleteData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: new Guid("f209ef7c-5537-4c17-a5ad-b0584b55a0d9"));

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: new Guid("90e31958-2608-4563-adb9-20bd73833033"));
        }
    }
}
