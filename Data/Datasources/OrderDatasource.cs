using IceCreamDesktop.Core.Entities;
using IceCreamDesktop.Core.Exceptions;
using IceCreamDesktop.Data.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Threading.Tasks;

namespace IceCreamDesktop.Data.Datasources
{
    public class OrderDatasource : IDatasource<Order>
    {
        private string ConnectionString { get; set; }
        private readonly string TableName = "[Order]"; // Keyword

        public OrderDatasource(string connectionString)
        {
            ConnectionString = connectionString;
        }

        public Task<Order> Create(Order data)
        {
            Order result;

            using (var connection = new SqlConnection(ConnectionString))
            {
                connection.Open();

                var sql = $"INSERT INTO {TableName} OUTPUT Inserted.Id DEFAULT VALUES";

                using var command = new SqlCommand(sql, connection);
                // Gets the new id
                var newId = command.ExecuteScalar().ToString();

                result = new Order(id: newId);
            }

            return Task.FromResult(result);
        }

        public Task Delete(string id)
        {
            using (var connection = new SqlConnection(ConnectionString))
            {
                connection.Open();

                var sql = $"DELETE FROM {TableName} " +
                    $"WHERE Id = {id}";

                using var command = new SqlCommand(sql, connection);
                var affectedRows = command.ExecuteNonQuery();

                if (affectedRows == 0) throw new NotFoundException("There is no order associated to this id");
            }

            return Task.CompletedTask;
        }

        public Task<List<Order>> FindAll()
        {
            List<Order> result = new List<Order>();

            using (var connection = new SqlConnection(ConnectionString))
            {
                connection.Open();

                var sql = $"SELECT * FROM {TableName}";

                using (var query = new SqlCommand(sql, connection))
                {
                    using var reader = query.ExecuteReader();
                    while (reader.Read())
                    {
                        var temp = new Order(
                            id: reader.GetInt32(0).ToString()
                        );

                        result.Add(temp);
                    }
                }
            }

            return Task.FromResult(result);
        }

        public Task<Order> FindById(string id)
        {
            Order result;

            using (var connection = new SqlConnection(ConnectionString))
            {
                connection.Open();

                var sql = $"SELECT * FROM {TableName} " +
                    $"WHERE Id = {id}";

                using var query = new SqlCommand(sql, connection);
                using (var reader = query.ExecuteReader())
                {
                    if (!reader.Read()) throw new NotFoundException("There is no order associated to this id");
                    result = new Order(
                        id: reader.GetInt32(0).ToString()    
                    );
                }
            }

            return Task.FromResult(result);
        }

        public Task<Order> Update(string id, Order data)
        {
            throw new NotAllowedException("You can't update an order");
        }
    }
}