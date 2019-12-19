using Microsoft.VisualStudio.TestTools.UnitTesting;
using IceCreamDesktop.Domain.Usecases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IceCreamDesktop.Data.Repositories;
using Monad;
using IceCreamDesktop.Core.Entities;
using IceCreamDesktop.Data.Datasources;

namespace IceCreamDesktop.Domain.Usecases.Tests
{
    [TestClass()]
    public class GetAllIceCreamTests
    {
        [TestMethod()]
        public void CallTest()
        {
            IceCreamDatasource iceCreamDatasource = new IceCreamDatasource();
            IceCreamRepository iceCreamRepository = new IceCreamRepository(iceCreamDatasource);
            GetAllIceCream getAllIceCream = new GetAllIceCream(iceCreamRepository);
            GetAllIceCreamArgs args = new GetAllIceCreamArgs();

            var result = getAllIceCream.Call(args);

            if (result.IsLeft()) Assert.Fail(result.Left().Message);

            foreach (IceCream iceCream in result.Right())
            {
                Console.WriteLine($"Id: {iceCream.Id}");
                Console.WriteLine($"Name: {iceCream.Name}");
                Console.WriteLine($"Brand: {iceCream.Brand}");
                Console.WriteLine($"ImageUrl: {iceCream.ImageUrl}");
            }
        }
    }
}