using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class _2ndseedfix : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "fab4fac1-c546-41de-aebc-a14da6895711",
                column: "ConcurrencyStamp",
                value: "e3936889-7659-4628-8ce8-f6dab857011a");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "c7b013f0-5201-4317-abd8-c211f91b7330",
                columns: new[] { "ConcurrencyStamp", "NormalizedUserName", "PasswordHash", "UserName" },
                values: new object[] { "650e65f5-d193-41f2-9a2d-571536369c2a", "ADMIN@LOCALHOST.COM", "AQAAAAEAACcQAAAAELuokjplb2K2CJI0w0jLL7Oj4s84EyDRkwao9OYgYuRH+kWI6ZXKRswLn23oKUSK8w==", "Admin@localhost.com" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
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
                columns: new[] { "ConcurrencyStamp", "NormalizedUserName", "PasswordHash", "UserName" },
                values: new object[] { "4fdd88af-75b3-4039-a869-653914f2e8b1", "ADMIN", "AQAAAAEAACcQAAAAELcdRtk8YwmGFHOxmiUMQaTBuXG6ATigJ1sWGdGcvxZP5503ODSJ4TiZ4sjNA2yjQA==", "Admin" });
        }
    }
}
