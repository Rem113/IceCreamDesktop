using IceCreamDesktop.Core.Entities;
using IceCreamDesktop.Core.Failures;
using IceCreamDesktop.Domain.Interfaces;
using Monad;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace IceCreamDesktop.Domain.Usecases
{
    public class GetAllIceCream : IUsecase<Either<Failure, List<IceCream>>, GetAllIceCreamArgs>
    {
        private IIceCreamRepository Repository;

        public GetAllIceCream(IIceCreamRepository repository)
        {
            Repository = repository;
        }

        public Task<Either<Failure, List<IceCream>>> Call(GetAllIceCreamArgs args)
        {
            return Repository.GetAllIceCream();
        }
    }

    public class GetAllIceCreamArgs : IArgs
    {
    }
}
