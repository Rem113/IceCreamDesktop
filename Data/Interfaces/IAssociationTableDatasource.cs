using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IceCreamDesktop.Data.Interfaces
{
    public interface IAssociationTableDatasource
    {
        Task<List<string>> FindByLeftId(string leftId);
        Task Create(string leftId, string rightId);
        Task Delete(string leftId, string rightId);
    }
}
