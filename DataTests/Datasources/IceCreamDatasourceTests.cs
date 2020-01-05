using IceCreamDesktop.Core.Entities;
using IceCreamDesktop.Core.Exceptions;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Reflection;
using System.Threading.Tasks;
using Xunit;
using Xunit.Sdk;

namespace IceCreamDesktop.Data.Datasources.Tests
{
    [Collection("IceCreamDatasource")]
    public class IceCreamDatasourceTests
    {
        public static readonly string ConnectionString = ConfigurationManager.ConnectionStrings[0].ConnectionString;

        public static readonly IceCreamDatasource TIceCreamDatasource = new IceCreamDatasource(ConnectionString);

        public static readonly IceCream TIceCream = new IceCream(
            id: "1",
            name: "Vanilla",
            brand: "Crunch",
            imageUrl: "https://www.osem.co.il/tm-content/uploads/2014/12/crunchVanilla-308x308.png"
        );

        public static readonly IceCream TNoIdIceCream = new IceCream(
            name: "Vanilla",
            brand: "Crunch",
            imageUrl: "https://www.osem.co.il/tm-content/uploads/2014/12/crunchVanilla-308x308.png"
        );

        [AttributeUsage(AttributeTargets.Method, AllowMultiple = false, Inherited = true)]
        sealed class ClearIceCreamDBAfter : BeforeAfterTestAttribute
        {
            public override void After(MethodInfo methodUnderTest)
            {
                using SqlConnection connection = new SqlConnection(ConnectionString);
                connection.Open();

                string sql = "DELETE FROM IceCream";

                using SqlCommand command = new SqlCommand(sql, connection);
                command.ExecuteNonQuery();
            }
        }

        [ClearIceCreamDBAfter()]
        [Trait("Method", "Create")]
        [Fact(DisplayName = "Should create a new id when necessary")]
        public async Task CreateTest1()
        {
            // Act
            var result = await TIceCreamDatasource.Create(TNoIdIceCream);

            // Assert
            Assert.NotNull(result.Id);
            Assert.Equal(TNoIdIceCream.Name, result.Name);
            Assert.Equal(TNoIdIceCream.Brand, result.Brand);
            Assert.Equal(TNoIdIceCream.ImageUrl, result.ImageUrl);
        }

        [ClearIceCreamDBAfter()]
        [Trait("Method", "FindById")]
        [Fact(DisplayName = "Should return the ice cream when the id exists")]
        public async Task FindByIdTest1()
        {
            // Arrange
            var createdIceCream = await TIceCreamDatasource.Create(TIceCream);

            // Act
            var result = await TIceCreamDatasource.FindById(createdIceCream.Id);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(createdIceCream.Id, result.Id);
        }

        [ClearIceCreamDBAfter()]
        [Trait("Method", "FindById")]
        [Fact(DisplayName = "Should throw an exception when the id does not exist")]
        public async Task FindByIdTest2()
        {
            // Act
            static async Task func() => await TIceCreamDatasource.FindById("1");

            // Assert
            await Assert.ThrowsAsync<NotFoundException>(func);
        }

        [ClearIceCreamDBAfter()]
        [Trait("Method", "FindAll")]
        [Fact(DisplayName = "Should return an empty list when there are no ice creams")]
        public async Task FindAllTest1()
        {
            // Act
            var result = await TIceCreamDatasource.FindAll();

            // Assert
            Assert.Empty(result);
        }

        [ClearIceCreamDBAfter()]
        [Trait("Method", "FindAll")]
        [Fact(DisplayName = "Should return all the ice creams when present")]
        public async Task FindAllTest2()
        {
            // Arrange
            await TIceCreamDatasource.Create(TIceCream);
            await TIceCreamDatasource.Create(TIceCream);

            // Act
            var result = await TIceCreamDatasource.FindAll();

            // Assert
            Assert.Equal(2, result.Count);
        }

        [ClearIceCreamDBAfter()]
        [Trait("Method", "Update")]
        [Fact(DisplayName = "Should update the ice cream when present")]
        public async Task UpdateTest1()
        {
            // Arrange
            var createdIceCream = await TIceCreamDatasource.Create(TIceCream);
            var updatedIceCream = new IceCream(
                name: $"{TIceCream.Name}Updated",
                brand: $"{TIceCream.Brand}Updated",
                imageUrl: $"{TIceCream.ImageUrl}Updated"
            );

            // Act
            var result = await TIceCreamDatasource.Update(createdIceCream.Id, updatedIceCream);

            // Assert
            Assert.Equal(createdIceCream.Id, result.Id);
            Assert.Equal(updatedIceCream.Name, result.Name);
            Assert.Equal(updatedIceCream.Brand, result.Brand);
            Assert.Equal(updatedIceCream.ImageUrl, result.ImageUrl);
        }

        [ClearIceCreamDBAfter()]
        [Trait("Method", "Update")]
        [Fact(DisplayName = "Should throw an exception when the ice cream does not exist")]
        public async Task UpdateTest2()
        {
            // Act
            async Task func() => await TIceCreamDatasource.Update("1", TIceCream);

            // Arrange
            await Assert.ThrowsAsync<NotFoundException>(func);
        }

        [ClearIceCreamDBAfter()]
        [Trait("Method", "Delete")]
        [Fact(DisplayName = "Should delete the ice cream when present")]
        public async Task DeleteTest1()
        {
            // Arrange
            var createdIceCream = await TIceCreamDatasource.Create(TIceCream);

            // Act & Assert
            await TIceCreamDatasource.Delete(createdIceCream.Id);
        }

        [ClearIceCreamDBAfter()]
        [Trait("Method", "Delete")]
        [Fact(DisplayName = "Should throw an exception when the ice cream does not exist")]
        public async Task DeleteTest2()
        {
            // Act
            async Task func() => await TIceCreamDatasource.Delete("1");

            // Assert
            await Assert.ThrowsAsync<NotFoundException>(func);
        }
    }
}