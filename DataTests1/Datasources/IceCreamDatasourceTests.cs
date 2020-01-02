using Microsoft.VisualStudio.TestTools.UnitTesting;
using IceCreamDesktop.Data.Datasources;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IceCreamDesktop.Core.Entities;

namespace IceCreamDesktop.Data.Datasources.Tests
{
    [TestClass()]
    public class IceCreamDatasourceTests
    {
        public readonly string ConnectionString = ConfigurationManager.ConnectionStrings[0].ConnectionString;

        [TestMethod()]
        public async Task CreateTest()
        {
            IceCream newIceCream = new IceCream("Vanilla", "Crunch", "https://www.osem.co.il/tm-content/uploads/2014/12/crunchVanilla-308x308.png");
            IceCreamDatasource iceCreamDatasource = new IceCreamDatasource(ConnectionString);
            IceCream result = await iceCreamDatasource.Create(newIceCream);

            Assert.IsNotNull(result.Id);
        }

        [TestMethod()]
        public async Task FindAllTest()
        {
            IceCreamDatasource iceCreamDatasource = new IceCreamDatasource(ConnectionString);
            List<IceCream> result = await iceCreamDatasource.FindAll();

            foreach (IceCream iceCream in result)
            {
                Console.WriteLine(iceCream.Id);
                Console.WriteLine(iceCream.Name);
                Console.WriteLine(iceCream.Brand);
                Console.WriteLine(iceCream.ImageUrl);
            }
        }

        [TestMethod()]
        public async Task FindByIdTest()
        {
            IceCreamDatasource iceCreamDatasource = new IceCreamDatasource(ConnectionString);
            IceCream result = await iceCreamDatasource.FindById("1");

            Console.WriteLine(result.Id);
            Console.WriteLine(result.Name);
            Console.WriteLine(result.Brand);
            Console.WriteLine(result.ImageUrl);
        }
    }
}