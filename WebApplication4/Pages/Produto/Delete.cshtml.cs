﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using SuaLojaDeComputadores.Models;
using WebApplication4.Data;

namespace WebApplication4.Pages.Produto
{
    public class DeleteModel : PageModel
    {
        private readonly WebApplication4.Data.WebApplication4Context _context;

        public DeleteModel(WebApplication4.Data.WebApplication4Context context)
        {
            _context = context;
        }

        [BindProperty]
        public SuaLojaDeComputadores.Models.Produto Produto { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var produto = await _context.Produto.FirstOrDefaultAsync(m => m.Id == id);

            if (produto == null)
            {
                return NotFound();
            }
            else
            {
                Produto = produto;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var produto = await _context.Produto.FindAsync(id);
            if (produto != null)
            {
                Produto = produto;
                _context.Produto.Remove(Produto);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
