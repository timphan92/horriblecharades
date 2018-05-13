using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using webapi_signalr.Hubs;
using webapi_signalr.Model;
using webapi_signalr.Interfaces;
using webapi_signalr.Data;

namespace webapi_signalr
{
  public class Startup
  {
    public Startup(IConfiguration configuration)
    {
      Configuration = configuration;
    }

    public IConfiguration Configuration { get; }

    // This method gets called by the runtime. Use this method to add services to the container.
    public void ConfigureServices(IServiceCollection services)
    {
      services.AddCors(options => options.AddPolicy("CorsPolicy",
        builder =>
        {
          builder.AllowAnyMethod().AllowAnyHeader().AllowAnyOrigin()
                      .AllowCredentials();
        }));

      services.AddMvc();

      services.Configure<SettingsDB>(options =>
      {
        options.ConnectionString = Configuration.GetSection("MongoConnection:ConnectionString").Value;
        options.Database = Configuration.GetSection("MongoConnection:Database").Value;
      });
      services.AddTransient<IDBRepository, DBRepository>();

      services.AddSignalR();
    }

    // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
    public void Configure(IApplicationBuilder app, IHostingEnvironment env)
    {
      if (env.IsDevelopment())
      {
        app.UseDeveloperExceptionPage();
      }

      app.UseStaticFiles();
      app.UseCookiePolicy();
      app.UseCors("CorsPolicy");
      app.UseSignalR(routes =>
      {
        routes.MapHub<Gamehub>("/gamehub");
      });

      app.UseMvc();

    }
  }
}
