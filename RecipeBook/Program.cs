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
builder.Services.AddDbContext<RecipeDBContext_00014227>(o => o.UseSqlServer(builder.Configuration.GetConnectionString("SqlServerConnection")));


builder.Services.AddScoped<IRepository_00014227<RecipeBookItems_00014227>, RecipeBookRepository_00014227>();
builder.Services.AddScoped<IRepository_00014227<Category_00014227>, CategoryRepository_00014227>();

builder.Services.AddCors(p=>p.AddPolicy("corspolicy", build =>
{
    build.WithOrigins("*").AllowAnyMethod().AllowAnyHeader(); 
}));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors("corspolicy");

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
