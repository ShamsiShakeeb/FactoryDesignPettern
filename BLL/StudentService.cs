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
    public class StudentService : IStudentService
    {
        private readonly IStudentRepository _studentRepository;

        public StudentService(IStudentRepository studentRepository)
        {
            _studentRepository = studentRepository;
        }
        public async Task Insert(Student student)
        {
            await _studentRepository.Insert(student);
        }
        public async Task Update(Student student)
        {
            await _studentRepository.Update(student);
        }
        public async Task Delete(int id)
        {
            await _studentRepository.Delete(id);
        }
        public async Task<List<Student>> Get(Expression<Func<Student,bool>> expression)
        {
            var list = await _studentRepository.Get(expression).ToListAsync();
            return list;
        }

    }
}
