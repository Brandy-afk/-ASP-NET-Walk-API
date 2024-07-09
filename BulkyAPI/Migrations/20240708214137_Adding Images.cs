using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace BulkyAPI.Migrations
{
    /// <inheritdoc />
    public partial class AddingImages : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.DropColumn(
                name: "WalkImageUrl",
                table: "Walks");

            migrationBuilder.AddColumn<Guid>(
                name: "ImageID",
                table: "Walks",
                type: "uuid",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Images",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    FileName = table.Column<string>(type: "text", nullable: false),
                    FileDescription = table.Column<string>(type: "text", nullable: true),
                    FileExtension = table.Column<string>(type: "text", nullable: false),
                    FileSizeInBytes = table.Column<long>(type: "bigint", nullable: false),
                    FilePath = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Images", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Difficulties",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("6e3f2077-2e44-47c7-9c6e-53612cbb7ba6"), "Extreme" },
                    { new Guid("896b448c-5cf9-4a82-ae3b-01fd46edac99"), "Easy" },
                    { new Guid("aa6fb312-9fb1-4c9c-913a-12a4edf35b00"), "Moderate" },
                    { new Guid("efddc1a2-d94c-495b-9189-64c8d6834d53"), "Difficult" }
                });

            migrationBuilder.InsertData(
                table: "Regions",
                columns: new[] { "Id", "Code", "Name", "RegionImageUrl" },
                values: new object[,]
                {
                    { new Guid("0bb2032d-0ad2-4798-8b71-29660805951f"), "SA", "South America", "https://example.com/southamerica.jpg" },
                    { new Guid("1f697779-3046-443b-b26e-13dcc9da939e"), "EU", "Europe", "https://example.com/europe.jpg" },
                    { new Guid("26fd3ddf-172d-41f3-8ea9-3a7e883323f5"), "AS", "Asia", "https://example.com/asia.jpg" },
                    { new Guid("94aa9313-4299-413a-965e-a2aca0eb54cd"), "AF", "Africa", "https://example.com/africa.jpg" },
                    { new Guid("dfedcad8-2660-4f5c-b0af-8b42043544fc"), "NA", "North America", "https://example.com/northamerica.jpg" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Walks_ImageID",
                table: "Walks",
                column: "ImageID");

            migrationBuilder.AddForeignKey(
                name: "FK_Walks_Images_ImageID",
                table: "Walks",
                column: "ImageID",
                principalTable: "Images",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Walks_Images_ImageID",
                table: "Walks");

            migrationBuilder.DropTable(
                name: "Images");

            migrationBuilder.DropIndex(
                name: "IX_Walks_ImageID",
                table: "Walks");

            migrationBuilder.DeleteData(
                table: "Difficulties",
                keyColumn: "Id",
                keyValue: new Guid("6e3f2077-2e44-47c7-9c6e-53612cbb7ba6"));

            migrationBuilder.DeleteData(
                table: "Difficulties",
                keyColumn: "Id",
                keyValue: new Guid("896b448c-5cf9-4a82-ae3b-01fd46edac99"));

            migrationBuilder.DeleteData(
                table: "Difficulties",
                keyColumn: "Id",
                keyValue: new Guid("aa6fb312-9fb1-4c9c-913a-12a4edf35b00"));

            migrationBuilder.DeleteData(
                table: "Difficulties",
                keyColumn: "Id",
                keyValue: new Guid("efddc1a2-d94c-495b-9189-64c8d6834d53"));

            migrationBuilder.DeleteData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: new Guid("0bb2032d-0ad2-4798-8b71-29660805951f"));

            migrationBuilder.DeleteData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: new Guid("1f697779-3046-443b-b26e-13dcc9da939e"));

            migrationBuilder.DeleteData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: new Guid("26fd3ddf-172d-41f3-8ea9-3a7e883323f5"));

            migrationBuilder.DeleteData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: new Guid("94aa9313-4299-413a-965e-a2aca0eb54cd"));

            migrationBuilder.DeleteData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: new Guid("dfedcad8-2660-4f5c-b0af-8b42043544fc"));

            migrationBuilder.DropColumn(
                name: "ImageID",
                table: "Walks");

            migrationBuilder.AddColumn<string>(
                name: "WalkImageUrl",
                table: "Walks",
                type: "text",
                nullable: true);

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
    }
}
