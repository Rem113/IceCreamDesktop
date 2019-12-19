using IceCreamDesktop.Core.Entities;
using IceCreamDesktop.Core.Failures;
using IceCreamDesktop.Domain.Interfaces;
using Monad;
using System.Collections.Generic;

namespace IceCreamDesktop.Domain.Usecases
{
    public class GetAllIceCream : IUsecase<Either<IceCreamFailure, List<IceCream>>, GetAllIceCreamArgs>
    {
        private IIceCreamRepository Repository;

        public GetAllIceCream(IIceCreamRepository repository)
        {
            Repository = repository;
        }

        public Either<IceCreamFailure, List<IceCream>> Call(GetAllIceCreamArgs args)
        {
            return Repository.GetAllIceCream();
        }
    }

    public class GetAllIceCreamArgs : IArgs
    {
    }
}
