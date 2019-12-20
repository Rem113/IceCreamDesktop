using Microsoft.VisualStudio.TestTools.UnitTesting;
using IceCreamDesktop.Data.Datasources;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IceCreamDesktop.Core.Entities;

namespace IceCreamDesktop.Data.Datasources.Tests
{
    [TestClass()]
    public class IceCreamDatasourceTests
    {
        [TestMethod()]
        public void FindAllTest()
        {
            IceCreamDatasource iceCreamDatasource = new IceCreamDatasource();
            List<IceCream> result = iceCreamDatasource.FindAll();

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
            IceCreamDatasource iceCreamDatasource = new IceCreamDatasource();
            IceCream result = iceCreamDatasource.FindById("1");

            Console.WriteLine(result.Id);
            Console.WriteLine(result.Name);
            Console.WriteLine(result.Brand);
            Console.WriteLine(result.ImageUrl);
        }

        [TestMethod()]
        public void CreateTest()
        {
            IceCream newIceCream = new IceCream("Vanilla", "Crunch", "https://www.osem.co.il/tm-content/uploads/2014/12/crunchVanilla-308x308.png");
            IceCreamDatasource iceCreamDatasource = new IceCreamDatasource();
            IceCream result = iceCreamDatasource.Create(newIceCream);

            Assert.IsNotNull(result.Id);
        }
    }
}