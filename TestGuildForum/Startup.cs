using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using GuildForum.Models;
using GuildForum.Models.Users;
using Microsoft.AspNetCore.Identity;

namespace GuildForum {
  public class Startup {
    public Startup(IConfiguration configuration) {
      Configuration = configuration;
    }

    public IConfiguration Configuration { get; }

    // This method gets called by the runtime. Use this method to add services to the container.
    public void ConfigureServices(IServiceCollection services) {
      services.AddDbContext<ForumContext>(opt =>
        opt.UseMySql(Configuration.GetConnectionString("DefaultConnection")));

      // Adds cookie based aythentication
      // Adds scoped classes for things like UserManager, SignInManager, PasswordHashers, etc..
      services.AddIdentity<ApplicationUser, IdentityRole>()
        .AddEntityFrameworkStores<ForumContext>()
        .AddDefaultTokenProviders();

      // Change password policy
      services.Configure<IdentityOptions>(options => {
        options.Password.RequireDigit = false;
        options.Password.RequiredLength = 5;
        options.Password.RequireLowercase = true;
        options.Password.RequireUppercase = false;
        options.Password.RequireNonAlphanumeric = false;
      });

      // zmiana linku gdzie ma przekierowac jak nie jestes zalogowany
      services.ConfigureApplicationCookie(options => {
        options.LoginPath = "/account/login";
      });


      services.AddMvc();
     //   .AddJsonOptions(x => x.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore);
    }

    // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
    public void Configure(IApplicationBuilder app, IHostingEnvironment env) {
      if (env.IsDevelopment()) app.UseDeveloperExceptionPage();
      app.UseAuthentication();
      app.UseMvc();
    }
  }
}
