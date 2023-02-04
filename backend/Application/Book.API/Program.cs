using Book.Infrastructure.Dependency;
using Book.Settings;
using Bookstore.Api.Enum.Book;
using MediatR;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var booksSettings = new BookStoreDatabaseSettings();
builder.Configuration.GetSection(BookDbSettings.BOOK_STORE_SETTINGS).Bind(booksSettings);
builder.Services.AddInfrastructure(booksSettings.ConnectionString, booksSettings.DatabaseName);
builder.Services.AddMediatR(Assembly.GetExecutingAssembly());

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

