using IceCreamDesktop.Core.Entities;
using IceCreamDesktop.Core.Exceptions;
using IceCreamDesktop.Data.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Threading.Tasks;

namespace IceCreamDesktop.Data.Datasources
{
    public class StoreDatasource : IDatasource<Store>
    {
        private string ConnectionUrl { get; set; }
        private const string TableName = "Store";

        public StoreDatasource(string connectionUrl)
        {
            ConnectionUrl = connectionUrl;
        }

        public Task<Store> Create(Store data)
        {
            Store result;

            using (SqlConnection connection = new SqlConnection(ConnectionUrl))
            {
                connection.Open();

                var sql = $"INSERT INTO {TableName} " +
                    $"OUTPUT Inserted.Id " +
                    $"VALUES ('{data.Name}', '{data.Address}', '{data.ImageUrl}', '{data.Telephone}', '{data.Website}')";

                var command = new SqlCommand(sql, connection);

                // Gets the id of the previously inserted store
                var newId = command.ExecuteScalar().ToString();

                result = new Store(
                    id: newId,
                    name: data.Name,
                    address: data.Address,
                    imageUrl: data.ImageUrl,
                    telephone: data.Telephone,
                    website: data.Website
                );
            }

            return Task.FromResult(result);
        }

        public Task Delete(string id)
        {
            using (SqlConnection connection = new SqlConnection(ConnectionUrl))
            {
                connection.Open();

                string sql = $"DELETE FROM {TableName} WHERE Id = {id}";

                using SqlCommand command = new SqlCommand(sql, connection);
                var affectedRows = command.ExecuteNonQuery();

                if (affectedRows == 0) throw new NotFoundException("There is no store associated with this id");
            }

            return Task.CompletedTask;
        }

        public Task<List<Store>> FindAll()
        {
            var result = new List<Store>();

            using (SqlConnection connection = new SqlConnection(ConnectionUrl))
            {
                var query = new SqlCommand($"SELECT * FROM {TableName}", connection);
                connection.Open();

                using (SqlDataReader reader = query.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        string id = reader.GetInt32(0).ToString();
                        string name = reader.GetString(1);
                        string address = reader.GetString(2);
                        string imageUrl = reader.GetString(3);
                        string telephone = reader.GetString(4);
                        string website = reader.GetString(5);

                        Store store = new Store(
                            id: id,
                            name: name,
                            address: address,
                            imageUrl: imageUrl,
                            telephone: telephone,
                            website: website
                        );

                        result.Add(store);
                    }
                }
            }

            return Task.FromResult(result);
        }

        public Task<Store> FindById(string id)
        {
            Store result;

            using (var connection = new SqlConnection(ConnectionUrl))
            {
                connection.Open();

                var query = new SqlCommand($"SELECT * FROM {TableName} WHERE Id = {id}", connection);

                using (var reader = query.ExecuteReader())
                {
                    if (!reader.Read()) throw new NotFoundException("There is no store associated with this id");

                    var name = reader.GetString(1);
                    var address = reader.GetString(2);
                    var imageUrl = reader.GetString(3);
                    var telephone = reader.GetString(4);
                    var website = reader.GetString(5);

                    result = new Store(
                        id: id,
                        name: name,
                        address: address,
                        imageUrl: imageUrl,
                        telephone: telephone,
                        website: website
                    );
                }
            }

            return Task.FromResult(result);
        }

        public Task<Store> Update(string id, Store data)
        {
            Store result;

            using (var connection = new SqlConnection(ConnectionUrl))
            {
                connection.Open();

                string sql = $"UPDATE {TableName} " +
                    $"SET Name = '{data.Name}', Address = '{data.Address}'," +
                    $"ImageUrl = '{data.ImageUrl}', Telephone = '{data.Telephone}'," +
                    $"Website = '{data.Website}'" +
                    $"WHERE Id = {id}";

                using var command = new SqlCommand(sql, connection);
                var affectedRows = command.ExecuteNonQuery();

                if (affectedRows == 0) throw new NotFoundException("There is no ice cream associated to this id");

                result = new Store(
                    id: id, 
                    name: data.Name,
                    address: data.Address,
                    imageUrl: data.ImageUrl,
                    telephone: data.Telephone,
                    website: data.Website
                );
            }

            return Task.FromResult(result);
        }
    }
}