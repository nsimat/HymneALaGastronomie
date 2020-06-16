using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using HymneALaGastronomie.CoreBusiness;
using HymneALaGastronomie.Data;

namespace HymneALaGastronomie.Pages.Restaurants2
{
    public class DetailsModel : PageModel
    {
        private readonly HymneALaGastronomie.Data.HymneALaGastronomieDbContext _context;

        public DetailsModel(HymneALaGastronomie.Data.HymneALaGastronomieDbContext context)
        {
            _context = context;
        }

        public Restaurant Restaurant { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Restaurant = await _context.Restaurants.FirstOrDefaultAsync(m => m.Id == id);

            if (Restaurant == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
