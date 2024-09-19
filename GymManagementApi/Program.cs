using FluentValidation;
using GymManagement.Agregateroot.Models;
using GymManagement.Agregateroot.Validators;
using GymManagement.DTO;
using GymManagement.Handler.Services;
using GymManagement.Repository.Data;
using GymManagement.Repository;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.


builder.Services.AddControllers();
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddScoped<ISlotRepository<Slot>, SlotRepository<Slot>>();
builder.Services.AddScoped<ITrainerRepository<Trainer>, TrainerRepository<Trainer>>();

builder.Services.AddScoped<SlotServiceHandler>();
builder.Services.AddScoped<TrainerServiceHandler>();
builder.Services.AddScoped<IValidator<SlotDTO>, SlotDTOValidator>();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

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
