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
    public class IndexModel : PageModel
    {
        private readonly HamzilahFoods.Data.HamzilahFoodsContext _context;

        public IndexModel(HamzilahFoods.Data.HamzilahFoodsContext context)
        {
            _context = context;
        }

        public IList<Menu> Menu { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.Menu != null)
            {
                Menu = await _context.Menu.ToListAsync();
            }
        }
    }
}
