using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Entity
{
    public class TeacherCourse : BaseEntity
    {
        [ForeignKey("Teacher")]
        public int TeacherId { set; get; }
        public Teacher Teacher { set; get; }
        [ForeignKey("Course")]
        public int CourseId { set; get; }
        public Course Course { set; get; }
    }
}
