using IceCreamDesktop.Core.Entities;
using IceCreamDesktop.Core.Failures;
using Monad;
using System.Collections.Generic;

namespace IceCreamDesktop.Domain.Interfaces
{
    public interface IIceCreamRepository
    {
        Either<IceCreamFailure, List<IceCream>> GetAllIceCream();
    }
}
