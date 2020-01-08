using IceCreamDesktop.Core.Entities;
using IceCreamDesktop.Core.Exceptions;
using IceCreamDesktop.Data.Interfaces;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Threading.Tasks;

namespace IceCreamDesktop.Data.Datasources
{
    public class IceCreamDatasource : IDatasource<IceCream>
    {
        private string ConnectionUrl { get; set; }
        private const string TableName = "IceCream";

        public IceCreamDatasource(string connectionUrl)
        {
            ConnectionUrl = connectionUrl;
        }

        public Task<IceCream> FindById(string iceCreamId)
        {
            string id, name, brand, imageUrl;

            using (SqlConnection connection = new SqlConnection(ConnectionUrl))
            {
                SqlCommand query = new SqlCommand($"SELECT * FROM {TableName} WHERE Id = {iceCreamId}", connection);
                connection.Open();

                using (SqlDataReader reader = query.ExecuteReader())
                {
                    if (!reader.Read())
                        throw new NotFoundException("There is no ice cream associated to this id");

                    id = reader.GetInt32(0).ToString();
                    name = reader.GetString(1);
                    brand = reader.GetString(2);
                    imageUrl = reader.GetString(3);
                }
            }

            return Task.FromResult(new IceCream(id: id, name: name, brand: brand, imageUrl: imageUrl));
        }

        public Task<List<IceCream>> FindAll()
        {
            List<IceCream> result = new List<IceCream>();

            using (SqlConnection connection = new SqlConnection(ConnectionUrl))
            {
                SqlCommand query = new SqlCommand($"SELECT * FROM {TableName}", connection);
                connection.Open();

                using SqlDataReader reader = query.ExecuteReader();
                while (reader.Read())
                {
                    string id = reader.GetInt32(0).ToString();
                    string name = reader.GetString(1);
                    string brand = reader.GetString(2);
                    string imageUrl = reader.GetString(3);

                    IceCream iceCream = new IceCream(id: id, name: name, brand: brand, imageUrl: imageUrl);
                    result.Add(iceCream);
                }
            }

            return Task.FromResult(result);
        }

        public Task<IceCream> Create(IceCream data)
        {
            IceCream result;

            using (SqlConnection connection = new SqlConnection(ConnectionUrl))
            {
                connection.Open();

                string sql = $"INSERT INTO {TableName} " +
                    $"OUTPUT Inserted.Id " +
                    $"VALUES ('{data.Name}', '{data.Brand}', '{data.ImageUrl}')";

                using SqlCommand command = new SqlCommand(sql, connection);
                // Gets the id of the previously inserted ice cream
                string newId = command.ExecuteScalar().ToString();

                result = new IceCream(id: newId, name: data.Name, brand: data.Brand, imageUrl: data.ImageUrl);
            }

            return Task.FromResult(result);
        }

        public Task<IceCream> Update(string id, IceCream data)
        {
            IceCream result;

            using (SqlConnection connection = new SqlConnection(ConnectionUrl))
            {
                connection.Open();

                string sql = $"UPDATE {TableName} " +
                    $"SET Name = '{data.Name}', Brand = '{data.Brand}', ImageUrl = '{data.ImageUrl}'" +
                    $"WHERE Id = {id}";

                using SqlCommand command = new SqlCommand(sql, connection);
                var affectedRows = command.ExecuteNonQuery();

                if (affectedRows == 0) throw new NotFoundException("There is no ice cream associated to this id");

                result = new IceCream(id: id, name: data.Name, brand: data.Brand, imageUrl: data.ImageUrl);
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

                if (affectedRows == 0) throw new NotFoundException("There is no ice cream associated to this id");
            }

            return Task.CompletedTask;
        }
    }
}