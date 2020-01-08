using Xunit;
using IceCreamDesktop.Data.Datasources;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using Xunit.Sdk;
using System.Reflection;
using System.Data.SqlClient;
using IceCreamDesktop.Core.Entities;
using IceCreamDesktop.Core.Enums;
using IceCreamDesktop.Core.Exceptions;

namespace IceCreamDesktop.Data.Datasources.Tests
{
    public class StoreIceCreamDatasourceTests
    {
        public static readonly string ConnectionString = ConfigurationManager.ConnectionStrings[0].ConnectionString;

        public static readonly StoreIceCreamDatasource TStoreIceCreamDatasource = new StoreIceCreamDatasource(ConnectionString);

        public static readonly StoreIceCream TStoreIceCream = new StoreIceCream(
            id: "1",
            price: 2.5f,
            rating: Ratings.VERY_GOOD,
            description: "description",
            barCode: "123456"
        );

        public static readonly StoreIceCream TNoIdStoreIceCream = new StoreIceCream(
            price: 2.5f,
            rating: Ratings.VERY_GOOD,
            description: "description",
            barCode: "123456"
        );

        [AttributeUsage(AttributeTargets.Method, AllowMultiple = false, Inherited = true)]
        sealed class ClearStoreIceCreamDBAfter : BeforeAfterTestAttribute
        {
            public override void After(MethodInfo methodUnderTest)
            {
                using SqlConnection connection = new SqlConnection(ConnectionString);
                connection.Open();

                string sql = "DELETE FROM StoreIceCream";

                using SqlCommand command = new SqlCommand(sql, connection);
                command.ExecuteNonQuery();
            }
        }

        [ClearStoreIceCreamDBAfter()]
        [Trait("Method", "Create")]
        [Fact(DisplayName = "Should create a new id when necessary")]
        public async Task CreateTest1()
        {
            // Act
            var result = await TStoreIceCreamDatasource.Create(TNoIdStoreIceCream);

            // Assert
            Assert.NotNull(result.Id);
            Assert.Equal(TNoIdStoreIceCream.Price, result.Price);
            Assert.Equal(TNoIdStoreIceCream.Rating, result.Rating);
            Assert.Equal(TNoIdStoreIceCream.Description, result.Description);
            Assert.Equal(TNoIdStoreIceCream.BarCode, result.BarCode);
        }

        [ClearStoreIceCreamDBAfter()]
        [Trait("Method", "FindById")]
        [Fact(DisplayName = "Should return the store ice cream when the id exists")]
        public async Task FindByIdTest1()
        {
            // Arrange
            var createdIceCream = await TStoreIceCreamDatasource.Create(TStoreIceCream);

            // Act
            var result = await TStoreIceCreamDatasource.FindById(createdIceCream.Id);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(createdIceCream.Id, result.Id);
        }

        [ClearStoreIceCreamDBAfter()]
        [Trait("Method", "FindById")]
        [Fact(DisplayName = "Should throw an exception when the id does not exist")]
        public async Task FindByIdTest2()
        {
            // Act
            static async Task func() => await TStoreIceCreamDatasource.FindById("1");

            // Assert
            await Assert.ThrowsAsync<NotFoundException>(func);
        }

        [ClearStoreIceCreamDBAfter()]
        [Trait("Method", "FindAll")]
        [Fact(DisplayName = "Should return an empty list when there are no store ice creams")]
        public async Task FindAllTest1()
        {
            // Act
            var result = await TStoreIceCreamDatasource.FindAll();

            // Assert
            Assert.Empty(result);
        }

        [ClearStoreIceCreamDBAfter()]
        [Trait("Method", "FindAll")]
        [Fact(DisplayName = "Should return all the store ice creams when present")]
        public async Task FindAllTest2()
        {
            // Arrange
            await TStoreIceCreamDatasource.Create(TStoreIceCream);
            await TStoreIceCreamDatasource.Create(TStoreIceCream);

            // Act
            var result = await TStoreIceCreamDatasource.FindAll();

            // Assert
            Assert.Equal(2, result.Count);
        }

        [ClearStoreIceCreamDBAfter()]
        [Trait("Method", "Update")]
        [Fact(DisplayName = "Should update the store ice cream when present")]
        public async Task UpdateTest1()
        {
            // Arrange
            var createdIceCream = await TStoreIceCreamDatasource.Create(TStoreIceCream);
            var updatedIceCream = new StoreIceCream(
                price: TStoreIceCream.Price + 2,
                rating: Ratings.VERY_BAD,
                description: $"{TStoreIceCream.Description}Updated",
                barCode: $"{TStoreIceCream.BarCode}Updated"
            );

            // Act
            var result = await TStoreIceCreamDatasource.Update(createdIceCream.Id, updatedIceCream);

            // Assert
            Assert.Equal(createdIceCream.Id, result.Id);
            Assert.Equal(updatedIceCream.Price, result.Price);
            Assert.Equal(updatedIceCream.Rating, result.Rating);
            Assert.Equal(updatedIceCream.Description, result.Description);
            Assert.Equal(updatedIceCream.BarCode, result.BarCode);
        }

        [ClearStoreIceCreamDBAfter()]
        [Trait("Method", "Update")]
        [Fact(DisplayName = "Should throw an exception when the store ice cream does not exist")]
        public async Task UpdateTest2()
        {
            // Act
            async Task func() => await TStoreIceCreamDatasource.Update("1", TStoreIceCream);

            // Arrange
            await Assert.ThrowsAsync<NotFoundException>(func);
        }

        [ClearStoreIceCreamDBAfter()]
        [Trait("Method", "Delete")]
        [Fact(DisplayName = "Should delete the store ice cream when present")]
        public async Task DeleteTest1()
        {
            // Arrange
            var createdIceCream = await TStoreIceCreamDatasource.Create(TStoreIceCream);

            // Act & Assert
            await TStoreIceCreamDatasource.Delete(createdIceCream.Id);
        }

        [ClearStoreIceCreamDBAfter()]
        [Trait("Method", "Delete")]
        [Fact(DisplayName = "Should throw an exception when the store ice cream does not exist")]
        public async Task DeleteTest2()
        {
            // Act
            async Task func() => await TStoreIceCreamDatasource.Delete("1");

            // Assert
            await Assert.ThrowsAsync<NotFoundException>(func);
        }
    }
}