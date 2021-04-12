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
    public class IndexModel : PageModel
    {
        private readonly DataBoundForm.Context.DataContext _context;

        public IndexModel(DataBoundForm.Context.DataContext context)
        {
            _context = context;
        }

        public IList<AuthorModel> AuthorModel { get;set; }

        public async Task OnGetAsync()
        {
            
            AuthorModel = await _context.Authors.ToListAsync();
        }
    }
}
