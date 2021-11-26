using dashboard.Server.Hubs;
using dashboard.Shared;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.ResponseCompression;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Rewrite;
using MudBlazor.Services;
using MudBlazor.Services.Scroll;
//"Data Source = tcp:s23.winhost.com; User ID = DB_146837_jasonisdunn_user; Password = RJ2cc7a#z; Connect Timeout = 600; Encrypt = False; TrustServerCertificate = False; ApplicationIntent = ReadWrite; MultiSubnetFailover = False"
namespace dashboard.Server
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddSignalR();
            services.AddControllersWithViews();
            services.AddRazorPages();
            services.AddSingleton<IWorker, WinhostIWorker>();
            services.AddResponseCompression(opts =>
            {
                opts.MimeTypes = ResponseCompressionDefaults.MimeTypes.Concat(
                    new[] { "application/octet-stream" });
            });
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddDbContextPool<TestDbContext>(options => options.UseSqlServer(Configuration["ConnectionStrings:DefaultConnection"]));
            services.AddMvc();
            services.AddMudServices();

            //services.AddDbContext<TestDbContext>((serviceProvider, dbContextBuilder) =>
            //{
            //    var httpContextAccessor = serviceProvider.GetRequiredService<IHttpContextAccessor>();
            //    var connectionString = @"Data Source = tcp:s23.winhost.com; User ID = DB_146837_jasonisdunn_user; Password = RJ2cc7a#z; Connect Timeout = 30; Encrypt = False; TrustServerCertificate = False; ApplicationIntent = ReadWrite; MultiSubnetFailover = False";
            //    dbContextBuilder.UseSqlServer(connectionString);
            //});
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
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

//            var rewrite = new RewriteOptions()
//.AddRewrite(@"^(.*)/dashboard/_framework/blazor.boot.json", "/_framework/blazor.boot.json", skipRemainingRules: true)
//.AddRewrite(@"^(.*)/_blazor/negotiate", "/_blazor/negotiate", skipRemainingRules: true)
//.AddRewrite(@"^(.*)/_blazor?(.*)", "/_blazor?{1}", skipRemainingRules: true)
//.AddRewrite(@"^(.*)/(.*)/dashboard/_framework/blazor.boot.json", "/_framework/blazor.boot.json", skipRemainingRules: true)
//.AddRewrite(@"^(.*)/(.*)/_blazor/negotiate", "/_blazor/negotiate", skipRemainingRules: true)
//.AddRewrite(@"^(.*)/(.*)/_blazor?(.*)", "/_blazor?{1}", skipRemainingRules: true);
//            app.UseRewriter(rewrite);

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapRazorPages();
                endpoints.MapControllers();
                endpoints.MapHub<MarqueeHub>("/marqueehub");
                endpoints.MapHub<MinerHub>("/minerhub");
                endpoints.MapHub<HideHub>("/hidehub");
                endpoints.MapFallbackToFile("index.html");
            });

        }
    }
}
