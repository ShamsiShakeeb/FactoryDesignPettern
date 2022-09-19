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
    public class TeacherService : ITeacherService
    {
        private readonly ITeacherRepository _TeacherRepository;

        public TeacherService(ITeacherRepository TeacherRepository)
        {
            _TeacherRepository = TeacherRepository;
        }
        public async Task Insert(Teacher Teacher)
        {
            await _TeacherRepository.Insert(Teacher);
        }
        public async Task Update(Teacher Teacher)
        {
            await _TeacherRepository.Update(Teacher);
        }
        public async Task Delete(int id)
        {
            await _TeacherRepository.Delete(id);
        }
        public async Task<List<Teacher>> Get(Expression<Func<Teacher, bool>> expression)
        {
            var list = await _TeacherRepository.Get(expression).ToListAsync();
            return list;
        }
    }
}
