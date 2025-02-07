using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DTO.Migrations
{
    /// <inheritdoc />
    public partial class addgiohangtable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "GIO_HANG",
                columns: table => new
                {
                    MaGH = table.Column<string>(type: "varchar(20)", nullable: false),
                    MaKH = table.Column<string>(type: "varchar(10)", unicode: false, maxLength: 10, nullable: false),
                    MaSP = table.Column<string>(type: "varchar(10)", unicode: false, maxLength: 10, nullable: false),
                    SoLuong = table.Column<int>(type: "int", nullable: false),
                    Gia = table.Column<double>(type: "float", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__GIO_HANG__22122024", x => x.MaGH);
                    table.ForeignKey(
                        name: "FK__GIO_HANG__MaKH__22122024",
                        column: x => x.MaKH,
                        principalTable: "KHACH_HANG",
                        principalColumn: "MaKH",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK__GIO_HANG__MaSP__22122024",
                        column: x => x.MaSP,
                        principalTable: "SAN_PHAM",
                        principalColumn: "MaSP",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_GIO_HANG_MaKH",
                table: "GIO_HANG",
                column: "MaKH");

            migrationBuilder.CreateIndex(
                name: "IX_GIO_HANG_MaSP",
                table: "GIO_HANG",
                column: "MaSP");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "GIO_HANG");
        }
    }
}
