using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using Sandbox.Components;
using Sandbox.Data;

var builder = WebApplication.CreateBuilder( args );

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

// Add DB Context
builder.Services.AddDbContext<ApplicationDbContext>( options =>
    options.UseNpgsql( builder.Configuration.GetConnectionString( "DefaultConnection" ) )
);

// Add API controllers
builder.Services.AddControllers();

// Add Swagger services
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "Sandbox API",
        Version = "v1",
        Description = "API for the Sandbox Blazor application"
    });
});

// Add this to your service configuration
builder.Services.AddHttpClient();
builder.Services.AddScoped( sp => new HttpClient {BaseAddress = new Uri( "https://localhost:44330" )} );

var app = builder.Build();

// Configure the HTTP request pipeline.
if ( app.Environment.IsDevelopment() )
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "Sandbox API V1");
    });
}
else
{
    app.UseExceptionHandler( "/Error", createScopeForErrors: true );
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

// And add this before app.UseRouting()
app.UseCors("AllowAll");

app.UseStaticFiles();
app.UseAntiforgery();

// Map controllers
app.MapControllers();

app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.Run();