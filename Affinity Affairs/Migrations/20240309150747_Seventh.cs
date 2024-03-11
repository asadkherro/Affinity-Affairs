using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Affinity_Affairs.Migrations
{
    /// <inheritdoc />
    public partial class Seventh : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "01331cdc-0caa-497f-b0fe-43c89f9ca793");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "5a32fc5f-c6ee-49f2-a863-02d3f1f3e892");

            migrationBuilder.RenameColumn(
                name: "EventName",
                table: "Events",
                newName: "Name");

            migrationBuilder.RenameColumn(
                name: "EventLocation",
                table: "Events",
                newName: "Location");

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "Events",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "52ae98ac-ce6f-4c84-a287-a83ac53af6a5", null, "User", "User" },
                    { "5d62873b-e849-48e0-94e2-91ded3652b66", null, "Admin", "Admin" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "52ae98ac-ce6f-4c84-a287-a83ac53af6a5");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "5d62873b-e849-48e0-94e2-91ded3652b66");

            migrationBuilder.DropColumn(
                name: "Description",
                table: "Events");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Events",
                newName: "EventName");

            migrationBuilder.RenameColumn(
                name: "Location",
                table: "Events",
                newName: "EventLocation");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "01331cdc-0caa-497f-b0fe-43c89f9ca793", null, "Admin", "Admin" },
                    { "5a32fc5f-c6ee-49f2-a863-02d3f1f3e892", null, "User", "User" }
                });
        }
    }
}
