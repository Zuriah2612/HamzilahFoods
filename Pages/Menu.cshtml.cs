using HamzilahFoods.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace HamzilahFoods.Pages
{
    public class MenuModel : PageModel
    {
        private readonly HamzilahFoods.Data.HamzilahFoodsContext _context;

        public MenuModel(HamzilahFoods.Data.HamzilahFoodsContext context)
        {
            _context = context;
        }

        public IList<Menu> Menu { get; set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.Menu != null)
            {
                Menu = await _context.Menu.ToListAsync();
            }
        }
    }
}
