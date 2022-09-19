using AutoMapper;
using BLL;
using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using ViewModel;

namespace ADP.Factory
{
    public class StudentFactory : IStudentFactory
    {
        private readonly IStudentService _studentService;
        private readonly IStudentTeacherService _studentTeacherService;
        private readonly ITeacherService _teacherService;
        private readonly IMapper _mapper;
        public StudentFactory(IStudentService studentService,
            IMapper mapper,
            IStudentTeacherService studentTeacherService,
            ITeacherService teacherService)
        {
            _studentService = studentService;
            _studentTeacherService = studentTeacherService;
            _teacherService = teacherService;
            _mapper = mapper;
        }
        public async Task Insert(StudentViewModel studentViewModel)
        {
             var student = _mapper.Map<Student>(studentViewModel);
            await _studentService.Insert(student);
        }
        public async Task Update(StudentViewModel studentViewModel)
        {
            var student = _mapper.Map<Student>(studentViewModel);
            await _studentService.Update(student);
        }
        public async Task Delete(int id)
        {
            await _studentService.Delete(id);
        }
        public async Task<StudentViewModel> DetailsById(int id)
        {
             var list = await _studentService.Get(x=> x.Id == id);
             var data = list.FirstOrDefault();
             var model = _mapper.Map<StudentViewModel>(data);
             return model;
        }
        public async Task DeleteByEmail(string email)
        {
            var list = await _studentService.Get(x => x.Email == email);
            var data = list.FirstOrDefault();
            await _studentService.Delete(data.Id);
        }

        public async Task<List<StudentTeacherRelationViewModel>> StudentTeacherRelationByStudentId(int id)
        {
            var studentTeacher = await _studentTeacherService.Get(x => x.StudentId == id);
            var teacher = await _teacherService.Get(x=> true);
            var student = await _studentService.Get(x => x.Id == id);

            var data = (from a in studentTeacher
                        join b in teacher
                        on a.TeacherId equals b.Id
                        select new StudentTeacherRelationViewModel()
                        {
                            StudentName = student.FirstOrDefault()?.Name,
                            StudentEmail = student.FirstOrDefault()?.Email,
                            TeacherName = b.Name,
                            TeacherEmail = b.Email,
                            TeacherAddress = b.Address
                        }).ToList();

            return data;
        }
        public async Task<List<StudentTeacherRelationViewModel>> StudentTeacherRelation()
        {
            var studentTeacher = await _studentTeacherService.Get(x=> true);
            var teacher = await _teacherService.Get(x => true);
            var student = await _studentService.Get(x=> true);

            var data = (from a in studentTeacher
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
                        }).ToList();

            return data;
        }
    }
}
