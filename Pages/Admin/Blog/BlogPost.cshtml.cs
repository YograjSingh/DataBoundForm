using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using DataBoundForm.Model;
using DataBoundForm.Context;

namespace DataBoundForm.Pages.Admin.Blog
{
    
    public class BlogPostModel : PageModel
    {

        private readonly ILogger<BlogPostModel> logger;
        private readonly DataContext _context;

        public BlogPostModel(ILogger<BlogPostModel> logger1, DataContext context) {

            logger = logger1;
            _context = context;
        }

        public string BlogTitle;
        public IList<BlogModel> BlogModel { get; set; }
        public Model.BlogModel Blog;
        public void OnGet(String? Title)
        {
             Blog = (BlogModel)_context.Blogs.Where(x => x.Title == Title);
            

        }
    }
}
