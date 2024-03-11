using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Affinity_Affairs.Migrations
{
    /// <inheritdoc />
    public partial class Sixth : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "c635afc9-2a84-40c7-9136-b36315fd5978");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "d23781ce-ac17-4392-81f2-56f560a7a10b");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "01331cdc-0caa-497f-b0fe-43c89f9ca793", null, "Admin", "Admin" },
                    { "5a32fc5f-c6ee-49f2-a863-02d3f1f3e892", null, "User", "User" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "01331cdc-0caa-497f-b0fe-43c89f9ca793");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "5a32fc5f-c6ee-49f2-a863-02d3f1f3e892");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "c635afc9-2a84-40c7-9136-b36315fd5978", null, "User", "User" },
                    { "d23781ce-ac17-4392-81f2-56f560a7a10b", null, "Admin", "Admin" }
                });
        }
    }
}
