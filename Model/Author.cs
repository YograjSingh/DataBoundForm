using Microsoft.AspNetCore.Mvc.RazorPages;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DataBoundForm.Model
{
    public class AuthorModel
    {

        [Required(ErrorMessage = "Please provide an First Name")]
            [MaxLength(50)]
        public string Given_name { get; set; }

            [Required(ErrorMessage = "Please provide an Last Name.")]
            [MaxLength(50)]
        public string Last_name { get; set; }

            public DateTime Birth_date { get; set; }

            [EmailAddress]
            [Required(ErrorMessage = "Please provide an Email address.")]
            [Key]
            public string Email { get; set; }

        [StringLength(100, MinimumLength = 6)]
        public string Website { get; set; }
            
            [Phone(ErrorMessage = "Please provide valid phone.")]
        [StringLength(20, MinimumLength = 5)]
        public string Phone { get; set; }

        [StringLength(60, MinimumLength = 3)]
        public string Country { get; set; }

        [StringLength(60, MinimumLength = 3)]
        public string Province { get; set; }

        [MaxLength(15)]
        public string Postal_code { get; set; }
        }
   
}
