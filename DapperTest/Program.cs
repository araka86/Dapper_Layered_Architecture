//Слаеная Архитектура 
//DAL (Data Access Layer) - модели, доступ к данным полдключение к БД (место использования Dapper )
//BL (Busines Layer) - Доступ к DAL, обработака результата полученных данных и отправка в PL
//PL (Presentation Layer) - контролерры, представление пользователя
using DapperTest.BL.Implementation;
using DapperTest.BL.Interfaces;
using DapperTest.Dal.Implementation;
using DapperTest.Dal.Interfaces;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddSingleton<IUserBL, UserBL>();
builder.Services.AddSingleton<IUserDal, UserDal>();

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
