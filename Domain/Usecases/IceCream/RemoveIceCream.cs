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
	public class RemoveIceCream : IUsecase<Option<Failure>, RemoveIceCreamArgs>
	{
		private readonly IIceCreamRepository Repository;

		public RemoveIceCream(IIceCreamRepository repository)
		{
			Repository = repository;
		}

		public Task<Option<Failure>> Call(RemoveIceCreamArgs args)
		{
			return Repository.RemoveIceCream(args.Id);
		}
	}

	public class RemoveIceCreamArgs : IArgs
	{
		public int Id { get; }

		public RemoveIceCreamArgs(int id)
		{
			Id = id;
		}
	}
}
