using IceCreamDesktop.Core.Entities;
using IceCreamDesktop.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace IceCreamDesktop.Domain.Usecases
{
    public class GetAllStore : IUsecase<List<Store>, GetAllStoreArgs>
    {
        private IStoreRepository Repository { get; }

        public GetAllStore(IStoreRepository repository)
        {
            Repository = repository;
        }

        public List<Store> Call(GetAllStoreArgs args)
        {
            return Repository.GetAllStore();
        }
    }

    public class GetAllStoreArgs : IArgs { }
}
