using Xunit;
using IceCreamDesktop.Data.Datasources;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit.Sdk;
using System.Reflection;
using System.Data.SqlClient;
using System.Configuration;
using IceCreamDesktop.Core.Entities;
using IceCreamDesktop.Core.Exceptions;

namespace IceCreamDesktop.Data.Datasources.Tests
{
    [Collection("StoreDatasource")]
    public class StoreDatasourceTests
    {
        public static readonly string ConnectionString = ConfigurationManager.ConnectionStrings[0].ConnectionString;

        public static readonly StoreDatasource TStoreDatasource = new StoreDatasource(ConnectionString);

        public static readonly Store TStore = new Store(
            name: "Store",
            address: "Store Address",
            imageUrl: "Store Image Url",
            telephone: "0123456789",
            website: "https://www.google.com/"
        );

        [AttributeUsage(AttributeTargets.Method, Inherited = false, AllowMultiple = true)]
        sealed class CleanStoreDBAfter : BeforeAfterTestAttribute
        {
            public override void After(MethodInfo methodUnderTest)
            {
                using SqlConnection connection = new SqlConnection(ConnectionString);
                connection.Open();

                string sql = "DELETE FROM Store";

                using SqlCommand command = new SqlCommand(sql, connection);
                command.ExecuteNonQuery();
            }
        }

        [CleanStoreDBAfter()]
        [Trait("Method", "Create")]
        [Fact(DisplayName = "Should create a new store")]
        public async Task CreateTest1()
        {
            // Act
            var result = await TStoreDatasource.Create(TStore);

            // Assert
            Assert.NotNull(result.Id);
            Assert.Equal(TStore.Name, result.Name);
            Assert.Equal(TStore.Address, result.Address);
            Assert.Equal(TStore.ImageUrl, result.ImageUrl);
            Assert.Equal(TStore.Telephone, result.Telephone);
            Assert.Equal(TStore.Website, result.Website);
        }

        [CleanStoreDBAfter()]
        [Trait("Method", "FindById")]
        [Fact(DisplayName = "Should throw an exception when there is no store with the provided id")]
        public async Task FindByIdTest1()
        {
            // Act
            static async Task func() => await TStoreDatasource.FindById("1");

            // Assert
            await Assert.ThrowsAsync<NotFoundException>(func);
        }

        [CleanStoreDBAfter()]
        [Trait("Method", "FindById")]
        [Fact(DisplayName = "Should return the store when the id exists")]
        public async Task FindByIdTest2()
        {
            // Arrange
            var createdStore = await TStoreDatasource.Create(TStore);

            // Act
            var result = await TStoreDatasource.FindById(createdStore.Id);

            // Assert
            Assert.Equal(createdStore.Id, result.Id);
            Assert.Equal(createdStore.Name, result.Name);
            Assert.Equal(createdStore.Address, result.Address);
            Assert.Equal(createdStore.ImageUrl, result.ImageUrl);
            Assert.Equal(createdStore.Telephone, result.Telephone);
            Assert.Equal(createdStore.Website, result.Website);
        }

        [CleanStoreDBAfter()]
        [Trait("Method", "FindAll")]
        [Fact(DisplayName = "Should return an empty list when there are no stores")]
        public async Task FindAllTest1()
        {
            // Act
            var result = await TStoreDatasource.FindAll();

            // Assert
            Assert.Empty(result);
        }
        
        [CleanStoreDBAfter()]
        [Trait("Method", "FindAll")]
        [Fact(DisplayName = "Should return all the stores when present")]
        public async Task FindAllTest2()
        {
            // Arrange
            await TStoreDatasource.Create(TStore);
            await TStoreDatasource.Create(TStore);

            // Act
            var result = await TStoreDatasource.FindAll();

            // Assert
            Assert.Equal(2, result.Count);
        }

        [CleanStoreDBAfter()]
        [Trait("Method", "Update")]
        [Fact(DisplayName = "Should throw an exception when the id does not exist")]
        public async Task UpdateTest1()
        {
            // Act
            static async Task func() => await TStoreDatasource.Update("1", TStore);

            // Assert
            await Assert.ThrowsAsync<NotFoundException>(func);
        }

        [CleanStoreDBAfter()]
        [Trait("Method", "Update")]
        [Fact(DisplayName = "Should successfully update the store when the id exists")]
        public async Task UpdateTest2()
        {
            // Arrange
            var createdStore = await TStoreDatasource.Create(TStore);
            var updatedStore = new Store(
                name: $"{TStore.Name}Updated",
                address: $"{TStore.Address}Updated",
                imageUrl: $"{TStore.ImageUrl}Updated",
                telephone: $"{TStore.Telephone}Updated",
                website: $"{TStore.Website}Updated"
            );

            // Act
            var result = await TStoreDatasource.Update(createdStore.Id, updatedStore);

            // Assert
            Assert.Equal(createdStore.Id, result.Id);
            Assert.Equal(updatedStore.Name, result.Name);
            Assert.Equal(updatedStore.Address, result.Address);
            Assert.Equal(updatedStore.ImageUrl, result.ImageUrl);
            Assert.Equal(updatedStore.Telephone, result.Telephone);
            Assert.Equal(updatedStore.Website, result.Website);
        }

        [CleanStoreDBAfter()]
        [Trait("Method", "Delete")]
        [Fact(DisplayName = "Should throw an exception when the id does not exist")]
        public async Task DeleteTest1()
        {
            // Act
            static async Task func() => await TStoreDatasource.Delete("1");

            // Assert
            await Assert.ThrowsAsync<NotFoundException>(func);
        }

        [CleanStoreDBAfter()]
        [Trait("Method", "Delete")]
        [Fact(DisplayName = "Should successfully delete the store when the id is valid")]
        public async Task DeleteTest2()
        {
            // Arrange
            var createdStore = await TStoreDatasource.Create(TStore);

            // Act & Assert
            await TStoreDatasource.Delete(createdStore.Id);
        }
    }
}