using MeuPonto.Cache;
using MeuPonto.Data;
using Microsoft.AspNetCore.Authentication.OpenIdConnect;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.Authorization;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Web;
using Microsoft.Identity.Web.UI;

namespace MeuPonto;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Add services to the container.

        {
            var endpointUri = builder.Configuration.GetConnectionString("EndpointUri") ?? throw new InvalidOperationException("EndpointUri not found.");
            var primaryKey = builder.Configuration.GetConnectionString("PrimaryKey") ?? throw new InvalidOperationException("PrimaryKey not found.");

            builder.Services.AddDbContext<MeuPontoDbContext>(options =>
                options.UseCosmos(endpointUri, primaryKey, databaseName: "MeuPonto"));
        }

        {
            var basePath = Directory.GetCurrentDirectory();
            var dataSource = Path.Combine(basePath, "MeuPonto.db");

            //builder.Services.AddDbContext<MeuPontoDbContext>(options =>
            //    options.UseSqlite($"Data Source={dataSource}", b => b.MigrationsAssembly("MeuPonto.EntityFrameworkCore.Sqlite")));
        }

        {
            var connectionString = builder.Configuration.GetConnectionString("DefaultConnection") ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");

            //builder.Services.AddDbContext<MeuPontoDbContext>(options =>
            //    options.UseSqlServer(connectionString, b => b.MigrationsAssembly("MeuPonto.EntityFrameworkCore.SqlServer")));
        }

        builder.Services.AddDatabaseDeveloperPageExceptionFilter();

        builder.Services.AddAuthentication(OpenIdConnectDefaults.AuthenticationScheme)
            .AddMicrosoftIdentityWebApp(builder.Configuration.GetSection("AzureAd"));

        builder.Services.Configure<OpenIdConnectOptions>(OpenIdConnectDefaults.AuthenticationScheme, options =>
        {
            var previousOptions = options.Events.OnRedirectToIdentityProvider;
            options.Events.OnRedirectToIdentityProvider = async context =>
            {
                await previousOptions(context);

                //https://github.com/Azure-Samples/active-directory-aspnetcore-webapp-openidconnect-v2/issues/399#issuecomment-681917473
                context.ProtocolMessage.ResponseType = Microsoft.IdentityModel.Protocols.OpenIdConnect.OpenIdConnectResponseType.IdToken;
            };

            var onTokenValidated = options.Events.OnTokenValidated;

            options.Events.OnTokenValidated = async context =>
            {
                onTokenValidated?.Invoke(context);
            };

            options.Events.OnRedirectToIdentityProviderForSignOut = async context =>
            {

            };
        });

        builder.Services.AddAuthorization(options =>
        {
            // By default, all incoming requests will be authorized according to the default policy.
            options.FallbackPolicy = options.DefaultPolicy;
        });
        builder.Services
            .AddRazorPages(options =>
            {
                options.RootDirectory = "/Modules";
            })
            .AddMvcOptions(options =>
            {
                var policy = new AuthorizationPolicyBuilder()
                              .RequireAuthenticatedUser()
                              .Build();
                options.Filters.Add(new AuthorizeFilter(policy));
            })
            .AddViewOptions(options =>
            {
                options.HtmlHelperOptions.ClientValidationEnabled = false;
            })
            .AddMicrosoftIdentityUI();

        builder.Services.AddTransient(p => new DateTimeSnapshot(DateTime.Now));

        var app = builder.Build();

        var supportedCultures = new[] { "pt-BR", "en-US" };
        var localizationOptions = new RequestLocalizationOptions().SetDefaultCulture(supportedCultures[0])
            .AddSupportedCultures(supportedCultures)
            .AddSupportedUICultures(supportedCultures);

        app.UseRequestLocalization(localizationOptions);

        // Configure the HTTP request pipeline.
        if (app.Environment.IsDevelopment())
        {
            app.UseWebAssemblyDebugging();
        }
        else
        {
            app.UseExceptionHandler("/Error");
            // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
            app.UseHsts();
        }

        app.UseHttpsRedirection();


        app.UseBlazorFrameworkFiles();
        app.UseStaticFiles();

        app.UseRouting();

        app.UseAuthentication();
        app.UseAuthorization();

        app.MapRazorPages();
        app.MapControllers();
        app.MapFallbackToFile("app/index.html");

        //using (var scope = app.Services.CreateScope())
        //{
        //    var db = scope.ServiceProvider.GetService<MeuPontoDbContext>();

        //    db.Database.EnsureDeleted();
        //    db.Database.Migrate();
        //}

        app.UseMiddleware<CacheMiddleware>();

        app.Run();
    }
}