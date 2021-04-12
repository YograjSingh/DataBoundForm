using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using DataBoundForm.Context;
using DataBoundForm.Model;

namespace DataBoundForm.Pages.Admin.Blog
{
    public class EditModel : PageModel
    {
        private readonly DataBoundForm.Context.DataContext _context;

        public EditModel(DataBoundForm.Context.DataContext context)
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

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(BlogModel).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BlogModelExists(BlogModel.Title))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool BlogModelExists(string id)
        {
            return _context.Blogs.Any(e => e.Title == id);
        }
    }
}
