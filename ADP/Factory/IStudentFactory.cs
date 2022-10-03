using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ViewModel;

namespace ADP.Factory
{
    public interface IStudentFactory : IGenericFactory<Student>
    {
        Task DeleteByEmail(string email);
        Task<List<StudentTeacherRelationViewModel>> StudentTeacherRelationByStudentId(int id);
        Task<List<StudentTeacherRelationViewModel>> StudentTeacherRelation();
        Task<List<StudentViewModel>> Get(string address);
    }
}
