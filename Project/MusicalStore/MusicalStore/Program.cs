using DTO.IRepository;
using DTO.Models;
using DTO.Repository;
using Microsoft.EntityFrameworkCore;
using MusicalStore.Models.Service.Momo;
using MusicalStore.Repository.CategoryRespository;
using MusicalStore.Repository.ChucVuRepository;
using MusicalStore.Repository.Momo;
using MusicalStore.Repository.OrderRespository;
using MusicalStore.Repository.PaymentRespository;
using MusicalStore.Repository.ProductRepo;
using MusicalStore.Repository.StaffRepository;
using MusicalStore.Repository.UserRepository;
using MusicalStore.Repository.vnpay;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddCors(option =>
{
    option.AddDefaultPolicy(builder => builder.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());
});
builder.Services.AddControllersWithViews();
builder.Services.AddRazorPages();

builder.Services.Configure<MomoOptionModel>(builder.Configuration.GetSection("MomoAPI"));
builder.Services.AddScoped<IMomoService, MomoService>();
builder.Services.AddScoped<IVnPayService, VnPayService>();

builder.Services.AddDbContext<MusicalStoreContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
//DTO
builder.Services.AddScoped<ISanPhamRepository, SanPhamRepository>();
builder.Services.AddScoped<IKhachHangRepository, KhachHangRepository>();
builder.Services.AddScoped<INhanVienRespository, NhanVienRepository>();
builder.Services.AddScoped<IChiTietGiamGiaRepository, ChiTietGiamGiaRepository>();
builder.Services.AddScoped<IGiamGiaRepository, GiamGiaRepository>();
builder.Services.AddScoped<ICTSanPhamRepository, CTSanPhamRepository>();
builder.Services.AddScoped<ILoaiSanPhamRepository, LoaiSanPhamRepository>();
builder.Services.AddScoped<ITaiKhoanRepository, TaiKhoanRepository>();
builder.Services.AddScoped<INhanVienRepository, NhanVienRepository>();
builder.Services.AddScoped<IDonHangRepository, DonHangRepository>();
builder.Services.AddScoped<IPtThanhToanRepository, PtThanhToanRepository>();
builder.Services.AddScoped<IChucVuRepository, ChucVuRepository>();

//MusicalStore
builder.Services.AddScoped<IProductRepository, ProductRepository>();
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IStaffRepository, StaffRepository>();
builder.Services.AddScoped<IOrderRespository, OrderRespository>();
builder.Services.AddScoped<IPaymentRespository, PaymentRespository>();
builder.Services.AddScoped<IPositionRepository, PositionRepository>();
builder.Services.AddScoped<ICategoryRepository, CategoryRepository>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseCors();
app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "areas",
    pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}");

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
