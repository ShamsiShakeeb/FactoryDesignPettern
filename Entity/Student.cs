using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Entity
{
    public class Student
    {
        [Key]
        public int Id { set; get; }
        [Required]
        [MaxLength(50)]
        [MinLength(3)]
        public string Name { set; get; }
        [Required]
        [MaxLength(100)]
        [MinLength(3)]
        public string Email { set; get; }
        [Required]
        [MaxLength(250)]
        [MinLength(6)]
        public string Address { set; get; }
        [Required]
        public double Cgpa { set; get; }
        public List<StudentTeacher> StudentTeachers { set; get; }
        public List<StudentCourse> StudentCourses { set; get; }
    }
}
