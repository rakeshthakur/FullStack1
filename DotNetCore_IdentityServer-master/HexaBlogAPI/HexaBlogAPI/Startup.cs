using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Microsoft.EntityFrameworkCore;
using HexaBlogAPI.Infrastructure;
using HexaBlogAPI.Repositories;
using HexaBlogAPI.Models;
using HexaBlogAPI.Filters;
using Microsoft.AspNetCore.Http;
using Swashbuckle.AspNetCore.Swagger;
using System.Reflection;
using System.IO;
using Microsoft.AspNetCore.Authentication.JwtBearer;

namespace HexaBlogAPI
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddCors(options =>
            {
                //options.AddDefaultPolicy(policy =>
                //{
                //    policy.AllowAnyOrigin()
                //    .AllowAnyMethod()
                //    .AllowAnyHeader();
                //});
                options.AddPolicy("MyPolicy", policy =>
                {
                    policy.AllowAnyOrigin()
                    .AllowAnyMethod()
                    .AllowAnyHeader();
                });
            });

            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddIdentityServerAuthentication(options =>
                {
                    options.Authority = Configuration.GetValue<string>("IdentityServerUrl");
                    options.RequireHttpsMetadata = false;
                    options.ApiName = "BlogAPI";
                });

            services.AddDbContext<BlogsContext>(options =>
            {
                options.UseSqlServer(Configuration.GetValue<string>("ConnectionString"));
            });

            services.AddSwaggerGen(options =>
            {
                options.SwaggerDoc("v1", new Info
                {
                    Title = "HexaBlog API",
                    Version="v1",
                    Contact=new Contact
                    {
                        Name="Sonu Sathyadas", Email ="sonusathyadas@hotmail.com", Url="https://streamingskills.blog"
                    },
                    Description="Blogs written by Hexaware bloggers ",
                    TermsOfService=string.Empty,
                    License=new License {  Name ="MIT License", Url="https://streamingskills.blog/license" }
                });
                var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
                options.IncludeXmlComments(xmlPath);
            });
            services.AddScoped<IRepository<Blog>, Repository<Blog>>();

            services.AddMvc(options =>
                {
                    options.Filters.Add(typeof(ApiExceptionFilter));
                })
                .SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
        }

        
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler(options=>
                {
                    options.Run(async (context) =>
                    {
                        context.Response.StatusCode = 500;
                        var msg = "Some error occured in the server";
                        await context.Response.WriteAsync(msg);                        
                    });
                });
            }

            InitializeDatabase(app);

            app.UseStaticFiles();
            app.UseAuthentication();
            app.UseCors("MyPolicy");
            app.UseSwagger();
            app.UseSwaggerUI(options =>
            {
                options.SwaggerEndpoint("/swagger/v1/swagger.json", "HexaBlog API");
                options.RoutePrefix = string.Empty;
            });

            app.UseMvc();
        }

        private void InitializeDatabase(IApplicationBuilder app)
        {
            using (var serviceScope = app.ApplicationServices.GetService<IServiceScopeFactory>().CreateScope())
            {
                serviceScope.ServiceProvider.GetRequiredService<BlogsContext>().Database.Migrate();
            }
        }
    }
}
