using IceCreamDesktop.Core.Entities;
using IceCreamDesktop.Core.Failures;
using IceCreamDesktop.Domain.Interfaces;
using Monad;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Threading.Tasks;
using Telerik.JustMock;
using Xunit;
using Xunit.Sdk;

namespace IceCreamDesktop.Domain.Usecases.Tests
{
    [Collection("IceCreamUseCases")]
    public class GetAllIceCreamTests
    {
        public static readonly IIceCreamRepository TRepository = Mock.Create<IIceCreamRepository>();

        public static readonly List<IceCream> TIceCreams = new List<IceCream> {
            new IceCream {
                Name = "IceCream1",
                Brand = "IceCream1Brand",
                ImageUrl = "https://www.osem.co.il/tm-content/uploads/2014/12/crunchVanilla-308x308.png"
            },
            new IceCream {
                Name = "IceCream2",
                Brand = "IceCream2Brand",
                ImageUrl = "https://www.osem.co.il/tm-content/uploads/2014/12/crunchVanilla-308x308.png"
            },
        };

        [AttributeUsage(AttributeTargets.Method, AllowMultiple = false, Inherited = true)]
        private class ClearMockAfter : BeforeAfterTestAttribute
        {
            public override void After(MethodInfo methodUnderTest)
            {
                Mock.Reset();
            }
        }

        [ClearMockAfter()]
        [Trait("Method", "Call")]
        [Fact(DisplayName = "Should return a list of ice creams when the repository is successful")]
        public async Task GetAllIceCreamTest1()
        {
            // Arrange
            Mock.Arrange(() => TRepository.GetAllIceCreams()).TaskResult(TIceCreams);
            GetAllIceCreams getAllIceCreams = new GetAllIceCreams(TRepository);
            GetAllIceCreamsArgs args = new GetAllIceCreamsArgs();

            // Act
            var result = await getAllIceCreams.Call(args);

            // Assert
            Assert.NotEmpty(result);
            Assert.Equal(TIceCreams.Count, result.Count);
        }
    }
}