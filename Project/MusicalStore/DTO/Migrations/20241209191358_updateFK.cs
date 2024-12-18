using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DTO.Migrations
{
    /// <inheritdoc />
    public partial class updateFK : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "MaCtGiamGia",
                table: "SAN_PHAM",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "MaCtGiamGiaNavigationMaGg",
                table: "SAN_PHAM",
                type: "varchar(10)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "MaCtGiamGiaNavigationMaSp",
                table: "SAN_PHAM",
                type: "varchar(10)",
                nullable: true);

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
                name: "IX_SAN_PHAM_MaCtGiamGiaNavigationMaSp_MaCtGiamGiaNavigationMaGg",
                table: "SAN_PHAM",
                columns: new[] { "MaCtGiamGiaNavigationMaSp", "MaCtGiamGiaNavigationMaGg" });

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

            migrationBuilder.AddForeignKey(
                name: "FK_SAN_PHAM_CHI_TIET_GIAM_GIA_MaCtGiamGiaNavigationMaSp_MaCtGiamGiaNavigationMaGg",
                table: "SAN_PHAM",
                columns: new[] { "MaCtGiamGiaNavigationMaSp", "MaCtGiamGiaNavigationMaGg" },
                principalTable: "CHI_TIET_GIAM_GIA",
                principalColumns: new[] { "MaSP", "MaGG" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MA_GIAM_GIA_CHI_TIET_GIAM_GIA_ChiTietGiamGiaMaSp_ChiTietGiamGiaMaGg",
                table: "MA_GIAM_GIA");

            migrationBuilder.DropForeignKey(
                name: "FK_SAN_PHAM_CHI_TIET_GIAM_GIA_MaCtGiamGiaNavigationMaSp_MaCtGiamGiaNavigationMaGg",
                table: "SAN_PHAM");

            migrationBuilder.DropIndex(
                name: "IX_SAN_PHAM_MaCtGiamGiaNavigationMaSp_MaCtGiamGiaNavigationMaGg",
                table: "SAN_PHAM");

            migrationBuilder.DropIndex(
                name: "IX_MA_GIAM_GIA_ChiTietGiamGiaMaSp_ChiTietGiamGiaMaGg",
                table: "MA_GIAM_GIA");

            migrationBuilder.DropColumn(
                name: "MaCtGiamGia",
                table: "SAN_PHAM");

            migrationBuilder.DropColumn(
                name: "MaCtGiamGiaNavigationMaGg",
                table: "SAN_PHAM");

            migrationBuilder.DropColumn(
                name: "MaCtGiamGiaNavigationMaSp",
                table: "SAN_PHAM");

            migrationBuilder.DropColumn(
                name: "ChiTietGiamGiaMaGg",
                table: "MA_GIAM_GIA");

            migrationBuilder.DropColumn(
                name: "ChiTietGiamGiaMaSp",
                table: "MA_GIAM_GIA");
        }
    }
}
