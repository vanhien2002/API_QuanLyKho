using API_QuanLyKho.Repository;
using API_QuanLyKho.Service;
using API_QuanLyKho.Repository;
using API_QuanLyKho.Service;
using static API_QuanLyKho.Repository.AIRepository;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
#region DI
builder.Services.AddScoped<IChiTietXHRepository, ChiTietXHRepository>();
builder.Services.AddScoped<IChiTietXHService, ChiTietXHService>();

builder.Services.AddScoped<IAIRepository, AIRepository>();
builder.Services.AddScoped<IAIService, AIService>();

builder.Services.AddScoped<IPhieuXuatHangService, PhieuXuatHangService>();
builder.Services.AddScoped<IPhieuXuatHangRepository, PhieuXuatHangRepository>();

builder.Services.AddScoped<IKhachHangRepository, KhachHangRepository>();
builder.Services.AddScoped<IKhachHangService, KhachHangService>();

builder.Services.AddScoped<ILoaiSPService, LoaiSPService>();
builder.Services.AddScoped<ILoaiSPRepository, LoaiSPRepository>();

builder.Services.AddScoped<ISanPhamService, SanPhamService>();
builder.Services.AddScoped<ISanPhamRepository, SanPhamRepository>();

builder.Services.AddScoped<IKhuService, KhuService>();
builder.Services.AddScoped<IKhuRepository, KhuRepository>();

builder.Services.AddScoped<IKeSPService, KeSPService>();
builder.Services.AddScoped<IKeSPRepository, KeSPRepository>();

builder.Services.AddScoped<IKhoHangService, KhoHangService>();
builder.Services.AddScoped<IKhoHangRepository, KhoHangRepository>();
//SANG
builder.Services.AddScoped<IChiTietNHService, ChiTietNHService>();
builder.Services.AddScoped<IChiTietNHRepository, ChiTietNHRepository>();

builder.Services.AddScoped<IChucVuService, ChucVuService>();
builder.Services.AddScoped<IChucVuRepository, ChucVuRepository>();

builder.Services.AddScoped<INhaCungCapService, NhaCungCapService>();
builder.Services.AddScoped<INhaCungCapRepository, NhaCungCapRepository>();

builder.Services.AddScoped<INhanVienService, NhanVienService>();
builder.Services.AddScoped<INhanVienRepository, NhanVienRepository>();

builder.Services.AddScoped<IPhieuNhapHangService, PhieuNhapHangService>();
builder.Services.AddScoped<IPhieuNhapHangRepository, PhieuNhapHangRepository>();

builder.Services.AddScoped<IPhanQuyenService, PhanQuyenService>();
builder.Services.AddScoped<IPhanQuyenRepository, PhanQuyenRepository>();

builder.Services.AddScoped<INhomNguoiDungService, NhomNguoiDungService>();
builder.Services.AddScoped<INhomNguoiDungRepository, NhomNguoiDungRepository>();

builder.Services.AddScoped<ITaiKhoanNVService, TaiKhoanNVService>();
builder.Services.AddScoped<ITaiKhoanNVRepository, TaiKhoanNVRepository>();

builder.Services.AddScoped<IDangNhapService, DangNhapService>();
builder.Services.AddScoped<IDangNhapRepository, DangNhapRepository>();

builder.Services.AddScoped<IManHinhService, ManHinhService>();
builder.Services.AddScoped<IManHinhRepository, ManHinhRepository>();

builder.Services.AddScoped<IThongKeService, ThongKeService>();
builder.Services.AddScoped<IThongKeRepository, ThongKeRepository>();

builder.Services.AddScoped<IGioHangSevice, GioHangSevice>();
builder.Services.AddScoped<IGioHangRepository, GioHangRepository>();
#endregion

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseAuthorization();

app.MapControllers();

app.Run();
