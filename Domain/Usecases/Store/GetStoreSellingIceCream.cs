using IceCreamDesktop.Core.Entities;
using IceCreamDesktop.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IceCreamDesktop.Domain.Usecases
{
	public class GetStoreSellingIceCream : IUsecase<List<Store>, GetStoreSellingIceCreamArgs>
	{
		private IStoreRepository Repository { get; set; }

		public GetStoreSellingIceCream(IStoreRepository repository)
		{
			Repository = repository;
		}

		public Task<List<Store>> Call(GetStoreSellingIceCreamArgs args)
		{
			return Repository.GetStoreSellingIceCream(args.IceCreamId);
		}
	}

	public class GetStoreSellingIceCreamArgs : IArgs
	{
		public int IceCreamId { get; set; }

		public GetStoreSellingIceCreamArgs(int iceCreamId)
		{
			IceCreamId = iceCreamId;
		}
	}
}