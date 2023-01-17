using Application.Implementations;
using Application.Interfaces;
using Neo4jClient;
using Persistencd.Repositories.Implementations;
using Persistence;
using Persistence.Repositories.Implementations;
using Persistence.Repositories.Interfaces;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var client = new GraphClient(new Uri("http://localhost:7474"), "neo4j", "password");
client.ConnectAsync();
builder.Services.AddSingleton<IGraphClient>(client);
builder.Services.AddScoped<IEmployeeRepository, EmployeeRepository>();
builder.Services.AddScoped<IEmployeeService, EmployeeService>();
builder.Services.AddScoped<IDepartmentRepository, DepartmentRepository>();
builder.Services.AddScoped<IDepartmentService, DepartmentService>();
builder.Services.AddControllersWithViews().AddRazorRuntimeCompilation();
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
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
