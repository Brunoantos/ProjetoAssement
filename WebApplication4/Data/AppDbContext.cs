
using Microsoft.EntityFrameworkCore;
using SuaLojaDeComputadores.Models;
using WebApplication4.Models;

public class AppDbContext : DbContext
{
    public DbSet<Produto> Produtos { get; set; }
    public DbSet<Marca> Marcas { get; set; }

    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
}
