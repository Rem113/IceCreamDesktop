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
        private IDatasource<IceCream> IceCreamModel;

        public IceCreamRepository(IDatasource<IceCream> iceCreamModel)
        {
            IceCreamModel = iceCreamModel;
        }

        public Either<IceCreamFailure, List<IceCream>> GetAllIceCream()
        {
            try
            {
                List<IceCream> result = IceCreamModel.FindAll();
                return () => result;
            }
            catch (Exception)
            {
                return () => new IceCreamFailure("Could not get all ice creams");
            }
        }
    }
}
