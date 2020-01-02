using IceCreamDesktop.Core.Entities;
using IceCreamDesktop.Core.Failures;
using Monad;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace IceCreamDesktop.Domain.Interfaces
{
    public interface IIceCreamRepository
    {
        Task<Either<Failure, List<IceCream>>> GetAllIceCream();
        Task<Either<Failure, IceCream>> AddIceCream(IceCream iceCream);
    }
}
