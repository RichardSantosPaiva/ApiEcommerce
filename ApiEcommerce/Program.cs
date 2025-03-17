using ApiEcommerce.Context;
using ApiEcommerce.Repository;
using ApiEcommerce.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.FileProviders;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
string connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

builder.Services.AddDbContext<AppDbContext>(opt =>
    opt.UseMySql(
    connectionString,
    ServerVersion.AutoDetect(connectionString)));

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<IRepository, Repository>();
builder.Services.AddScoped<IProductService, ProductService>();
builder.Services.AddTransient<IFileService, FileService>();

string staticFilesPath = builder.Configuration["Directories:StaticFilesPath"];


var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var dbContext = scope.ServiceProvider.GetRequiredService<AppDbContext>();
    dbContext.Database.Migrate(); 
}

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.Use((context, next) =>
{
    if (context.Request.Path.Value.EndsWith("/", StringComparison.OrdinalIgnoreCase))
    {
        context.Request.Path = context.Request.Path.Value.TrimEnd('/');
    }
    return next();
});
app.UseStaticFiles();

app.MapControllers();

app.Run();
