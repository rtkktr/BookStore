using BookStore.Infrastructure;
using BookStore.Infrastructure.Contracts;
using BookStore.Infrastructure.Services;
using BookStore.Infrastructure.Services.Statuses;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

var connectionString = builder.Configuration.GetConnectionString("Default");
builder.Services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(connectionString));

builder.Services.AddScoped<IBookRepository<Guid?, bool, RepositoryStatus>, BookRepository>();
builder.Services.AddScoped<IAuthorRepository<Guid?, bool, RepositoryStatus>, AuthorRepository>();
builder.Services.AddScoped<IPublisherRepository<Guid?, bool, RepositoryStatus>, PublisherRepository>();
builder.Services.AddScoped<ITranslatorRepository<Guid?, bool, RepositoryStatus>, TranslatorRepository>();
builder.Services.AddScoped<IOrderHeaderRepository<Guid?, bool, RepositoryStatus>, OrderHeaderRepository>();
builder.Services.AddScoped<IUserRepository<Guid?, bool, RepositoryStatus>, UserRepository>();

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
