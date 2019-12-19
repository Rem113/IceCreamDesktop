using Microsoft.VisualStudio.TestTools.UnitTesting;
using IceCreamDesktop.Domain.Usecases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IceCreamDesktop.Data.Repositories;
using IceCreamDesktop.Data.Models;
using Monad;
using IceCreamDesktop.Core.Entities;

namespace IceCreamDesktop.Domain.Usecases.Tests
{
    [TestClass()]
    public class GetAllIceCreamTests
    {
        [TestMethod()]
        public void CallTest()
        {
            IceCreamModel iceCreamModel = new IceCreamModel();
            IceCreamRepository iceCreamRepository = new IceCreamRepository(iceCreamModel);
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