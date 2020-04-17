using IceCreamDesktop.Core.Entities;
using IceCreamDesktop.Domain.Interfaces;
using System;
using System.Reflection;
using System.Threading.Tasks;
using Telerik.JustMock;
using Xunit;
using Xunit.Sdk;

namespace IceCreamDesktop.Domain.Usecases.Tests
{
	[Collection("IceCreamUseCases")]
	public class AddIceCreamTests
	{
		public static readonly IIceCreamRepository TRepository = Mock.Create<IIceCreamRepository>();

		public static readonly IceCream TIceCream = new IceCream
		{
			Name = "Crunch Vanilla",
			Brand = "Nestle",
			ImageUrl = "https://www.osem.co.il/tm-content/uploads/2014/12/crunchVanilla-308x308.png",
			Energy = 0.0,
			Fat = 0.0
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
		public async Task AddIceCreamTest1()
		{
			// Arrange
			Mock.Arrange(() => TRepository.AddIceCream(TIceCream)).TaskResult(() => TIceCream);
			AddIceCream addIceCream = new AddIceCream(TRepository);
			AddIceCreamArgs args = new AddIceCreamArgs(TIceCream);

			// Act
			var result = await addIceCream.Call(args);

			// Assert
		}
	}
}