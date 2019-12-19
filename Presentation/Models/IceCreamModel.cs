using IceCreamDesktop.Core.Entities;
using IceCreamDesktop.Core.Failures;
using IceCreamDesktop.Data.Datasources;
using IceCreamDesktop.Data.Interfaces;
using IceCreamDesktop.Data.Repositories;
using IceCreamDesktop.Domain.Interfaces;
using IceCreamDesktop.Domain.Usecases;
using Monad;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IceCreamDesktop.Presentation.Models
{
    public class IceCreamModel
    {
        private IDatasource<IceCream> Datasource { get; }
        private IIceCreamRepository Repository { get; }

        public IceCreamModel()
        {
            Datasource = new IceCreamDatasource();
            Repository = new IceCreamRepository(Datasource);
        }

        public Either<IceCreamFailure, List<IceCream>> GetAllIceCream()
        {
            GetAllIceCream getAllIceCream = new GetAllIceCream(Repository);
            return getAllIceCream.Call(new GetAllIceCreamArgs());
        }
    }
}
