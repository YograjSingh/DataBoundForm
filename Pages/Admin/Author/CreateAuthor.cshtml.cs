using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DataBoundForm.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace DataBoundForm.Pages.Author
{
    public class CreateAuthorModel : PageModel
    {
       
            public void OnGet()
            {
            }

            public void OnPost()
            {

            }

            [FromForm]
            public AuthorModel Author { get; set; }

        

    }
    }

