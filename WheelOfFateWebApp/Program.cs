using WheelOfFate.Services.Services;
using WheelOfFate.Services.Services.IServices;
using WheelOfFateWebApp;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();


//Adding Automapper
builder.Services.AddAutoMapper(typeof(MapperConfig));


builder.Services.AddHttpClient<IEmployeeService, EmployeeService>();
builder.Services.AddScoped<IEmployeeService, EmployeeService>();

builder.Services.AddHttpClient<IEmployeeHourService, EmployeeHourService>();
builder.Services.AddScoped<IEmployeeHourService, EmployeeHourService>();

builder.Services.AddHttpClient<IShiftService, ShiftService>();
builder.Services.AddScoped<IShiftService, ShiftService>();

builder.Services.AddHttpClient<IMergedService, MergedService>();
builder.Services.AddScoped<IMergedService, MergedService>();

builder.Services.AddHttpClient<IAllHoursService, AllHoursService>();
builder.Services.AddScoped<IAllHoursService, AllHoursService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=EmployeeManagement}/{action=Index}/{id?}");

app.Run();
