using Microsoft.EntityFrameworkCore;
using RelationshipApi_8_7_3.Data;
using RelationshipApi_8_7_3.Repository;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Connection to DB
builder.Services.AddDbContext<DataContext>(x => x.UseSqlServer(
    builder.Configuration.GetConnectionString("DefaultConnection")
    ));

// Repositories
builder.Services.AddScoped<ICustomerRepository, CustomerRepository>();

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
