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
    public class StudentFactory : GenericFactory<Student>, IStudentFactory
    {
        private readonly IStudentService _studentService;
        private readonly IStudentTeacherService _studentTeacherService;
        private readonly IStudentCourseService _studentCourseService;
        private readonly ITeacherService _teacherService;
        private readonly ITeacherCourseService _teacherCourseService;
        private readonly IMapper _mapper;
        public StudentFactory(IStudentService studentService,
            IMapper mapper,
            IStudentTeacherService studentTeacherService,
            ITeacherService teacherService,
            IGenericService<Student> genericService) : base(genericService, mapper)
        {
            _studentService = studentService;
            _studentTeacherService = studentTeacherService;
            _teacherService = teacherService;
            _mapper = mapper;
        }

        #region Uncommon
        public async Task DeleteByEmail(string email)
        {
            var data = await _studentService.GetEntity(x => x.Email == email);
            await _studentService.Delete(data);
        }
        public async Task<List<StudentTeacherRelationViewModel>> StudentTeacherRelationByStudentId(int id)
        {
            var studentTeacher = _studentTeacherService.Get(x => x.StudentId == id);
            var teacher = _teacherService.Get(x=> true);
            var student = await _studentService.GetEntity(x => x.Id == id);

            var data = (from a in studentTeacher
                        join b in teacher
                        on a.TeacherId equals b.Id
                        select new StudentTeacherRelationViewModel()
                        {
                            StudentName = student.Name,
                            StudentEmail = student.Email,
                            TeacherName = b.Name,
                            TeacherEmail = b.Email,
                            TeacherAddress = b.Address
                        }).ToList();

            return data;
        }
        public async Task<List<StudentTeacherRelationViewModel>> StudentTeacherRelation()
        {
            var studentTeacher =  _studentTeacherService.Get(x=> true);
            var teacher =  _teacherService.Get(x => true);
            var student =  _studentService.Get(x=> true);

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
        public async Task<List<StudentViewModel>> Get(string address)
        {
            var data = await _studentService.GetListAsync(x => x.Address==address);
            var list = _mapper.Map<List<Student>, List<StudentViewModel>>(data);
            return list;
        }
        #endregion
    }
}
