using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using DataBoundForm.Context;
using DataBoundForm.Model;

namespace DataBoundForm.Pages.Admin.Blog
{
    public class DeleteModel : PageModel
    {
        private readonly DataBoundForm.Context.DataContext _context;

        public DeleteModel(DataBoundForm.Context.DataContext context)
        {
            _context = context;
        }

        [BindProperty]
        public BlogModel BlogModel { get; set; }

        public async Task<IActionResult> OnGetAsync(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            BlogModel = await _context.Blogs.FirstOrDefaultAsync(m => m.Title == id);

            if (BlogModel == null)
            {
                return NotFound();
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            BlogModel = await _context.Blogs.FindAsync(id);

            if (BlogModel != null)
            {
                _context.Blogs.Remove(BlogModel);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
