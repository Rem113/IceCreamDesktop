using IceCreamDesktop.Core.Entities;
using IceCreamDesktop.Core.Failures;
using IceCreamDesktop.Domain.Interfaces;
using Monad;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IceCreamDesktop.Data.Repositories
{
	public class IceCreamRepository : IIceCreamRepository
	{
		private readonly KioskContext Kiosk;

		public IceCreamRepository(KioskContext kiosk)
		{
			Kiosk = kiosk;
		}

		public Task<List<IceCream>> GetAllIceCreams()
		{
			if (Kiosk.IceCreams.Any())
				return Task.FromResult(Kiosk.IceCreams.ToList());
			return Task.FromResult(new List<IceCream>());
		}

		public async Task<Either<Failure, IceCream>> AddIceCream(IceCream iceCream)
		{
			try
			{
				Kiosk.IceCreams.Add(iceCream);
				await Kiosk.SaveChangesAsync();
				return () => iceCream;
			}
			catch (Exception)
			{
				return () => new DataAccessFailure("An error has occured");
			}
		}

		public async Task<Option<Failure>> RemoveIceCream(int id)
		{
			var matches = Kiosk.IceCreams.Where(iceCream => id == iceCream.Id).ToList();

			if (!matches.Any())
				return () => new DataAccessFailure("You can't delete this ice cream!");

			Kiosk.IceCreams.Remove(matches.First());
			await Kiosk.SaveChangesAsync();

			return Option.Nothing<Failure>();
		}

		public Task<List<IceCream>> GetStoreMissingIceCream(int storeId)
		{
			var iceCreams = Kiosk.IceCreams.ToList();
			var products = Kiosk.Products.Where(product => product.Store.Id == storeId).ToList();

			products.ForEach(p => iceCreams.Remove(p.IceCream));

			return Task.FromResult(iceCreams);
		}
	}
}