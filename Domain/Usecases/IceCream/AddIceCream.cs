using IceCreamDesktop.Core.Entities;
using IceCreamDesktop.Core.Failures;
using IceCreamDesktop.Domain.Interfaces;
using Monad;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IceCreamDesktop.Domain.Usecases
{
    public class AddIceCream : IUsecase<Either<IceCreamFailure, IceCream>, AddIceCreamArgs>
    {
        private IIceCreamRepository Repository;

        public AddIceCream(IIceCreamRepository repository)
        {
            Repository = repository;
        }

        public Either<IceCreamFailure, IceCream> Call(AddIceCreamArgs args)
        {
            return Repository.AddIceCream(args.IceCream);
        }
    }

    public class AddIceCreamArgs : IArgs
    {
        public IceCream IceCream { get; }

        public AddIceCreamArgs(IceCream iceCream)
        {
            IceCream = iceCream;
        }
    }
}
