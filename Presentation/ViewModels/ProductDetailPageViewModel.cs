using IceCreamDesktop.Core.Entities;
using IceCreamDesktop.Presentation.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IceCreamDesktop.Presentation.ViewModels
{
	public class ProductDetailPageViewModel : PageViewModel
	{
		public Product Product { get; set; }

		public ProductDetailPageViewModel(Product product)
		{
			Product = product;
		}
	}
}