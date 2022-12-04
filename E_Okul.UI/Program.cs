using E_Okul.Dal;
using E_Okul.Entity.Concretes;
using E_Okul.Repository.Abstracts;
using E_Okul.Repository.Concretes;
using E_Okul.UI.Models;
using E_Okul.Uow;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<EOkulContext>(options =>
        options.UseSqlServer(builder.Configuration.GetConnectionString("Baglanti")));
builder.Services.AddScoped<IStudentRep, StudentRep<Students>>();
builder.Services.AddScoped<IBranchRep, BranchRep<Branches>>();
builder.Services.AddScoped<ITeacherRep, TeacherRep<Teachers>>();
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
builder.Services.AddScoped<BranchModel>();
builder.Services.AddScoped<TeacherModel>();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
