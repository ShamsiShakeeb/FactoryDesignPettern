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
    public class TeacherFactory: GenericFactory<Teacher> , ITeacherFactory
    {
        private readonly IGenericService<Student> _studentService;
        private readonly IGenericService<StudentTeacher> _studentTeacherService;
        private readonly IGenericService<Teacher> _teacherService;

        private readonly IMapper _mapper;
        public TeacherFactory(
            IMapper mapper,
            IGenericService<Student> studentService,
            IGenericService<StudentTeacher> studentTeacherService,
            IGenericService<Teacher> teacherService)

            : base(teacherService, mapper)
        {
            _mapper = mapper;
            _studentService = studentService;
            _studentTeacherService = studentTeacherService;
            _teacherService = teacherService;

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
