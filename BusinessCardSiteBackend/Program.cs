using System.Reflection;
using BusinessCardSiteBackend;
using BusinessCardSiteBackend.Data;
using BusinessCardSiteBackend.Repositories;
using FluentValidation;
using Microsoft.EntityFrameworkCore;
using NLog.Web;

WebApplicationBuilder builder = WebApplication.CreateBuilder(args);

builder.Host.UseNLog();

// Add builder.Services to the container.
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(builder.Configuration.
                       GetConnectionString("DefaultConnection")));

builder.Services.AddCors();

builder.Services.AddScoped<ApplicationDbContext>();
builder.Services.AddScoped<IReviewRepository, ReviewRepository>();

builder.Services.AddControllers();

builder.Services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());

WebApplication app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}

app.UseCors(p => p.AllowAnyOrigin()
    .AllowAnyHeader()
    .AllowAnyMethod()
    .WithExposedHeaders("Content-Disposition"));

app.UseMiddleware<CustomExceptionMiddleware>();

// app.UseHttpsRedirection();

app.UseRouting();

app.UseAuthorization();

app.UseEndpoints(endpoints =>
{
    endpoints.MapControllers();
});

app.Run();
