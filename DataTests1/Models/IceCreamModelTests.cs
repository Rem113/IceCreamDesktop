using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using IceCreamDesktop.Core.Entities;

namespace IceCreamDesktop.Data.Models.Tests
{
    [TestClass()]
    public class IceCreamModelTests
    {
        [TestMethod()]
        public void FindAllTest()
        {
            IceCreamModel iceCreamModel = new IceCreamModel();
            List<IceCream> result = iceCreamModel.FindAll();

            foreach (IceCream iceCream in result)
            {
                Console.WriteLine(iceCream.Id);
                Console.WriteLine(iceCream.Name);
                Console.WriteLine(iceCream.Brand);
                Console.WriteLine(iceCream.ImageUrl);
            }
        }

        [TestMethod()]
        public void FindByIdTest()
        {
            IceCreamModel iceCreamModel = new IceCreamModel();
            IceCream result = iceCreamModel.FindById("1");

            Console.WriteLine(result.Id);
            Console.WriteLine(result.Name);
            Console.WriteLine(result.Brand);
            Console.WriteLine(result.ImageUrl);
        }
    }
}