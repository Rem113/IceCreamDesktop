using IceCreamDesktop.Core.Entities;
using IceCreamDesktop.Core.Failures;
using IceCreamDesktop.Domain.Interfaces;
using Monad;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace IceCreamDesktop.Domain.Usecases
{
    public class GetAllIceCreams : IUsecase<List<IceCream>, GetAllIceCreamsArgs>
    {
        private readonly IIceCreamRepository Repository;

        public GetAllIceCreams(IIceCreamRepository repository)
        {
            Repository = repository;
        }

        public Task<List<IceCream>> Call(GetAllIceCreamsArgs args)
        {
            return Repository.GetAllIceCreams();
        }
    }

    public class GetAllIceCreamsArgs : IArgs
    {
    }
}