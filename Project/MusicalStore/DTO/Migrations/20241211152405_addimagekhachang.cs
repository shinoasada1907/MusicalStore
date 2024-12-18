using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DTO.Migrations
{
    /// <inheritdoc />
    public partial class addimagekhachang : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "AnhDaiDien",
                table: "KHACH_HANG",
                type: "nvarchar(250)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AnhDaiDien",
                table: "KHACH_HANG");
        }
    }
}
