
using Microsoft.EntityFrameworkCore;
using DbContext = Microsoft.EntityFrameworkCore.DbContext;
using Microsoft.Extensions.DependencyInjection;
using ChatAppClient.Data;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<ChatAppClientContext>(options =>

    options.UseSqlServer(builder.Configuration.GetConnectionString("ChatAppClientContext") ?? throw new InvalidOperationException("Connection string 'ChatAppClientContext' not found.")));

// Add services to the container.
builder.Services.AddControllersWithViews();
//builder.Services.AddDbContext<DBContext>(options =>
//{
//    options.UseSqlServer(builder.Configuration.GetConnectionString("DbConnectin"));
//});
builder.Services.AddCors(opt => opt.AddDefaultPolicy(policy => policy
                                                            .AllowCredentials()
                                                            .AllowAnyHeader()
                                                            .SetIsOriginAllowed(x => true)
));

builder.Services.AddSignalR();

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
app.UseCors();
app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
