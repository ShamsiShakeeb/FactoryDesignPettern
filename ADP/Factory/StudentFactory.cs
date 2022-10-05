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
        private readonly IGenericService<Student> _studentService;
        private readonly IGenericService<StudentTeacher> _studentTeacherService;
        private readonly IGenericService<Teacher> _teacherService;
        private readonly IMapper _mapper;
        public StudentFactory(
            IMapper mapper,
            IGenericService<Student> studentService,
            IGenericService<StudentTeacher> studentTeacherService,
            IGenericService<Teacher> teacherService)

            : base(studentService, mapper)
        {
            _mapper = mapper;
            _studentService = studentService;
            _studentTeacherService = studentTeacherService;
            _teacherService = teacherService;

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
            var teacher = _teacherService.Get(x => true);
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
        public async Task<List<StudentViewModel>> GetStudentByAddress(string address)
        {
            var data = await _studentService.GetListAsync(x => x.Address == address);
            var list = _mapper.Map<List<Student>, List<StudentViewModel>>(data);
            return list;
        }
        #endregion
    }
}
