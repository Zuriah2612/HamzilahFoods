using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using HamzilahFoods.Data;

namespace HamzilahFoods.Pages.Admin
{
    public class CreateModel : PageModel
    {
        private readonly HamzilahFoods.Data.HamzilahFoodsContext _context;

        public CreateModel(HamzilahFoods.Data.HamzilahFoodsContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Menu Menu { get; set; } = default!;
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
          if (!ModelState.IsValid || _context.Menu == null || Menu == null)
            {
                return Page();
            }

            _context.Menu.Add(Menu);
            await _context.SaveChangesAsync();

            return RedirectToPage("/Admin/Index");
        }
    }
}
