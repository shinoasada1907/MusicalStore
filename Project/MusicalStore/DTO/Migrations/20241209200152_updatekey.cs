using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DTO.Migrations
{
    /// <inheritdoc />
    public partial class updatekey : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MA_GIAM_GIA_CHI_TIET_GIAM_GIA_ChiTietGiamGiaMaSp_ChiTietGiamGiaMaGg",
                table: "MA_GIAM_GIA");

            migrationBuilder.DropIndex(
                name: "IX_MA_GIAM_GIA_ChiTietGiamGiaMaSp_ChiTietGiamGiaMaGg",
                table: "MA_GIAM_GIA");

            migrationBuilder.DropColumn(
                name: "ChiTietGiamGiaMaGg",
                table: "MA_GIAM_GIA");

            migrationBuilder.DropColumn(
                name: "ChiTietGiamGiaMaSp",
                table: "MA_GIAM_GIA");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ChiTietGiamGiaMaGg",
                table: "MA_GIAM_GIA",
                type: "varchar(10)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ChiTietGiamGiaMaSp",
                table: "MA_GIAM_GIA",
                type: "varchar(10)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_MA_GIAM_GIA_ChiTietGiamGiaMaSp_ChiTietGiamGiaMaGg",
                table: "MA_GIAM_GIA",
                columns: new[] { "ChiTietGiamGiaMaSp", "ChiTietGiamGiaMaGg" });

            migrationBuilder.AddForeignKey(
                name: "FK_MA_GIAM_GIA_CHI_TIET_GIAM_GIA_ChiTietGiamGiaMaSp_ChiTietGiamGiaMaGg",
                table: "MA_GIAM_GIA",
                columns: new[] { "ChiTietGiamGiaMaSp", "ChiTietGiamGiaMaGg" },
                principalTable: "CHI_TIET_GIAM_GIA",
                principalColumns: new[] { "MaSP", "MaGG" });
        }
    }
}
