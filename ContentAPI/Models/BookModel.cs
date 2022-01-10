using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ContentAPI.Models
{
    public class BookModel
    {
        [Required(ErrorMessage = "Title is necessary")]
        public string Title { get; set; }
        [Required(ErrorMessage = "Gender is necessary")]
        public string Gender { get; set; }
        [Required(ErrorMessage = "Gender is necessary")]
        public string Writer { get; set; }
        [Range(1, 5000, ErrorMessage = "Max is 5000 pages")]
        public int Pages { get; set; }
    }
}
