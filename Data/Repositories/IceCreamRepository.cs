using IceCreamDesktop.Core.Entities;
using IceCreamDesktop.Core.Failures;
using IceCreamDesktop.Data.Interfaces;
using IceCreamDesktop.Data.Datasources;
using IceCreamDesktop.Domain.Interfaces;
using Monad;
using System;
using System.Collections.Generic;

namespace IceCreamDesktop.Data.Repositories
{
    public class IceCreamRepository : IIceCreamRepository
    {
        private IDatasource<IceCream> IceCreamDatasource;

        public IceCreamRepository(IDatasource<IceCream> iceCreamDatasource)
        {
            IceCreamDatasource = iceCreamDatasource;
        }

        public Either<IceCreamFailure, IceCream> AddIceCream(IceCream iceCream)
        {
            try
            {
                IceCream result = IceCreamDatasource.Create(iceCream);
                return () => result;
            } catch (Exception)
            {
                return () => new IceCreamFailure("Could not add a new ice cream");
            }
        }

        public Either<IceCreamFailure, List<IceCream>> GetAllIceCream()
        {
            try
            {
                List<IceCream> result = IceCreamDatasource.FindAll();
                return () => result;
            }
            catch (Exception)
            {
                return () => new IceCreamFailure("Could not get all ice creams");
            }
        }
    }
}
