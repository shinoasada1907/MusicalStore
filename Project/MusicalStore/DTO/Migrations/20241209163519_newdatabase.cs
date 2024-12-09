using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DTO.Migrations
{
    /// <inheritdoc />
    public partial class newdatabase : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CHUC_VU",
                columns: table => new
                {
                    MaCV = table.Column<string>(type: "varchar(10)", unicode: false, maxLength: 10, nullable: false),
                    TenCV = table.Column<string>(type: "nvarchar(200)", unicode: false, maxLength: 20, nullable: true),
                    MucLuong = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__CHUC_VU__27258E763D8D5847", x => x.MaCV);
                });

            migrationBuilder.CreateTable(
                name: "CT_SAN_PHAM",
                columns: table => new
                {
                    MaCTSP = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 10, nullable: false),
                    GioiThieu = table.Column<string>(type: "nvarchar(max)", unicode: false, maxLength: 200, nullable: true),
                    ThongSo = table.Column<string>(type: "nvarchar(500)", unicode: false, maxLength: 200, nullable: true),
                    TinhNang = table.Column<string>(type: "nvarchar(max)", unicode: false, maxLength: 200, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__CT_SAN_P__1E4FCECD0651B758", x => x.MaCTSP);
                });

            migrationBuilder.CreateTable(
                name: "KHACH_HANG",
                columns: table => new
                {
                    MaKH = table.Column<string>(type: "varchar(10)", unicode: false, maxLength: 10, nullable: false),
                    TenKH = table.Column<string>(type: "nvarchar(250)", unicode: false, maxLength: 50, nullable: false),
                    Email = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    SDT = table.Column<string>(type: "varchar(11)", unicode: false, maxLength: 11, nullable: true),
                    GioiTinh = table.Column<string>(type: "nvarchar(10)", unicode: false, maxLength: 5, nullable: true),
                    NgaySinhKH = table.Column<DateOnly>(type: "date", nullable: true),
                    DiaChi = table.Column<string>(type: "nvarchar(250)", unicode: false, maxLength: 200, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__KHACH_HA__2725CF1E1C748EF7", x => x.MaKH);
                });

            migrationBuilder.CreateTable(
                name: "LOAI_SAN_PHAM",
                columns: table => new
                {
                    MaLSP = table.Column<string>(type: "varchar(10)", unicode: false, maxLength: 10, nullable: false),
                    TenLSP = table.Column<string>(type: "nvarchar(150)", unicode: false, maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__LOAI_SAN__3B983FFE73DE8B14", x => x.MaLSP);
                });

            migrationBuilder.CreateTable(
                name: "MA_GIAM_GIA",
                columns: table => new
                {
                    MaGG = table.Column<string>(type: "varchar(10)", unicode: false, maxLength: 10, nullable: false),
                    GiaTriGiam = table.Column<int>(type: "int", nullable: true),
                    ChiTiet = table.Column<string>(type: "nvarchar(200)", unicode: false, maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__MA_GIAM___2725AE8263AD34E0", x => x.MaGG);
                });

            migrationBuilder.CreateTable(
                name: "NHA_CUNG_CAP",
                columns: table => new
                {
                    MaNCC = table.Column<string>(type: "varchar(10)", unicode: false, maxLength: 10, nullable: false),
                    TenNCC = table.Column<string>(type: "nvarchar(250)", unicode: false, maxLength: 20, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__NHA_CUNG__3A185DEB0EC52CBD", x => x.MaNCC);
                });

            migrationBuilder.CreateTable(
                name: "PHAN_QUYEN",
                columns: table => new
                {
                    MaPQ = table.Column<string>(type: "varchar(10)", unicode: false, maxLength: 10, nullable: false),
                    TenPQ = table.Column<string>(type: "nvarchar(150)", unicode: false, maxLength: 20, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__PHAN_QUY__2725E7F37E0A52DF", x => x.MaPQ);
                });

            migrationBuilder.CreateTable(
                name: "PT_THANH_TOAN",
                columns: table => new
                {
                    MaPTTT = table.Column<string>(type: "varchar(10)", unicode: false, maxLength: 10, nullable: false),
                    HinhThuc = table.Column<string>(type: "nvarchar(200)", unicode: false, maxLength: 20, nullable: true),
                    SDT = table.Column<string>(type: "varchar(11)", unicode: false, maxLength: 11, nullable: true),
                    TenNhan = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    NganHang = table.Column<string>(type: "varchar(10)", unicode: false, maxLength: 10, nullable: true),
                    STK = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__PT_THANH__B30A28028AF8FF85", x => x.MaPTTT);
                });

            migrationBuilder.CreateTable(
                name: "TINH_TRANG",
                columns: table => new
                {
                    MaTT = table.Column<int>(type: "int", nullable: false),
                    TenTT = table.Column<string>(type: "nvarchar(100)", unicode: false, maxLength: 20, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__TINH_TRA__272500792636AA7B", x => x.MaTT);
                });

            migrationBuilder.CreateTable(
                name: "NHAN_VIEN",
                columns: table => new
                {
                    MaNV = table.Column<string>(type: "varchar(10)", unicode: false, maxLength: 10, nullable: false),
                    TenNV = table.Column<string>(type: "nvarchar(250)", unicode: false, maxLength: 50, nullable: false),
                    GioiTinh = table.Column<string>(type: "nvarchar(10)", unicode: false, maxLength: 5, nullable: true),
                    DienThoai = table.Column<string>(type: "varchar(11)", unicode: false, maxLength: 11, nullable: true),
                    CCCD = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: true),
                    NgaySinh = table.Column<DateOnly>(type: "date", nullable: true),
                    MaCV = table.Column<string>(type: "varchar(10)", unicode: false, maxLength: 10, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__NHAN_VIE__2725D70A836C3D7B", x => x.MaNV);
                    table.ForeignKey(
                        name: "FK__NHAN_VIEN__MaCV__3B75D760",
                        column: x => x.MaCV,
                        principalTable: "CHUC_VU",
                        principalColumn: "MaCV");
                });

            migrationBuilder.CreateTable(
                name: "SAN_PHAM",
                columns: table => new
                {
                    MaSP = table.Column<string>(type: "varchar(10)", unicode: false, maxLength: 10, nullable: false),
                    TenSP = table.Column<string>(type: "nvarchar(250)", unicode: false, maxLength: 50, nullable: false),
                    Hang = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: true),
                    DVT = table.Column<string>(type: "nvarchar(10)", unicode: false, maxLength: 20, nullable: true),
                    Gia = table.Column<double>(type: "float", nullable: true),
                    MoTa = table.Column<string>(type: "nvarchar(max)", unicode: false, maxLength: 200, nullable: true),
                    MaCTSP = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 50, nullable: true),
                    Hinh = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    SLSP = table.Column<int>(type: "int", nullable: true),
                    MaLSP = table.Column<string>(type: "varchar(10)", unicode: false, maxLength: 10, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__SAN_PHAM__2725081C89E7C261", x => x.MaSP);
                    table.ForeignKey(
                        name: "FK__CT__SAN_PHAM__MaCTSP",
                        column: x => x.MaCTSP,
                        principalTable: "CT_SAN_PHAM",
                        principalColumn: "MaCTSP");
                    table.ForeignKey(
                        name: "FK__SAN_PHAM__MaLSP__48CFD27E",
                        column: x => x.MaLSP,
                        principalTable: "LOAI_SAN_PHAM",
                        principalColumn: "MaLSP");
                });

            migrationBuilder.CreateTable(
                name: "DON_HANG",
                columns: table => new
                {
                    MaDH = table.Column<string>(type: "varchar(10)", unicode: false, maxLength: 10, nullable: false),
                    TongTienHang = table.Column<double>(type: "float", nullable: false),
                    TongTT = table.Column<double>(type: "float", nullable: false),
                    NgayLap = table.Column<DateOnly>(type: "date", nullable: false),
                    TinhTrang = table.Column<string>(type: "nvarchar(100)", unicode: false, maxLength: 20, nullable: true),
                    MaKH = table.Column<string>(type: "varchar(10)", unicode: false, maxLength: 10, nullable: true),
                    MaTT = table.Column<int>(type: "int", nullable: true),
                    MaPTTT = table.Column<string>(type: "varchar(10)", unicode: false, maxLength: 10, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__DON_HANG__2725866136FFA2BC", x => x.MaDH);
                    table.ForeignKey(
                        name: "FK__DON_HANG__MaKH__5629CD9C",
                        column: x => x.MaKH,
                        principalTable: "KHACH_HANG",
                        principalColumn: "MaKH");
                    table.ForeignKey(
                        name: "FK__DON_HANG__MaPTTT__5812160E",
                        column: x => x.MaPTTT,
                        principalTable: "PT_THANH_TOAN",
                        principalColumn: "MaPTTT");
                    table.ForeignKey(
                        name: "FK__DON_HANG__MaTT__571DF1D5",
                        column: x => x.MaTT,
                        principalTable: "TINH_TRANG",
                        principalColumn: "MaTT");
                });

            migrationBuilder.CreateTable(
                name: "PHIEU_NHAP",
                columns: table => new
                {
                    MaPN = table.Column<string>(type: "varchar(10)", unicode: false, maxLength: 10, nullable: false),
                    NgayLap = table.Column<DateOnly>(type: "date", nullable: true),
                    NgayXuat = table.Column<DateOnly>(type: "date", nullable: true),
                    MaNCC = table.Column<string>(type: "varchar(10)", unicode: false, maxLength: 10, nullable: true),
                    MaNV = table.Column<string>(type: "varchar(10)", unicode: false, maxLength: 10, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__PHIEU_NH__2725E7F0F32683B7", x => x.MaPN);
                    table.ForeignKey(
                        name: "FK__PHIEU_NHAP__MaNV__6477ECF3",
                        column: x => x.MaNV,
                        principalTable: "NHAN_VIEN",
                        principalColumn: "MaNV");
                    table.ForeignKey(
                        name: "FK__PHIEU_NHA__MaNCC__6383C8BA",
                        column: x => x.MaNCC,
                        principalTable: "NHA_CUNG_CAP",
                        principalColumn: "MaNCC");
                });

            migrationBuilder.CreateTable(
                name: "TAI_KHOAN",
                columns: table => new
                {
                    MaTK = table.Column<string>(type: "varchar(10)", unicode: false, maxLength: 10, nullable: false),
                    TenTK = table.Column<string>(type: "nvarchar(250)", unicode: false, maxLength: 50, nullable: false),
                    MatKhau = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: false),
                    Email = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    MaKH = table.Column<string>(type: "varchar(10)", unicode: false, maxLength: 10, nullable: true),
                    MaNV = table.Column<string>(type: "varchar(10)", unicode: false, maxLength: 10, nullable: true),
                    MaPQ = table.Column<string>(type: "varchar(10)", unicode: false, maxLength: 10, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__TAI_KHOA__2725007095687E5D", x => x.MaTK);
                    table.ForeignKey(
                        name: "FK__TAI_KHOAN__MaKH__403A8C7D",
                        column: x => x.MaKH,
                        principalTable: "KHACH_HANG",
                        principalColumn: "MaKH");
                    table.ForeignKey(
                        name: "FK__TAI_KHOAN__MaNV__412EB0B6",
                        column: x => x.MaNV,
                        principalTable: "NHAN_VIEN",
                        principalColumn: "MaNV");
                    table.ForeignKey(
                        name: "FK__TAI_KHOAN__MaPQ__4222D4EF",
                        column: x => x.MaPQ,
                        principalTable: "PHAN_QUYEN",
                        principalColumn: "MaPQ");
                });

            migrationBuilder.CreateTable(
                name: "BINH_LUAN",
                columns: table => new
                {
                    MaKH = table.Column<string>(type: "varchar(10)", unicode: false, maxLength: 10, nullable: false),
                    MaSP = table.Column<string>(type: "varchar(10)", unicode: false, maxLength: 10, nullable: false),
                    NoiDung = table.Column<string>(type: "nvarchar(500)", unicode: false, maxLength: 200, nullable: true),
                    NgayDang = table.Column<DateOnly>(type: "date", nullable: true),
                    Sao = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__BINH_LUA__F5579F9FC6E17241", x => new { x.MaKH, x.MaSP });
                    table.ForeignKey(
                        name: "FK__BINH_LUAN__MaKH__5DCAEF64",
                        column: x => x.MaKH,
                        principalTable: "KHACH_HANG",
                        principalColumn: "MaKH");
                    table.ForeignKey(
                        name: "FK__BINH_LUAN__MaSP__5EBF139D",
                        column: x => x.MaSP,
                        principalTable: "SAN_PHAM",
                        principalColumn: "MaSP");
                });

            migrationBuilder.CreateTable(
                name: "CHI_TIET_GIAM_GIA",
                columns: table => new
                {
                    MaSP = table.Column<string>(type: "varchar(10)", unicode: false, maxLength: 10, nullable: false),
                    MaGG = table.Column<string>(type: "varchar(10)", unicode: false, maxLength: 10, nullable: false),
                    NgayBD = table.Column<DateOnly>(type: "date", nullable: true),
                    NgayKT = table.Column<DateOnly>(type: "date", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__CHI_TIET__155752F40C7EF9D8", x => new { x.MaSP, x.MaGG });
                    table.ForeignKey(
                        name: "FK__CHI_TIET_G__MaGG__5165187F",
                        column: x => x.MaGG,
                        principalTable: "MA_GIAM_GIA",
                        principalColumn: "MaGG");
                    table.ForeignKey(
                        name: "FK__CHI_TIET_G__MaSP__5070F446",
                        column: x => x.MaSP,
                        principalTable: "SAN_PHAM",
                        principalColumn: "MaSP");
                });

            migrationBuilder.CreateTable(
                name: "CT_DON_HANG",
                columns: table => new
                {
                    MaDH = table.Column<string>(type: "varchar(10)", unicode: false, maxLength: 10, nullable: false),
                    SoLuong = table.Column<int>(type: "int", nullable: false),
                    Gia = table.Column<double>(type: "float", nullable: true),
                    Tong = table.Column<double>(type: "float", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__CT_DON_H__52737C6725ADE823", x => new { x.MaDH, x.SoLuong });
                    table.ForeignKey(
                        name: "FK__CT_DON_HAN__MaDH__5AEE82B9",
                        column: x => x.MaDH,
                        principalTable: "DON_HANG",
                        principalColumn: "MaDH");
                });

            migrationBuilder.CreateTable(
                name: "CT_PHIEU_NHAP",
                columns: table => new
                {
                    MaPN = table.Column<string>(type: "varchar(10)", unicode: false, maxLength: 10, nullable: false),
                    MaSP = table.Column<string>(type: "varchar(10)", unicode: false, maxLength: 10, nullable: false),
                    SLNhap = table.Column<int>(type: "int", nullable: true),
                    GiaNhap = table.Column<double>(type: "float", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__CT_PHIEU__F557B7712CD9316A", x => new { x.MaPN, x.MaSP });
                    table.ForeignKey(
                        name: "FK__CT_PHIEU_N__MaPN__6754599E",
                        column: x => x.MaPN,
                        principalTable: "PHIEU_NHAP",
                        principalColumn: "MaPN");
                    table.ForeignKey(
                        name: "FK__CT_PHIEU_N__MaSP__68487DD7",
                        column: x => x.MaSP,
                        principalTable: "SAN_PHAM",
                        principalColumn: "MaSP");
                });

            migrationBuilder.CreateIndex(
                name: "IX_BINH_LUAN_MaSP",
                table: "BINH_LUAN",
                column: "MaSP");

            migrationBuilder.CreateIndex(
                name: "IX_CHI_TIET_GIAM_GIA_MaGG",
                table: "CHI_TIET_GIAM_GIA",
                column: "MaGG");

            migrationBuilder.CreateIndex(
                name: "IX_CT_PHIEU_NHAP_MaSP",
                table: "CT_PHIEU_NHAP",
                column: "MaSP");

            migrationBuilder.CreateIndex(
                name: "IX_DON_HANG_MaKH",
                table: "DON_HANG",
                column: "MaKH");

            migrationBuilder.CreateIndex(
                name: "IX_DON_HANG_MaPTTT",
                table: "DON_HANG",
                column: "MaPTTT");

            migrationBuilder.CreateIndex(
                name: "IX_DON_HANG_MaTT",
                table: "DON_HANG",
                column: "MaTT");

            migrationBuilder.CreateIndex(
                name: "IX_NHAN_VIEN_MaCV",
                table: "NHAN_VIEN",
                column: "MaCV");

            migrationBuilder.CreateIndex(
                name: "IX_PHIEU_NHAP_MaNCC",
                table: "PHIEU_NHAP",
                column: "MaNCC");

            migrationBuilder.CreateIndex(
                name: "IX_PHIEU_NHAP_MaNV",
                table: "PHIEU_NHAP",
                column: "MaNV");

            migrationBuilder.CreateIndex(
                name: "IX_SAN_PHAM_MaCTSP",
                table: "SAN_PHAM",
                column: "MaCTSP");

            migrationBuilder.CreateIndex(
                name: "IX_SAN_PHAM_MaLSP",
                table: "SAN_PHAM",
                column: "MaLSP");

            migrationBuilder.CreateIndex(
                name: "IX_TAI_KHOAN_MaKH",
                table: "TAI_KHOAN",
                column: "MaKH");

            migrationBuilder.CreateIndex(
                name: "IX_TAI_KHOAN_MaNV",
                table: "TAI_KHOAN",
                column: "MaNV");

            migrationBuilder.CreateIndex(
                name: "IX_TAI_KHOAN_MaPQ",
                table: "TAI_KHOAN",
                column: "MaPQ");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BINH_LUAN");

            migrationBuilder.DropTable(
                name: "CHI_TIET_GIAM_GIA");

            migrationBuilder.DropTable(
                name: "CT_DON_HANG");

            migrationBuilder.DropTable(
                name: "CT_PHIEU_NHAP");

            migrationBuilder.DropTable(
                name: "TAI_KHOAN");

            migrationBuilder.DropTable(
                name: "MA_GIAM_GIA");

            migrationBuilder.DropTable(
                name: "DON_HANG");

            migrationBuilder.DropTable(
                name: "PHIEU_NHAP");

            migrationBuilder.DropTable(
                name: "SAN_PHAM");

            migrationBuilder.DropTable(
                name: "PHAN_QUYEN");

            migrationBuilder.DropTable(
                name: "KHACH_HANG");

            migrationBuilder.DropTable(
                name: "PT_THANH_TOAN");

            migrationBuilder.DropTable(
                name: "TINH_TRANG");

            migrationBuilder.DropTable(
                name: "NHAN_VIEN");

            migrationBuilder.DropTable(
                name: "NHA_CUNG_CAP");

            migrationBuilder.DropTable(
                name: "CT_SAN_PHAM");

            migrationBuilder.DropTable(
                name: "LOAI_SAN_PHAM");

            migrationBuilder.DropTable(
                name: "CHUC_VU");
        }
    }
}
