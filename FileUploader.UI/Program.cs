using FileUploader.Core.Domain.RepositoryContracts;
using FileUploader.Infrastructure.DbContext;
using FileUploader.Infrastructure.Repositories;
using FileUploader.UI.Middleware;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();

//Inject DbContexts
builder.Services.AddDbContext<FileUploadDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("FileUploadConnectionString"));
});
builder.Services.AddDbContext<AuthDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("FileUploadAuthDbConnectionString"));
});
builder.Services.AddDbContext<LogDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("FileUploadLogsConnectionString"));
});

builder.Services.AddIdentity<IdentityUser,  IdentityRole>().AddEntityFrameworkStores<AuthDbContext>()
    .AddDefaultTokenProviders();

builder.Services.AddScoped<IClientsRepository, ClientRepository>();
builder.Services.AddScoped<IUploadFileRepository, UploadFileRepository>();
builder.Services.AddScoped<IDocumentsRepository, DocumentsRepository>();
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<ILogsRepository, LogsRepository>();

var app = builder.Build();

app.UseMiddleware<ExceptionHandlingMiddleware>();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();
app.UseStaticFiles();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=UploadFile}/{action=Dashboard}/{id?}");

app.Run();
