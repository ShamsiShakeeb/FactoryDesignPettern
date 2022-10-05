using AutoMapper;
using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ViewModel;

namespace ADP.Models
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Student, StudentViewModel>().ReverseMap();
            CreateMap<Teacher, TeacherViewModel>().ReverseMap();
            CreateMap<Course, CourseViewModel>().ReverseMap();
            CreateMap<Report, ReportViewModel>().ReverseMap();
        }
    }
}
