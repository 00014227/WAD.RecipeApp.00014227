using Microsoft.EntityFrameworkCore;
using RecipeBook.Data;
using RecipeBook.Model;
using RecipeBook.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<RecipeDBContext>(o => o.UseSqlServer(builder.Configuration.GetConnectionString("SqlServerConnection")));


builder.Services.AddScoped<IRepository<RecipeBookItems>, RecipeBookRepository>();
builder.Services.AddScoped<IRepository<Category>, CategoryRepository>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
