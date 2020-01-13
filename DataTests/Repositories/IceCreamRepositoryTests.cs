using IceCreamDesktop.Core.Entities;
using Monad;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using Telerik.JustMock;
using Xunit;
using Xunit.Sdk;

namespace IceCreamDesktop.Data.Repositories.Tests
{
    [Collection("IceCreamRepository")]
    public class IceCreamRepositoryTests
    {
        private static readonly KioskContext TKiosk = Mock.Create<KioskContext>();

        private static readonly IceCreamRepository TRepository = new IceCreamRepository(TKiosk);

        private static readonly IceCream TIceCream = new IceCream
        {
            Name = "Extreme",
            Brand = "Nestle",
            ImageUrl = "http://google.com/"
        };

        [Trait("Method", "AddIceCream")]
        [Fact(DisplayName = "Should add an ice cream when the data is valid")]
        public async Task AddIceCreamTest()
        {
            // Arrange
            Mock.Arrange(() => TKiosk.IceCreams.Add(TIceCream)).Returns(TIceCream);

            Assert.Equal(TKiosk.IceCreams.Add(TIceCream), TIceCream);

            // Act
            //var result = await TRepository.AddIceCream(TIceCream);

            //// Assert
            //Assert.True(result.IsRight());
        }

        [Fact()]
        public void GetAllIceCreamTest()
        {
            Assert.True(false, "This test needs an implementation");
        }
    }
}