using System.Collections.Generic;

namespace IceCreamDesktop.Data.Interfaces
{
    public interface IModel<Type>
    {
        List<Type> FindAll();
        Type FindById();
        Type Create(Type data);
        Type Update(string id, Type data);
        bool Delete(string id);
    }
}
