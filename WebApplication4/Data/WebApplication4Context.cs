using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SuaLojaDeComputadores.Models;

namespace WebApplication4.Data
{
    public class WebApplication4Context : DbContext
    {
        public WebApplication4Context (DbContextOptions<WebApplication4Context> options)
            : base(options)
        {
        }

        public DbSet<SuaLojaDeComputadores.Models.Produto> Produto { get; set; } = default!;
    }
}
