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
			builder.RegisterType<KioskContext>().AsSelf();

			builder.RegisterType<IceCreamRepository>().As<IIceCreamRepository>();
			builder.RegisterType<StoreRepository>().As<IStoreRepository>();

			// Domain
			builder.RegisterType<AddIceCream>();
			builder.RegisterType<GetAllIceCreams>();
			builder.RegisterType<RemoveIceCream>();

			builder.RegisterType<AddProduct>();

			builder.RegisterType<AddStore>();
			builder.RegisterType<GetAllStores>();
			builder.RegisterType<RemoveStore>();

			Container = builder.Build();
		}

		public static T Resolve<T>()
		{
			return Container.Resolve<T>();
		}
	}
}