using AutoMapper;
using BLL;
using Entity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using ViewModel;

namespace ADP.Factory
{
    public class TeacherFactory:ITeacherFactory
    {
        
        private readonly IStudentService _studentService;
        private readonly IStudentTeacherService _studentTeacherService;
        private readonly IStudentCourseService _studentCourseService;
        private readonly ITeacherService _teacherService;
        private readonly ITeacherCourseService _teacherCourseService;

        private readonly IMapper _mapper;
        public TeacherFactory(IStudentService studentService,
            IMapper mapper,
            IStudentTeacherService studentTeacherService,
            IStudentCourseService studentCourseService,
            ITeacherService teacherService,
            ITeacherCourseService teacherCourseService)
        {
            _studentService = studentService;
            _studentTeacherService = studentTeacherService;
            _studentCourseService = studentCourseService;
            _teacherService = teacherService;
            _teacherCourseService = teacherCourseService;
            _mapper = mapper;
        }
        public async Task Insert(TeacherViewModel teacherViewModel)
        {
            var teacher = _mapper.Map<Teacher>(teacherViewModel);
            await _teacherService.Insert(teacher);
        }
        public async Task Update(TeacherViewModel teacherViewModel)
        {
            var teacher = _mapper.Map<Teacher>(teacherViewModel);
            await _teacherService.Update(teacher);
        }
        public async Task Delete(int id)
        {
            var data = await _teacherService.GetEntity(x => x.Id == id);
            await _teacherService.Delete(data);
        }
        public async Task<List<TeacherViewModel>> Get()
        {
            var data = await _teacherService.GetListAsync(x => true);
            var list = _mapper.Map<List<Teacher>, List<TeacherViewModel>>(data);
            return list;
        }
        public async Task<TeacherViewModel> DetailsById(int id)
        {
            var data = await _teacherService.GetEntity(x => x.Id == id);
            var model = _mapper.Map<TeacherViewModel>(data);
            return model;
        }
        public async Task DeleteByEmail(string email)
        {
            var data = await _teacherService.GetEntity(x => x.Email == email);
            await _teacherService.Delete(data);
        }
        public async Task<List<StudentTeacherRelationViewModel>> StudentTeacherRelationByTeacherId(int id)
        {
            var studentTeacher = _studentTeacherService.Get(x => x.TeacherId == id);
            var student = _studentService.Get(x => true);
            var teacher = await _teacherService.GetEntity(x => x.Id == id);

            var data = (from a in studentTeacher
                        join b in student
                        on a.StudentId equals b.Id
                        select new StudentTeacherRelationViewModel()
                        {
                            StudentName = b.Name,
                            StudentEmail = b.Email,
                            TeacherName = teacher.Name,
                            TeacherEmail = teacher.Email,
                            TeacherAddress = teacher.Address
                        }).ToList();

            return data;
        }
        public async Task<List<StudentTeacherRelationViewModel>> StudentTeacherRelation()
        {
            var studentTeacher = _studentTeacherService.Get(x => true);
            var teacher = _teacherService.Get(x => true);
            var student = _studentService.Get(x => true);

            var data = await (from a in studentTeacher
                              join b in teacher
                              on a.TeacherId equals b.Id
                              join s in student
                              on a.StudentId equals s.Id
                              select new StudentTeacherRelationViewModel()
                              {
                                  StudentName = s.Name,
                                  StudentEmail = s.Email,
                                  TeacherName = b.Name,
                                  TeacherEmail = b.Email,
                                  TeacherAddress = b.Address
                              }).ToListAsync();

            return data;
        }

    }
}
