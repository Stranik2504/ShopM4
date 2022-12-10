using AdventureLabNew.Data;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<ApplicationDbContext>(
    options => options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"))
);

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

/*app.Use((context, next) =>
{
    context.Items["name"] = "Dany";
    return next.Invoke();
});*/

app.Run(x =>
{
    // return x.Response.WriteAsync("Hello " + x.Items["name"]);

    if (x.Request.Cookies.ContainsKey("name"))
        return x.Response.WriteAsync("Hello " + x.Request.Cookies["name"]);
    else
    {
        x.Response.Cookies.Append("name", "Dany");
        return x.Response.WriteAsync("NO");
    }
});

app.Run();
