using Xunit;
using IceCreamDesktop.Data.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IceCreamDesktop.Data.Repositories.Tests
{
    [Collection("IceCreamRepository")]
    public class IceCreamRepositoryTests
    {
        [Trait("Method", "GetAllIceCreams")]
        [Fact(DisplayName = "Should")]
        public async Task GetAllIceCreamsTest()
        {
            var kiosk = new KioskContext();

            var iceCreams = kiosk.IceCreams.Any();

            // Assert.True(false, "This test needs an implementation");
        }

        [Fact()]
        public void AddIceCreamTest()
        {
            Assert.True(false, "This test needs an implementation");
        }
    }
}