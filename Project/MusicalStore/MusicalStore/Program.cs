using DTO.IRepository;
using DTO.Models;
using DTO.Repository;
using Microsoft.EntityFrameworkCore;
using MusicalStore.Models.Service.Momo;
using MusicalStore.Repository.Momo;
using MusicalStore.Repository.ProductRepo;
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

//MusicalStore
builder.Services.AddScoped<IProductRepository, ProductRepository>();

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
