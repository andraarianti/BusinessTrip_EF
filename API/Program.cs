using API.Models;
using BLL;
using BLL.Interfaces;
using Data;
using Data.Interfaces;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//appdbcontext
builder.Services.AddDbContext<AppDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("MyDbConnectionString"));
});

//DI
builder.Services.AddScoped<IPositionsData, PositionsData>();
builder.Services.AddScoped<IPositionsBLL, PositionsBLL>();
builder.Services.AddScoped<IStaffData, StaffData>();
builder.Services.AddScoped<IStaffBLL, StaffBLL>();
builder.Services.AddScoped<ITripData, TripData>();
builder.Services.AddScoped<ITripBLL, TripBLL>();
builder.Services.AddScoped<IExpenseData, ExpenseData>();
builder.Services.AddScoped<IExpenseBLL, ExpenseBLL>();
builder.Services.AddScoped<IApprovalData, ApprovalData>();
builder.Services.AddScoped<IApprovalBLL, ApprovalBLL>();

//add automapper
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

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
