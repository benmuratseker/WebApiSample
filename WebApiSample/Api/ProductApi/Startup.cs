using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Versioning;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using ProductApi.Data;
using ProductApi.Services;
using Swashbuckle.AspNetCore.Swagger;

namespace ProductApi
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
            services.AddDbContext<ProductsDbContext>(options => options.UseSqlServer(@"Data Source = (localdb)\MSSQLLocalDB; Initial Catalog=ProductsDB"));

            services.AddApiVersioning();
            //services.AddApiVersioning(v => v.ApiVersionReader = new MediaTypeApiVersionReader());//accept -> application/json;v=2.0 etc

            services.AddScoped<IProduct, ProductRepository>();
            
            services.AddControllers();
            services.AddSwaggerGen(s => {
                s.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo
                {
                    Title = "Product API",
                    Version = "v1"
                });

            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, ProductsDbContext productsDbContext)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
            //app.UseMvc();

            app.UseSwagger();
            app.UseSwaggerUI(s =>
            {
                s.SwaggerEndpoint("/swagger/v1/swagger.json", "API for product");
            });

            productsDbContext.Database.EnsureCreated();
        }
    }
}
