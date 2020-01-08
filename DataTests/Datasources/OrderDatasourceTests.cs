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
using IceCreamDesktop.Core.Exceptions;

namespace IceCreamDesktop.Data.Datasources.Tests
{
    [Collection("OrderDatasource")]
    public class OrderDatasourceTests
    {
        public static readonly string ConnectionString = ConfigurationManager.ConnectionStrings[0].ConnectionString;

        public static readonly OrderDatasource TOrderDatasource = new OrderDatasource(ConnectionString);

        [AttributeUsage(AttributeTargets.Method, AllowMultiple = false, Inherited = true)]
        sealed class ClearOrderDBAfter : BeforeAfterTestAttribute
        {
            public override void After(MethodInfo methodUnderTest)
            {
                using SqlConnection connection = new SqlConnection(ConnectionString);
                connection.Open();

                string sql = "DELETE FROM [Order]";

                using SqlCommand command = new SqlCommand(sql, connection);
                command.ExecuteNonQuery();
            }
        }

        [ClearOrderDBAfter()]
        [Trait("Method", "Create")]
        [Fact(DisplayName = "Should put a new order")]
        public async Task CreateTest()
        {
            // Act
            var result = await TOrderDatasource.Create(new Order());

            // Assert
            Assert.NotNull(result.Id);
        }

        [ClearOrderDBAfter()]
        [Trait("Method", "Delete")]
        [Fact(DisplayName = "Should throw an exception when the id does not exist")]
        public async Task DeleteTest1()
        {
            // Act
            static async Task func() => await TOrderDatasource.Delete("1");

            // Assert
            await Assert.ThrowsAsync<NotFoundException>(func);
        }
        
        [ClearOrderDBAfter()]
        [Trait("Method", "Delete")]
        [Fact(DisplayName = "Should delete when the id exists")]
        public async Task DeleteTest2()
        {
            // Arrange
            var createdOrder = await TOrderDatasource.Create(new Order());

            // Act & Assert
            await TOrderDatasource.Delete(createdOrder.Id);
        }

        [ClearOrderDBAfter()]
        [Trait("Method", "FindAll")]
        [Fact(DisplayName = "Should return an empty list when the table is empty")]
        public async Task FindAllTest1()
        {
            // Act
            var result = await TOrderDatasource.FindAll();

            // Assert
            Assert.Empty(result);
        }
        
        [ClearOrderDBAfter()]
        [Trait("Method", "FindAll")]
        [Fact(DisplayName = "Should return all the elements in the table")]
        public async Task FindAllTest2()
        {
            // Arrange
            await TOrderDatasource.Create(new Order());
            await TOrderDatasource.Create(new Order());

            // Act
            var result = await TOrderDatasource.FindAll();

            // Assert
            Assert.NotEmpty(result);
            Assert.Equal(2, result.Count);
        }

        [ClearOrderDBAfter()]
        [Trait("Method", "FindById")]
        [Fact(DisplayName = "Should throw an exception when the id does not exist")]
        public async Task FindByIdTest1()
        {
            // Act
            static async Task func() => await TOrderDatasource.FindById("1");

            // Assert
            await Assert.ThrowsAsync<NotFoundException>(func);
        }

        [ClearOrderDBAfter()]
        [Trait("Method", "FindById")]
        [Fact(DisplayName = "Should return the correct order when the id exists")]
        public async Task FindByIdTest2()
        {
            // Arrange
            var createdOrder = await TOrderDatasource.Create(new Order());

            // Act
            var result = await TOrderDatasource.FindById(createdOrder.Id);

            // Assert
            Assert.Equal(createdOrder.Id, result.Id);
        }

        [ClearOrderDBAfter()]
        [Trait("Method", "Update")]
        [Fact(DisplayName = "Should throw an exception when trying to update an order")]
        public async Task UpdateTest()
        {
            // Act
            static async Task func() => await TOrderDatasource.Update("1", new Order());

            // Assert
            await Assert.ThrowsAsync<NotAllowedException>(func);
        }
    }
}