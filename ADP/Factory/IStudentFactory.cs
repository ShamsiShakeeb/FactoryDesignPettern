using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ViewModel;

namespace ADP.Factory
{
    public interface IStudentFactory
    {
        Task Insert(StudentViewModel studentViewModel);
        Task Update(StudentViewModel studentViewModel);
        Task Delete(int id);
        Task<StudentViewModel> DetailsById(int id);
        Task DeleteByEmail(string email);
        Task<List<StudentTeacherRelationViewModel>> StudentTeacherRelationByStudentId(int id);
        Task<List<StudentTeacherRelationViewModel>> StudentTeacherRelation();
    }
}
