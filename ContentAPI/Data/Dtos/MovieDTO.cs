using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ContentAPI.Data.Dtos
{
    public class MovieDTO
    {
        [Required(ErrorMessage = "Title is necessary")]
        public string Title { get; set; }
        [Required(ErrorMessage = "Gender is necessary")]
        public string Gender { get; set; }
        [Required(ErrorMessage = "Director is necessary")]
        public string Director { get; set; }
        public int Duration { get; set; }
    }
}
