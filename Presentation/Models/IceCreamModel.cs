using IceCreamDesktop.Core.Entities;
using IceCreamDesktop.Core.Failures;
using IceCreamDesktop.Data.Datasources;
using IceCreamDesktop.Data.Interfaces;
using IceCreamDesktop.Data.Repositories;
using IceCreamDesktop.Domain.Interfaces;
using IceCreamDesktop.Domain.Usecases;
using Monad;
using System.Collections.Generic;
using System.Configuration;
using System.Threading.Tasks;

namespace IceCreamDesktop.Presentation.Models
{
    public class IceCreamModel
    {
        private IDatasource<IceCream> Datasource { get; }
        private IIceCreamRepository Repository { get; }

        public IceCreamModel()
        {
            Datasource = new IceCreamDatasource(ConfigurationManager.ConnectionStrings[0].ConnectionString);
            Repository = new IceCreamRepository(Datasource);
        }

        public Task<Either<Failure, List<IceCream>>> GetAllIceCream()
        {
            GetAllIceCream getAllIceCream = new GetAllIceCream(Repository);
            return getAllIceCream.Call(new GetAllIceCreamArgs());
        }
    }
}