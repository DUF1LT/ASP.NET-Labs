using Lab8.DataSource;
using Lab8.Models;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

var configuration = builder.Configuration;

builder.Services.AddCors(o => o.AddDefaultPolicy(b =>
{
    b.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod().SetIsOriginAllowed((host) => true);
}));

builder.Services.AddMvc(o => o.EnableEndpointRouting = false);

builder.Services.AddControllersWithViews();

builder.Services.AddDbContext<DbContext>(o => o.UseSqlServer(
    configuration.GetConnectionString("DefaultConnection"))
);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddTransient<IRepository<Record>, RecordDbRepository>();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseRouting();

app.UseCors();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=DictionaryMvc}/{action=Index}/{id?}");

app.Run();