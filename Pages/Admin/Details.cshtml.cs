using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using HamzilahFoods.Data;

namespace HamzilahFoods.Pages.Admin
{
    public class DetailsModel : PageModel
    {
        private readonly HamzilahFoods.Data.HamzilahFoodsContext _context;

        public DetailsModel(HamzilahFoods.Data.HamzilahFoodsContext context)
        {
            _context = context;
        }

      public Menu Menu { get; set; } = default!; 

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Menu == null)
            {
                return NotFound();
            }

            var menu = await _context.Menu.FirstOrDefaultAsync(m => m.ID == id);
            if (menu == null)
            {
                return NotFound();
            }
            else 
            {
                Menu = menu;
            }
            return Page();
        }
    }
}
