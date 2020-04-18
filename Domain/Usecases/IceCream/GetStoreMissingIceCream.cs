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
	public class GetStoreMissingIceCream : IUsecase<Either<Failure, List<IceCream>>, GetStoreMissingIceCreamArgs>
	{
		public IIceCreamRepository Repository { get; set; }

		public GetStoreMissingIceCream(IIceCreamRepository repository)
		{
			Repository = repository;
		}

		public async Task<Either<Failure, List<IceCream>>> Call(GetStoreMissingIceCreamArgs args)
		{
			try
			{
				var result = await Repository.GetStoreMissingIceCream(args.StoreId);

				return () => result;
			}
			catch (Exception e)
			{
				return () => new DataAccessFailure(e.Message);
			}
		}
	}

	public class GetStoreMissingIceCreamArgs : IArgs
	{
		public int StoreId { get; set; }

		public GetStoreMissingIceCreamArgs(int storeId)
		{
			StoreId = storeId;
		}
	}
}