using GymManagement.Agregateroot.Models;
using GymManagement.Handler.Services;
using GymManagement.Repository;
using GymManagement.Repository.Data;
using Microsoft.EntityFrameworkCore;
using FluentValidation.AspNetCore;

using GymManagement.Agregateroot.Validators;
using FluentValidation;
using GymManagement.DTO;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();
//public void ConfigureServices(IServiceCollection services)
//{
//    services.AddControllersWithViews();

//    // Register FluentValidation
//    services.AddValidatorsFromAssemblyContaining<SlotDTOValidator>();
//    services.AddMvc().AddFluentValidation();

//    // Other service registrations
//}
//AddFluentValidation(fv => fv.RegisterValidatorsFromAssemblyContaining<SlotDTOValidator>());



builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddScoped<ISlotRepository<Slot>,SlotRepository<Slot>>();
builder.Services.AddScoped<ITrainerRepository<Trainer>, TrainerRepository<Trainer>>();

builder.Services.AddScoped<SlotServiceHandler>();
builder.Services.AddScoped<TrainerServiceHandler>();
builder.Services.AddScoped<IValidator<SlotDTO>, SlotDTOValidator>();
var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();


