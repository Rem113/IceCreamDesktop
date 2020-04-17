﻿using IceCreamDesktop.Core.Entities;
using IceCreamDesktop.Core.Failures;
using IceCreamDesktop.Domain.Interfaces;
using Monad;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IceCreamDesktop.Data.Repositories
{
	public class ProductRepository : IProductRepository
	{
		private KioskContext Kiosk { get; set; }

		public ProductRepository(KioskContext kiosk)
		{
			Kiosk = kiosk;
		}

		public Task<Either<Failure, Product>> AddProductToStore(Product product)
		{
			throw new NotImplementedException();
		}

		public Task<List<Product>> GetProductsOfStore(int storeId)
		{
			return Task.FromResult(Kiosk.Products.Where(product => product.Store.Id == storeId).ToList());
		}
	}
}