using IceCreamDesktop.Core.Entities;
using IceCreamDesktop.Core.Failures;
using IceCreamDesktop.Data.Interfaces;
using IceCreamDesktop.Data.Models;
using IceCreamDesktop.Domain.Interfaces;
using Monad;
using System;
using System.Collections.Generic;

namespace IceCreamDesktop.Data.Repositories
{
    public class IceCreamRepository : IIceCreamRepository
    {
        private IModel<IceCream> IceCreamModel;

        public IceCreamRepository(IModel<IceCream> iceCreamModel)
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
