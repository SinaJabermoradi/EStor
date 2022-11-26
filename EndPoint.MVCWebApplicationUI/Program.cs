var builder = WebApplication.CreateBuilder(args); // به کمک این متد ، می تونیم هم از کانفیگور و هم از کافیگور سرویس استفاده کنیم

#region Configure Service
// Add services to the container.

builder.Services.AddControllersWithViews();

#endregion

#region Configure

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

#endregion
