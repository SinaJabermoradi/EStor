using EStor.Application.Interfaces.Contexts;
using EStor.Application.Services.Users.QueriesService.GetRoles;
using EStor.Application.Services.Users.QueriesService.GetUsers;
using EStor.Persistence.Context;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;


#region Main()

#region Main() کد های مربوط به خود ِمتد 

var builder = WebApplication.CreateBuilder(args); // به کمک این متد ، می تونیم هم از کانفیگور و هم از کافیگور سرویس استفاده کنیم

#endregion

#region Configure Service()
// Add services to the container.

#region Service Dependency Injection تزریق وابستگی سرویس ها یا 

builder.Services.AddScoped<IDataBaseContext, DataBaseContext>();
builder.Services.AddScoped<IGetUsersService, GetUsersService>();
builder.Services.AddScoped<IGetRolesService, GetRolesService>();

#endregion

string connectionString = new SqlConnectionStringBuilder()
{
    DataSource = @"DESKTOP-RIGJNO6\DEVELOP",
    InitialCatalog = "EStor_DB",
    IntegratedSecurity = true
}.ConnectionString;

builder.Services.AddEntityFrameworkSqlServer()
    .AddDbContext<DataBaseContext>(options => options.UseSqlServer(connectionString));

builder.Services.AddControllersWithViews();

#endregion

#region Configure()

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

app.UseEndpoints(endpoints =>
{
    endpoints.MapControllerRoute(
        name: "default",
        pattern: "{controller=Home}/{action=Index}/{id?}");

    endpoints.MapControllerRoute(
        name: "areas",
        pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}"
    );
});



app.Run();

#endregion

#endregion
