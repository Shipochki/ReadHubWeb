using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ReadHub.Core;
using ReadHub.Core.Data;
using ReadHub.Core.Services.Admin;
using ReadHub.Core.Services.Author;
using ReadHub.Core.Services.Book;
using ReadHub.Core.Services.Cart;
using ReadHub.Core.Services.Order;
using ReadHub.Core.Services.Publisher;
using ReadHub.Core.Services.Review;
using ReadHub.Core.Services.VirtualBook;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<ReadHubDbContext>(options =>
    options.UseSqlServer(connectionString));
builder.Services.AddDatabaseDeveloperPageExceptionFilter();

builder.Services.AddDefaultIdentity<User>(options =>
{
    options.SignIn.RequireConfirmedAccount = false;
    options.Password.RequireDigit = false;
    options.Password.RequireLowercase = false;
    options.Password.RequireNonAlphanumeric = false;
    options.Password.RequireUppercase = false;
})
    .AddRoles<IdentityRole>()
    .AddEntityFrameworkStores<ReadHubDbContext>();

builder.Services.AddControllersWithViews(options =>
{
    options.Filters.Add<AutoValidateAntiforgeryTokenAttribute>();
});

builder.Services.AddTransient<IBookService, BookService>();
builder.Services.AddTransient<IAdminService, AdminService>();
builder.Services.AddTransient<IAuthorService, AuthorService>();
builder.Services.AddTransient<IPublisherService, PublisherService>();
builder.Services.AddTransient<IReviewService, ReviewService>();
builder.Services.AddTransient<IOrderService, OrderService>();
builder.Services.AddTransient<ICartService, CartService>();
builder.Services.AddTransient<IVirtualBookService, VirtualBookService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
    app.UseMigrationsEndPoint();
}
else
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.UseEndpoints(endpoints =>
{
	endpoints.MapControllerRoute(
		name: "Areas",
		pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}");

	endpoints.MapControllerRoute(
		name: "Book Edit",
		pattern: "/Book/Edit/{id}/{information}",
		defaults: new { Controller = "Book", Action = "Edit" });

	endpoints.MapControllerRoute(
		name: "Book AddReview",
		pattern: "/Book/AddReview/{id}/{information}",
		defaults: new { Controller = "Book", Action = "AddReview" });

	endpoints.MapDefaultControllerRoute();
	endpoints.MapRazorPages();
});

app.MapRazorPages();

app.Run();
