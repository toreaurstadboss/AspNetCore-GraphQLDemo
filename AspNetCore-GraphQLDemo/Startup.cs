using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AspNetCore_GraphQLDemo.GraphQL;
using AspNetCore_GraphQLDemo.GraphQL.Messaging;
using AspNetCore_GraphQLDemo.GraphQL.Types;
using Data;
using Data.Repositories;
using GraphQL;
using GraphQL.Server;
using GraphQL.Server.Ui.Playground;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.WebSockets;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace AspNetCore_GraphQLDemo
{
    public class Startup
    {
        private readonly IWebHostEnvironment _env;

        public Startup(IConfiguration configuration, IWebHostEnvironment env)
        {
            _env = env;
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {


            // If using IIS:
            services.Configure<IISServerOptions>(options =>
            {
                options.AllowSynchronousIO = true;
            });

            services.AddControllersWithViews();

            services.AddHttpContextAccessor();

            services.AddRazorPages().AddRazorRuntimeCompilation();

            services.AddDbContext<MountainDbContext>(options =>
            {
                options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection"));
            });

            services.AddScoped<IMountainRepository, MountainRepository>();

            services.AddScoped<IDependencyResolver>(s => new FuncDependencyResolver(s.GetRequiredService));

            services.AddScoped<MountainSchema>();

            services.AddSingleton<MountainMessageService>();

            services.AddSingleton<MountainDetailsDisplayedMessageService>();

            services.AddGraphQL(x => { x.ExposeExceptions = _env.IsDevelopment(); }).AddGraphTypes(ServiceLifetime.Scoped)
            .AddUserContextBuilder(httpContext => httpContext.User)
            .AddDataLoader()
            .AddWebSockets();

            services.AddCors(options =>
            {
                options.AddPolicy(name: "MyAllowSpecificOrigins",
                    builder =>
                    {
                        builder.AllowAnyOrigin().AllowAnyMethod();
                    });
            });

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseBrowserLink();
            }

            app.UseStaticFiles(); 
            app.UseRouting();

            app.UseCors("MyAllowSpecificOrigins");

            app.UseWebSockets();

            app.UseGraphQLWebSockets<MountainSchema>("/graphql");

            //app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapDefaultControllerRoute();
            });

            app.UseGraphQL<MountainSchema>();
            if (env.IsDevelopment())
            {
                app.UseGraphQLPlayground(new GraphQLPlaygroundOptions
                {
                    
                });
            }
        }
    }
}
