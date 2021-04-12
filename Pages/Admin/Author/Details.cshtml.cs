using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using DataBoundForm.Context;
using DataBoundForm.Model;

namespace DataBoundForm.Pages.Admin.Author
{
    public class DetailsModel : PageModel
    {
        private readonly DataBoundForm.Context.DataContext _context;

        public DetailsModel(DataBoundForm.Context.DataContext context)
        {
            _context = context;
        }

        public AuthorModel AuthorModel { get; set; }

        public async Task<IActionResult> OnGetAsync(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            AuthorModel = await _context.Authors.FirstOrDefaultAsync(m => m.Email == id);

            if (AuthorModel == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
