using System.Net;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddAuthentication("CookieAuth")
    .AddCookie("CookieAuth", options =>
    {
        options.LoginPath = "/Account/Login";
    });

// Supabase
var url = "https://yxszixapxyoicurvxbdu.supabase.co";
var key = "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJpc3MiOiJzdXBhYmFzZSIsInJlZiI6Inl4c3ppeGFweHlvaWN1cnZ4YmR1Iiwicm9sZSI6ImFub24iLCJpYXQiOjE3MDk0MDQ0MjEsImV4cCI6MjAyNDk4MDQyMX0.ebzbmfoyAfkaTr_ok68mclD4iJnDdxr5g19rovhN7Hc";

var options = new Supabase.SupabaseOptions
{
    AutoConnectRealtime = true
};

// Correction: Déplacer cette ligne avant app.Build()
builder.Services.AddSingleton(new Supabase.Client(url, key, options));
builder.Services.AddScoped<SupabaseService>();

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

app.UseAuthentication(); // Doit être appelé avant UseAuthorization
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}"
    );

app.MapControllerRoute(
    name: "dashboard",
    pattern: "{controller=Dashboard}/{action=Index}/{id?}"
    );

app.MapControllerRoute(
    name: "account",
    pattern: "{controller=Account}/{action=Login}/{id?}"
    );




    

app.Run();
