using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Entity
{
    public class StudentTeacher
    {
        [Key]
        public int Id { set; get; }
        [ForeignKey("Student")]
        public int StudentId { set; get; }
        public Student Student { set; get; }
        [ForeignKey("Teacher")]
        public int TeacherId { set; get; }
        public Teacher Teacher { set; get; }
    }
}
