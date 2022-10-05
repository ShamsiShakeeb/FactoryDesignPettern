using Entity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ViewModel
{
    public class CourseViewModel 
    {
        public int Id { set; get; }

        [Required]
        [MaxLength(50)]
        [MinLength(3)]
        public string CourseCode { set; get; }
        [Required]
        [MaxLength(100)]
        [MinLength(3)]
        public string CourseTitle { set; get; }
        [Required]
        [MaxLength(100)]
        [MinLength(3)]
        public string CourseDetails { set; get; }
    }
}
