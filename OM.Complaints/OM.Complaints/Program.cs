using FluentValidation;
using Microsoft.Extensions.DependencyInjection.Extensions;
using NLog.Web;
using OM.Complaints.Builders;
using OM.Complaints.Models;
using OM.Complaints.Services;

var builder = WebApplication.CreateBuilder(args);
builder.Logging.ClearProviders();
builder.Host.UseNLog();

builder.Services.TryAddTransient<IComplaintViewModelBuilder, ComplaintViewModelBuilder>();
builder.Services.TryAddTransient<IValidator<Complaint>, ComplaintValidator>();
builder.Services.Configure<MailSettings>(builder.Configuration.GetSection("MailSettings"));
builder.Services.AddTransient<IMailService, MailService>();

// Add services to the container.
builder.Services.AddControllersWithViews();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
