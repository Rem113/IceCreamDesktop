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
            new IceCream(
                name: "IceCream1",
                brand: "IceCream1Brand",
                imageUrl: "https://www.osem.co.il/tm-content/uploads/2014/12/crunchVanilla-308x308.png"
            ),
            new IceCream(
                name: "IceCream2",
                brand: "IceCream2Brand",
                imageUrl: "https://www.osem.co.il/tm-content/uploads/2014/12/crunchVanilla-308x308.png"
            ),
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
            Mock.Arrange(() => TRepository.GetAllIceCream()).TaskResult(() => TIceCreams);
            GetAllIceCream getAllIceCream = new GetAllIceCream(TRepository);
            GetAllIceCreamArgs args = new GetAllIceCreamArgs();

            // Act
            var result = await getAllIceCream.Call(args);

            // Assert
            result.Match(
                Left: failure => Assert.True(false, failure.Message),   // Fails
                Right: iceCreams =>
                {
                    Assert.Equal(TIceCreams.Count, iceCreams.Count);
                }
            ).Invoke();
        }

        [ClearMockAfter()]
        [Trait("Method", "Call")]
        [Fact(DisplayName = "Should return a failure when the repository fails")]
        public async Task GetAllIceCreamTest2()
        {
            // Arrange
            Mock.Arrange(() => TRepository.GetAllIceCream()).TaskResult(() => new DataAccessFailure());
            GetAllIceCream getAllIceCream = new GetAllIceCream(TRepository);
            GetAllIceCreamArgs args = new GetAllIceCreamArgs();

            // Act
            var result = await getAllIceCream.Call(args);

            // Assert
            Assert.True(result.IsLeft(), "Should return a failure");
        }
    }
}