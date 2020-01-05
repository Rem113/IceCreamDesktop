using IceCreamDesktop.Core.Entities;
using IceCreamDesktop.Core.Failures;
using IceCreamDesktop.Data.Interfaces;
using IceCreamDesktop.Domain.Interfaces;
using Monad;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace IceCreamDesktop.Data.Repositories
{
    public class IceCreamRepository : IIceCreamRepository
    {
        private IDatasource<IceCream> IceCreamDatasource;

        public IceCreamRepository(IDatasource<IceCream> iceCreamDatasource)
        {
            IceCreamDatasource = iceCreamDatasource;
        }

        public async Task<Either<Failure, IceCream>> AddIceCream(IceCream iceCream)
        {
            try
            {
                IceCream result = await IceCreamDatasource.Create(iceCream);
                return () => result;
            }
            catch (Exception)
            {
                return () => new DataAccessFailure("Could not add a new ice cream");
            }
        }

        public async Task<Either<Failure, List<IceCream>>> GetAllIceCream()
        {
            try
            {
                List<IceCream> result = await IceCreamDatasource.FindAll();
                return () => result;
            }
            catch (Exception)
            {
                return () => new DataAccessFailure("Could not get all ice creams");
            }
        }
    }
}