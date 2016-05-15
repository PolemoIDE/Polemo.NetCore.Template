using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using $safeprojectname$.Models;

namespace $safeprojectname$
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<$safeprojectname$Context>(x =>
                x.UseSqlite("Data source = $safeprojectname$.db"));

            services.AddMvc();

            services.AddIdentity<User, IdentityRole>(x =>
            {
                x.Password.RequireDigit = false;
                x.Password.RequiredLength = 0;
                x.Password.RequireLowercase = false;
                x.Password.RequireNonAlphanumeric = false;
                x.Password.RequireUppercase = false;
                x.User.AllowedUserNameCharacters = null;
            });
        }

        public void Configure(IApplicationBuilder app, ILoggerFactory logger)
        {
            logger.AddConsole(minLevel: LogLevel.Warning);

            app.UseIdentity();
            app.UseStaticFiles();
            app.UseMvcWithDefaultRoute();
        }
    }
}
