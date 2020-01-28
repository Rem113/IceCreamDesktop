using IceCreamDesktop.Core.Entities;
using IceCreamDesktop.Core.Failures;
using Monad;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IceCreamDesktop.Domain.Interfaces
{
    public interface IIceCreamRepository
    {
        Task<List<IceCream>> GetAllIceCreams();
        Task<Either<Failure, IceCream>> AddIceCream(IceCream iceCream);
        Task<Option<Failure>> RemoveIceCream(int id);
    }
}
