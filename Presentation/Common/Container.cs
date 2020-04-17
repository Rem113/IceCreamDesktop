using Autofac;
using IceCreamDesktop.Data;
using IceCreamDesktop.Data.Repositories;
using IceCreamDesktop.Domain.Interfaces;
using IceCreamDesktop.Domain.Usecases;

namespace IceCreamDesktop.Presentation.Common
{
	public static class Injector
	{
		private static IContainer Container { get; set; }

		public static void Init()
		{
			var builder = new ContainerBuilder();

			// Data
			builder.RegisterType<KioskContext>().SingleInstance().AsSelf();

			builder.RegisterType<IceCreamRepository>().SingleInstance().As<IIceCreamRepository>();
			builder.RegisterType<StoreRepository>().SingleInstance().As<IStoreRepository>();
			builder.RegisterType<ProductRepository>().SingleInstance().As<IProductRepository>();
			builder.RegisterType<ReviewRepository>().SingleInstance().As<IReviewRepository>();

			// Domain
			builder.RegisterType<AddIceCream>().SingleInstance();
			builder.RegisterType<GetAllIceCreams>().SingleInstance();
			builder.RegisterType<RemoveIceCream>().SingleInstance();

			builder.RegisterType<AddProduct>().SingleInstance();
			builder.RegisterType<GetProductsForStore>().SingleInstance();

			builder.RegisterType<AddStore>().SingleInstance();
			builder.RegisterType<GetAllStores>().SingleInstance();
			builder.RegisterType<RemoveStore>().SingleInstance();

			builder.RegisterType<GetReviewForProduct>().SingleInstance();
			builder.RegisterType<AddReview>().SingleInstance();
			builder.RegisterType<RemoveProduct>().SingleInstance();

			Container = builder.Build();
		}

		public static T Resolve<T>()
		{
			return Container.Resolve<T>();
		}
	}
}