using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Affinity_Affairs.Migrations
{
    /// <inheritdoc />
    public partial class tenth : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "6197b5a8-ef74-4483-971c-236bee525d4f");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "c1f0c451-1250-4697-b47a-d5c7d02b0a03");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "1b8e1c4b-227e-4b7a-95c7-f882051630ed", null, "Admin", "Admin" },
                    { "aef1ca9e-a93c-4d01-8839-4ed24004a2d5", null, "User", "User" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1b8e1c4b-227e-4b7a-95c7-f882051630ed");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "aef1ca9e-a93c-4d01-8839-4ed24004a2d5");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "6197b5a8-ef74-4483-971c-236bee525d4f", null, "Admin", "Admin" },
                    { "c1f0c451-1250-4697-b47a-d5c7d02b0a03", null, "User", "User" }
                });
        }
    }
}
