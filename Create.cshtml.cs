using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using OneMoreTime.Data;

namespace OneMoreTime.Pages.Doc
{
    public class CreateModel : PageModel
    {
        private readonly OneMoreTime.Data.ApplicationDbContext _context;

        public CreateModel(OneMoreTime.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Doctors Doctors { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Doctors.Add(Doctors);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}