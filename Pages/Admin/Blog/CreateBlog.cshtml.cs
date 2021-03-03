using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using DataBoundForm.Model;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace DataBoundForm.Pages.Admin.Blog
{
    public class CreateBlog : PageModel
    {
        
        [FromForm]
        public BlogModel Blog { get; set; }
        private List<Model.AuthorModel> Authors { get; set; } = new List<Model.AuthorModel>();
        public IEnumerable<SelectListItem> AuthorList { get; private set; }

        public CreateBlog() {

            Model.AuthorModel FristAuthor = new AuthorModel()
            {
                Given_name = "Richard",
                Last_name = "Flow",
                Birth_date = new DateTime(1990, 06, 27),
                Email = "abc@xyz.com",
                Website = "www.abc.com",
                Phone = "8888554455",
                Country = "Canada",
                Province = "Ontario",
                Postal_code ="1424115"


            };

            Model.AuthorModel SecondAuthor = new AuthorModel()
            {
                Given_name = "Richard",
                Last_name = "Jhnonson",
                Birth_date = new DateTime(1992, 06, 27),
                Email = "abc@xyz1.com",
                Website = "www.abc1.com",
                Phone = "8888554465",
                Country = "US",
                Province = "ANY",
                Postal_code = "1524115"


            };
            Model.AuthorModel ThirdAuthor = new AuthorModel()
            {
                Given_name = "Michael",
                Last_name = "Jhnonson",
                Birth_date = new DateTime(1980, 06, 27),
                Email = "abc@xyz12.com",
                Website = "www.abc12.com",
                Phone = "88885544652",
                Country = "India",
                Province = "ANY1",
                Postal_code = "15241152"


            };

            Model.AuthorModel FourthAuthor = new AuthorModel()
            {
                Given_name = "Stephen",
                Last_name = "Jhnonson",
                Birth_date = new DateTime(1982, 06, 27),
                Email = "abc@xyz121.com",
                Website = "www.abc121.com",
                Phone = "888855446521",
                Country = "Pakistan",
                Province = "Baluchistan",
                Postal_code = "152141152"


            };

            Authors.Add(FristAuthor);
            Authors.Add(SecondAuthor);
            Authors.Add(ThirdAuthor);
            Authors.Add(FourthAuthor);


        }

        public void OnGet()
        {
            List<SelectListItem> list = new List<SelectListItem>();
            foreach (var author in Authors)
            {
                list.Add(new SelectListItem(author.Given_name +" " +author.Last_name , author.Given_name) );
            }
            AuthorList = list;
        }

        public void OnPost()
        {
            List<SelectListItem> list = new List<SelectListItem>();
            foreach (var author in Authors)
            {
                list.Add(new SelectListItem(author.Given_name + " " + author.Last_name, author.Given_name));
                
            }
            AuthorList = list;
        }
    }
}
