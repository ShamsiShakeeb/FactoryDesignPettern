using DAL;
using Entity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class StudentTeacherService : IStudentTeacherService
    {
        private readonly IStudentTeacherRepository _studentTeacherRepository;

        public StudentTeacherService(IStudentTeacherRepository studentTeacherRepository)
        {
            _studentTeacherRepository = studentTeacherRepository;
        }
        public async Task Insert(StudentTeacher studentTeacher)
        {
            await _studentTeacherRepository.Insert(studentTeacher);
        }
        public async Task Update(StudentTeacher studentTeacher)
        {
            await _studentTeacherRepository.Update(studentTeacher);
        }
        public async Task Delete(int id)
        {
            await _studentTeacherRepository.Delete(id);
        }
        public async Task<List<StudentTeacher>> Get(Expression<Func<StudentTeacher, bool>> expression)
        {
            var list = await _studentTeacherRepository.Get(expression).ToListAsync();
            return list;
        }
    }
}
