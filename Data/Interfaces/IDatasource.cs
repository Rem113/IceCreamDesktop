using System.Collections.Generic;
using System.Threading.Tasks;

namespace IceCreamDesktop.Data.Interfaces
{
    public interface IDatasource<Type>
    {
        Task<List<Type>> FindAll();
        Task<Type> FindById(string id);
        Task<Type> Create(Type data);
        Task<Type> Update(string id, Type data);
        Task<bool> Delete(string id);
    }
}
