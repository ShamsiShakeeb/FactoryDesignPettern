using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ADP.Factory
{
    public interface IGenericFactory<TEntity> where TEntity : BaseEntity,new()
    {
        Task Insert<TViewModel>(TViewModel model) where TViewModel : class;
        Task Update<TViewModel>(int id, TViewModel model) where TViewModel : class;
        Task Delete(int id);
        Task<List<TViewModel>> Get<TViewModel>() where TViewModel : class;
        Task<TViewModel> DetailsById<TViewModel>(int id) where TViewModel : class;
    }
}
