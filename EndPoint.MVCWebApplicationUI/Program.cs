using EStor.Application.Interfaces.Contexts;
using EStor.Application.Services.Common.CommonFacad;
using EStor.Application.Services.Common.QueriesService.GetCategoryForSearch;
using EStor.Application.Services.Common.QueriesService.GetMenuItem;
using EStor.Application.Services.Products.FacadPattern;
using EStor.Application.Services.Users.CommandsService.EditUser;
using EStor.Application.Services.Users.CommandsService.RegisterUser;
using EStor.Application.Services.Users.CommandsService.RemoveUser;
using EStor.Application.Services.Users.CommandsService.UserLogIn;
using EStor.Application.Services.Users.CommandsService.UserStatusChange;
using EStor.Application.Services.Users.QueriesService.GetRoles;
using EStor.Application.Services.Users.QueriesService.GetUsers;
using EStor.Persistence.Context;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;


#region Main()

#region Main() کد های مربوط به خود ِمتد 

var builder = WebApplication.CreateBuilder(args); // به کمک این متد ، می تونیم هم از کانفیگور و هم از کافیگور سرویس استفاده کنیم

#endregion

#region Configure Service()
// Add services to the container.

builder.Services.AddAuthentication(options =>
{
    options.DefaultSignInScheme = CookieAuthenticationDefaults.AuthenticationScheme;
    options.DefaultAuthenticateScheme = CookieAuthenticationDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = CookieAuthenticationDefaults.AuthenticationScheme;
}).AddCookie(options =>
    {
        options.LoginPath = new PathString("/Home/Index");
        options.ExpireTimeSpan = TimeSpan.FromMinutes(5.0);
    });

#region Service Dependency Injection تزریق وابستگی سرویس ها یا 

builder.Services.AddScoped<IDataBaseContext, DataBaseContext>();
builder.Services.AddScoped<IGetUsersService, GetUsersService>();
builder.Services.AddScoped<IGetRolesService, GetRolesService>();
builder.Services.AddScoped<IRegisterUserService, RegisterUserService>();
builder.Services.AddScoped<IRemoveUserService, RemoveUserService>();
builder.Services.AddScoped<IUserStatusChangeService, UserStatusChangeService>();
builder.Services.AddScoped<IEditUserService, EditUserService>();
builder.Services.AddScoped<IUserLoginService, UserLoginService>();
builder.Services.AddScoped<IGetMenuItemService, GetMenuItemService>();
builder.Services.AddScoped<IGetCategoryForSearchService, GetCategoryForSearchService>();


#region Facad Injection

builder.Services.AddScoped<IProductFacad, ProductFacad>();

#endregion

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
app.UseAuthentication();

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
