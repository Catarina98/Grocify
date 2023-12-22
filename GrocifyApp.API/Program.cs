using GrocifyApp.DAL;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Add dependencies
GrocifyApp.DAL.DependencyInjectionRegistry.ConfigureServices(builder.Configuration, builder.Services);
GrocifyApp.BLL.DependencyInjectionRegistry.ConfigureServices(builder.Services);

var app = builder.Build();

app.UseDefaultFiles();
app.UseStaticFiles();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.MapFallbackToFile("/index.html");

using (var scope = app.Services.CreateScope())
{
    var factory = scope.ServiceProvider.GetRequiredService<IDbContextFactory<GrocifyAppContext>>();
    using var context = factory.CreateDbContext();

    if (context.Database.IsSqlServer())
    {
        context.Database.Migrate();
    }
}

app.Run();
