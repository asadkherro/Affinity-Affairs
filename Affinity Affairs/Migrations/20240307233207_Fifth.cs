using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Affinity_Affairs.Migrations
{
    /// <inheritdoc />
    public partial class Fifth : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1e70bdd2-3e2e-417b-b899-a81d205b8acd");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "58edfe65-943a-4c15-b95c-8db451655cf3");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "c635afc9-2a84-40c7-9136-b36315fd5978", null, "User", "User" },
                    { "d23781ce-ac17-4392-81f2-56f560a7a10b", null, "Admin", "Admin" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Events_ImageId",
                table: "Events",
                column: "ImageId");

            migrationBuilder.AddForeignKey(
                name: "FK_Events_Images_ImageId",
                table: "Events",
                column: "ImageId",
                principalTable: "Images",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Events_Images_ImageId",
                table: "Events");

            migrationBuilder.DropIndex(
                name: "IX_Events_ImageId",
                table: "Events");

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
                    { "1e70bdd2-3e2e-417b-b899-a81d205b8acd", null, "User", "User" },
                    { "58edfe65-943a-4c15-b95c-8db451655cf3", null, "Admin", "Admin" }
                });
        }
    }
}
