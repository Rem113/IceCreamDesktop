using IceCreamDesktop.Core.Entities;
using IceCreamDesktop.Core.Failures;
using IceCreamDesktop.Domain.Interfaces;
using Monad;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace IceCreamDesktop.Data.Repositories
{
	public class StoreRepository : IStoreRepository
	{
		private readonly KioskContext Kiosk;

		public StoreRepository(KioskContext kiosk)
		{
			Kiosk = kiosk;
		}

		public async Task<Either<Failure, Store>> AddStore(Store store)
		{
			try
			{
				Kiosk.Stores.Add(store);
				await Kiosk.SaveChangesAsync();
				return () => store;
			}
			catch (Exception)
			{
				return () => new DataAccessFailure("An error has occured");
			}
		}

		public Task<List<Store>> GetAllStores()
		{
			if (Kiosk.Stores.Any())
				return Task.FromResult(Kiosk.Stores.ToList());
			return Task.FromResult(new List<Store>());
		}

		public Task<List<Store>> GetStoreSellingIceCream(int iceCreamId)
		{
			return Task.FromResult(Kiosk.Stores
				.Where(store => store.Products.Any(p => p.IceCream.Id == iceCreamId)).ToList());
		}

		public async Task<Option<Failure>> RemoveStore(int id)
		{
			var matches = Kiosk.Stores.Where(store => id == store.Id).ToList();

			if (!matches.Any())
				return () => new DataAccessFailure("You can't delete this store!");

			Kiosk.Stores.Remove(matches.First());
			await Kiosk.SaveChangesAsync();

			return Option.Nothing<Failure>();
		}
	}
}