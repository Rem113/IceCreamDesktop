using System.Collections.Generic;
using System.Threading.Tasks;

using Microsoft.VisualStudio.TestTools.UnitTesting;
using Monad;
using Telerik.JustMock;

using IceCreamDesktop.Core.Entities;
using IceCreamDesktop.Domain.Interfaces;
using IceCreamDesktop.Core.Failures;

namespace IceCreamDesktop.Domain.Usecases.Tests
{
    [TestClass()]
    public class GetAllIceCreamTests
    {
        [TestMethod()]
        public async Task CallTest()
        {
            IIceCreamRepository iceCreamRepository = Mock.Create<IIceCreamRepository>();

            IceCream tIceCream = new IceCream(name: "Extreme", brand: "Nestle", imageUrl: "google.fr");

            Mock
                .Arrange(() => iceCreamRepository.GetAllIceCream())
                .Returns(Task.FromResult<Either<Failure, List<IceCream>>>(() => new List<IceCream> { tIceCream }));

            GetAllIceCream getAllIceCream = new GetAllIceCream(iceCreamRepository);

            var result = await getAllIceCream.Call(new GetAllIceCreamArgs());

            result.Match(
                Left: failure =>
                {
                    Assert.Fail(failure.Message);
                },
                Right: response =>
                {
                    var iceCreams = response as List<IceCream>;
                    Assert.AreEqual(iceCreams.Count, 1);
                    Assert.AreEqual(iceCreams[0], tIceCream);
                    Mock.GetTimesCalled(() => iceCreamRepository.GetAllIceCream()).Equals(1);
                }
            )();
        }
    }
}