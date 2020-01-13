﻿using IceCreamDesktop.Core.Entities;
using IceCreamDesktop.Core.Failures;
using IceCreamDesktop.Domain.Interfaces;
using Monad;
using System.Threading.Tasks;

namespace IceCreamDesktop.Domain.Usecases
{
    public class AddIceCream : IUsecase<Either<Failure, IceCream>, AddIceCreamArgs>
    {
        private readonly IIceCreamRepository Repository;

        public AddIceCream(IIceCreamRepository repository)
        {
            Repository = repository;
        }

        public Task<Either<Failure, IceCream>> Call(AddIceCreamArgs args)
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