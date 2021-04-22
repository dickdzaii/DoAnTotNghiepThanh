using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BLL;
using BLL.Interfaces;
using DAL;
using DAL.Helper;
using DAL.Interfaces;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;

namespace API
{
    public class Startup
    {
        public Startup(IWebHostEnvironment env)
        {
            var builder = new ConfigurationBuilder()
               .SetBasePath(env.ContentRootPath)
               .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
               .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true)
               .AddEnvironmentVariables();
            Configuration = builder.Build();
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddCors(options => {
                options.AddPolicy("AllowAll", builder => builder.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());
            });
            var appSettingsSection = Configuration.GetSection("AppSettings");
            services.Configure<AppSettings>(appSettingsSection);

            // configure jwt authentication
            var appSettings = appSettingsSection.Get<AppSettings>();
            var key = Encoding.ASCII.GetBytes(appSettings.Secret);
            services.AddAuthentication(x =>
            {
                x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            .AddJwtBearer(x =>
            {
                x.RequireHttpsMetadata = false;
                x.SaveToken = true;
                x.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(key),
                    ValidateIssuer = false,
                    ValidateAudience = false
                };
            });
            services.AddControllers();
            services.AddTransient<IDatabaseHelper, DatabaseHelper>();
            services.AddTransient<IItemGroupRepository, ItemGroupRepository>();
            services.AddTransient<IItemGroupBusiness, ItemGroupBusiness>();
            services.AddTransient<IItemRepository, ItemRepository>();
            services.AddTransient<IItemBusiness, ItemBusiness>();
            services.AddTransient<ICustomerRepository, CustomerRepository>();
            services.AddTransient<ICustomerBusiness, CustomerBusiness>();
            services.AddTransient<ILoaiRepository, LoaiRepository>();
            services.AddTransient<ILoaiBusiness, LoaiBusiness>();
            services.AddTransient<IKhachHangRepository, KhachHangRepository>();
            services.AddTransient<IKhachHangBusiness, KhachHangBusiness>();
            services.AddTransient<ISanPhamRepository, SanPhamRepository>();
            services.AddTransient<ISanPhamBusiness, SanPhamBusiness>();
            services.AddTransient<IDonHangRepository,DonHangRepository>();
            services.AddTransient<IDonHangBusiness, DonHangBusiness>();
            services.AddTransient<IThongKeRepository, ThongKeRepository>();
            services.AddTransient<IThongKeBusiness, ThongKeBusiness>();
            services.AddTransient<IHoaDonNhapRepository, HoaDonNhapRepository>();
            services.AddTransient<IHoaDonNhapBusiness, HoaDonNhapBusiness>();
            services.AddTransient<INhaCungCapRepository, NhaCungCapRepository>();
            services.AddTransient<INhaCungCapBusiness, NhaCungCapBusiness>();
            services.AddTransient<IKiemKhoRepository, KiemKhoRepository>();
            services.AddTransient<IKiemKhoBusiness, KiemKhoBusiness>();

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseApiMiddleware();
            app.UseRouting();
            app.UseAuthorization();
            app.UseCors("AllowAll");
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
            app.UseHttpsRedirection(); 
        }
    }
}
