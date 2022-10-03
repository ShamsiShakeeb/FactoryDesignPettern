using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Entity
{
    public class StudentCourse : BaseEntity
    {
        [ForeignKey("Student")]
        public int StudentId { set; get; }
        public Student Student { set; get; }

        [ForeignKey("Course")]
        public int CourseId { set; get; }
        public Course Course { set; get; }
    }
}
