using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class seedfix : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "fab4fac1-c546-41de-aebc-a14da6895711",
                column: "ConcurrencyStamp",
                value: "70a8a95c-f815-48ae-8d2b-2e5264c57943");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "c7b013f0-5201-4317-abd8-c211f91b7330",
                columns: new[] { "ConcurrencyStamp", "NormalizedEmail", "PasswordHash" },
                values: new object[] { "4fdd88af-75b3-4039-a869-653914f2e8b1", "ADMIN@LOCALHOST.COM", "AQAAAAEAACcQAAAAELcdRtk8YwmGFHOxmiUMQaTBuXG6ATigJ1sWGdGcvxZP5503ODSJ4TiZ4sjNA2yjQA==" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "fab4fac1-c546-41de-aebc-a14da6895711",
                column: "ConcurrencyStamp",
                value: "ae107004-a8a4-4294-a7c1-bd8375317398");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "c7b013f0-5201-4317-abd8-c211f91b7330",
                columns: new[] { "ConcurrencyStamp", "NormalizedEmail", "PasswordHash" },
                values: new object[] { "13f57561-8839-440c-bba2-dbdcc18d3837", "ADMIN@LOCALHOST", "AQAAAAEAACcQAAAAELAU1+NsesvQHhiLMsvpV1jRoEZh3aUHhENOgtiLacu2Vjy9Mpk3d6AJibwTWqVeHA==" });
        }
    }
}
