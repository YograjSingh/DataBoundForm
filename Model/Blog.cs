﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace DataBoundForm.Model
{
    public class BlogModel
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [Key]
        [Display(Name = "Title")]
        [StringLength(500, MinimumLength = 3)]
        [Required]
        public string Title { get; set; }
        
        [MaxLength(5000)]
        public string Content { get; set; }
        public AuthorModel Author { get; set; }
        public DateTime Date { get; set; } = DateTime.Now;
    }
}
