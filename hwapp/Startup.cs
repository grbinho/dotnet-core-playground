using System;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Configuration;

namespace aspnetcoreapp
{
    public class Startup
    {
        public Startup(IHostingEnvironment env)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath);
                                            
            builder.AddEnvironmentVariables();
            Configuration = builder.Build();
            
            
            Console.WriteLine("Startup constructor");            
        }
        
        public IConfigurationRoot Configuration { get; }
          
        public void Configure(IApplicationBuilder app, 
            ILoggerFactory loggerFactory,
            IHostingEnvironment env)
        {   
            Console.WriteLine($"contentroot: {env.ContentRootPath}");        
            Console.WriteLine($"webroot: {env.WebRootPath}");
            
            loggerFactory.AddConsole(minLevel: LogLevel.Trace);
            var logger = loggerFactory.CreateLogger("Testing");
            
            if(env.IsDevelopment()) {
                app.UseRuntimeInfoPage("/info");
            }
            
            
            app.UseRequestLogger();                          
            app.UseStaticFiles();
            app.UseWelcomePage();
            
          
                               
            app.UseMvc();
        }
        
        //Called before Configure
        public void ConfigureServices(IServiceCollection services) 
        {
            //Register DI      
            services.AddRouting();
            services.AddMvc();
            services.AddDirectoryBrowser();
        }
        
      
    }
}