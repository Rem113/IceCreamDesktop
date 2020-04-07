using CommonServiceLocator;
using System;
using System.Collections.Generic;

namespace IceCreamDesktop.Presentation
{
	public class Container : IServiceLocator
	{
		private static Dictionary<Type, object> dictionnary = new Dictionary<Type, object>();

		private static Container instance = null;

		public static Container GetInstance()
		{
			if (instance == null) instance = new Container();
			return instance;
		}

		public IEnumerable<object> GetAllInstances(Type serviceType)
		{
			throw new NotImplementedException();
		}

		public IEnumerable<TService> GetAllInstances<TService>()
		{
			throw new NotImplementedException();
		}

		public object GetInstance(Type serviceType)
		{
			if (!dictionnary.ContainsKey(serviceType))
				throw new ActivationException();

			return dictionnary[serviceType];
		}

		public object GetInstance(Type serviceType, string key)
		{
			throw new NotImplementedException();
		}

		public TService GetInstance<TService>()
		{
			throw new NotImplementedException();
		}

		public TService GetInstance<TService>(string key)
		{
			throw new NotImplementedException();
		}

		public object GetService(Type serviceType)
		{
			throw new NotImplementedException();
		}
	}
}