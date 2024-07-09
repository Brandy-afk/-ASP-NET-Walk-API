using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace BulkyAPI.Migrations
{
    /// <inheritdoc />
    public partial class Seeding : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Difficulties",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("17e417cf-9ed9-415c-a5dc-3ba9d3711e95"), "Easy" },
                    { new Guid("7dc01279-5319-4799-9001-66b3c59abb84"), "Moderate" },
                    { new Guid("92e2814e-7410-402b-a365-86ae9dd00865"), "Extreme" },
                    { new Guid("bf4f135a-54ba-4d09-aba4-f128d3b3fbe2"), "Difficult" }
                });

            migrationBuilder.InsertData(
                table: "Regions",
                columns: new[] { "Id", "Code", "Name", "RegionImageUrl" },
                values: new object[,]
                {
                    { new Guid("0115a2b7-069a-4178-9854-d74c67198d68"), "NA", "North America", "https://example.com/northamerica.jpg" },
                    { new Guid("0b5ab2da-4c9f-453a-89d2-08ff9ee06323"), "SA", "South America", "https://example.com/southamerica.jpg" },
                    { new Guid("69e40f4a-3676-4fe5-88db-0890cfcd4316"), "AF", "Africa", "https://example.com/africa.jpg" },
                    { new Guid("bd59c495-71f4-4c52-b616-5cafa2a9feff"), "EU", "Europe", "https://example.com/europe.jpg" },
                    { new Guid("f35513a5-4835-4d35-8f44-b4f99f94f555"), "AS", "Asia", "https://example.com/asia.jpg" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Difficulties",
                keyColumn: "Id",
                keyValue: new Guid("17e417cf-9ed9-415c-a5dc-3ba9d3711e95"));

            migrationBuilder.DeleteData(
                table: "Difficulties",
                keyColumn: "Id",
                keyValue: new Guid("7dc01279-5319-4799-9001-66b3c59abb84"));

            migrationBuilder.DeleteData(
                table: "Difficulties",
                keyColumn: "Id",
                keyValue: new Guid("92e2814e-7410-402b-a365-86ae9dd00865"));

            migrationBuilder.DeleteData(
                table: "Difficulties",
                keyColumn: "Id",
                keyValue: new Guid("bf4f135a-54ba-4d09-aba4-f128d3b3fbe2"));

            migrationBuilder.DeleteData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: new Guid("0115a2b7-069a-4178-9854-d74c67198d68"));

            migrationBuilder.DeleteData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: new Guid("0b5ab2da-4c9f-453a-89d2-08ff9ee06323"));

            migrationBuilder.DeleteData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: new Guid("69e40f4a-3676-4fe5-88db-0890cfcd4316"));

            migrationBuilder.DeleteData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: new Guid("bd59c495-71f4-4c52-b616-5cafa2a9feff"));

            migrationBuilder.DeleteData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: new Guid("f35513a5-4835-4d35-8f44-b4f99f94f555"));
        }
    }
}
