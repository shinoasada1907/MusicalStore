using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DTO.Migrations
{
    /// <inheritdoc />
    public partial class addpkctpn : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK__CT_PHIEU__F557B7712CD9316A",
                table: "CT_PHIEU_NHAP");

            migrationBuilder.AddColumn<string>(
                name: "MaCtPn",
                table: "CT_PHIEU_NHAP",
                type: "varchar(10)",
                unicode: false,
                maxLength: 10,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddPrimaryKey(
                name: "PK__CT_PHIEU__F557B7712CD9316A",
                table: "CT_PHIEU_NHAP",
                column: "MaCtPn");

            migrationBuilder.CreateIndex(
                name: "IX_CT_PHIEU_NHAP_MaPN",
                table: "CT_PHIEU_NHAP",
                column: "MaPN");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK__CT_PHIEU__F557B7712CD9316A",
                table: "CT_PHIEU_NHAP");

            migrationBuilder.DropIndex(
                name: "IX_CT_PHIEU_NHAP_MaPN",
                table: "CT_PHIEU_NHAP");

            migrationBuilder.DropColumn(
                name: "MaCtPn",
                table: "CT_PHIEU_NHAP");

            migrationBuilder.AddPrimaryKey(
                name: "PK__CT_PHIEU__F557B7712CD9316A",
                table: "CT_PHIEU_NHAP",
                columns: new[] { "MaPN", "MaSP" });
        }
    }
}
