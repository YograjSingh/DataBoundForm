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
    public class blogController : Controller {
        public IActionResult Index() {
            return View();
        }
    }
    public class IndexModel : PageModel
    {
        private readonly DataBoundForm.Context.DataContext _context;

        public IndexModel(DataBoundForm.Context.DataContext context)
        {
            _context = context;
        }

        public IList<BlogModel> BlogModel { get;set; }
        public IList<AuthorModel> AuthorModel { get; set; }

        public async Task OnGetAsync()

        { 
            var getBlog = _context.Blogs.Where(x => x.Title != null ).OrderByDescending (x =>x.Date).Take(5);
            BlogModel = await getBlog.ToListAsync();

            var getAuthor = _context.Authors.Where(x => x.Given_name != null);
            AuthorModel = await getAuthor.ToListAsync();
        }
    }
}
