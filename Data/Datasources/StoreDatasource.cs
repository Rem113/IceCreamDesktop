using IceCreamDesktop.Core.Entities;
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

        public async Task<Store> Create(Store data)
        {
            Store result;

            using (SqlConnection connection = new SqlConnection(ConnectionUrl))
            {
                connection.Open();

                if (!string.IsNullOrWhiteSpace(data.Id))
                {
                    Store store = await FindById(data.Id);

                    if (store != null) throw new ArgumentException("There is already a store associated with this id");
                }

                SqlCommand command = new SqlCommand($"INSERT INTO {TableName} OUTPUT Inserted.Id VALUES ('{data.Name}', '{data.Address}', '{data.ImageUrl}', '{data.Telephone}', '{data.Website}')", connection);

                // Gets the id of the previously inserted ice cream
                string newId = command.ExecuteScalar().ToString();

                result = new Store(newId, data.Name, data.Address, data.ImageUrl, data.Website);
            }

            return result;
        }

        public Task Delete(string id)
        {
            throw new NotImplementedException();
        }

        public Task<List<Store>> FindAll()
        {
            throw new NotImplementedException();
        }

        public Task<Store> FindById(string id)
        {
            throw new NotImplementedException();
        }

        public Task<Store> Update(string id, Store data)
        {
            throw new NotImplementedException();
        }
    }
}