var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// C(Course): Allows app to handle HTTP requests and render HTML views
builder.Services.AddControllersWithViews();

// Compiles the app
var app = builder.Build();

// Configure the HTTP request pipeline.
// C: How requests are processed
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    // C: Force clients to use HTTPS connection
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseRouting();

app.UseAuthorization();

app.MapStaticAssets();

app.MapControllerRoute(
        name: "default",
        pattern: "{controller=Home}/{action=Index}/{id?}")
    .WithStaticAssets();


app.Run();