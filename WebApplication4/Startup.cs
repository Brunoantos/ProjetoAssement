using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using SuaLojaDeComputadores.Models;
using SuaLojaDeComputadores.Services;
using WebApplication4.Models;

namespace WebApplication4
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
            services.AddDbContext<AppDbContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));

            services.AddTransient<ProdutoService>();

            services.AddMvc();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, IServiceScopeFactory scopeFactory)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });

            // Adiciona dados iniciais ao iniciar a aplicação
            using (var scope = scopeFactory.CreateScope())
            {
                InicializarDados(scope);
            }
        }

        // Método de inicialização de dados
        public void InicializarDados(IServiceScope scope)
        {
            var dbContext = scope.ServiceProvider.GetRequiredService<AppDbContext>();

            if (!dbContext.Marcas.Any())
            {
                dbContext.Marcas.AddRange(
                    new Marca { Nome = "Marca1" },
                    new Marca { Nome = "Marca2" }
                    // Adicione mais marcas conforme necessário
                );
            }

            if (!dbContext.Produtos.Any())
            {
                dbContext.Produtos.AddRange(
                    new Produto { Nome = "Produto1", MarcaId = 1 },
                    new Produto { Nome = "Produto2", MarcaId = 2 }
                    // Adicione mais produtos conforme necessário
                );
            }

            dbContext.SaveChanges();
        }
    }
}
