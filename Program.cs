using DatingApp.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


builder.Services.AddDbContext<DataContext>(opt => 
opt.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection")));

//builder.Services.AddCors();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
// builder.Services.AddEndpointsApiExplorer();
// builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

//app.UseCors(Options => Options.AllowAnyHeader().AllowAnyMethod().WithOrigins ("https://localhost:7251"));
app.UseCors(Options => Options.AllowAnyHeader().AllowAnyMethod().AllowAnyOrigin());
//app.UseHttpsRedirection();
//app.UseAuthorization();

app.MapControllers();

app.Run();
