using IceCreamDesktop.Core.Entities;
using IceCreamDesktop.Core.Enums;
using IceCreamDesktop.Core.Exceptions;
using IceCreamDesktop.Data.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IceCreamDesktop.Data.Datasources
{
    public class StoreIceCreamDatasource : IDatasource<StoreIceCream>
    {
        private string ConnectionUrl { get; set; }
        private const string TableName = "StoreIceCream";

        public StoreIceCreamDatasource(string connectionUrl)
        {
            ConnectionUrl = connectionUrl;
        }

        public Task<StoreIceCream> FindById(string storeIceCreamId)
        {
            StoreIceCream result;

            using (SqlConnection connection = new SqlConnection(ConnectionUrl))
            {
                SqlCommand query = new SqlCommand($"SELECT * FROM {TableName} WHERE Id = {storeIceCreamId}", connection);
                connection.Open();

                using (SqlDataReader reader = query.ExecuteReader())
                {
                    if (!reader.Read())
                        throw new NotFoundException("There is no store ice cream associated to this id");

                    result = new StoreIceCream(
                        id: reader.GetInt32(0).ToString(),
                        price: (float) reader.GetDouble(1),
                        rating: (Ratings) Enum.Parse(typeof(Ratings), reader.GetString(2)),
                        description: reader.GetString(3),
                        barCode: reader.GetString(4)
                    );
                }
            }

            return Task.FromResult(result);
        }

        public Task<List<StoreIceCream>> FindAll()
        {
            List<StoreIceCream> result = new List<StoreIceCream>();

            using (SqlConnection connection = new SqlConnection(ConnectionUrl))
            {
                SqlCommand query = new SqlCommand($"SELECT * FROM {TableName}", connection);
                connection.Open();

                using SqlDataReader reader = query.ExecuteReader();
                while (reader.Read())
                {
                    StoreIceCream StoreIceCream = new StoreIceCream(
                        id: reader.GetInt32(0).ToString(),
                        price: (float) reader.GetDouble(1),
                        rating: (Ratings) Enum.Parse(typeof(Ratings), reader.GetString(2)),
                        description: reader.GetString(3),
                        barCode: reader.GetString(4)
                    );
                    result.Add(StoreIceCream);
                }
            }

            return Task.FromResult(result);
        }

        public Task<StoreIceCream> Create(StoreIceCream data)
        {
            StoreIceCream result;

            using (SqlConnection connection = new SqlConnection(ConnectionUrl))
            {
                connection.Open();

                string sql = $"INSERT INTO {TableName} " +
                    $"OUTPUT Inserted.Id " +
                    $"VALUES ({data.Price.ToString(CultureInfo.InvariantCulture)}, '{data.Rating.ToString("g").ToUpper()}', " +
                    $"'{data.Description}', '{data.BarCode}')";

                using SqlCommand command = new SqlCommand(sql, connection);
                // Gets the id of the previously inserted store ice cream
                var newId = command.ExecuteScalar().ToString();

                result = new StoreIceCream(
                    id: newId,
                    price: data.Price,
                    rating: data.Rating,
                    description: data.Description,
                    barCode: data.BarCode
                );
            }

            return Task.FromResult(result);
        }

        public Task<StoreIceCream> Update(string id, StoreIceCream data)
        {
            StoreIceCream result;

            using (SqlConnection connection = new SqlConnection(ConnectionUrl))
            {
                connection.Open();

                string sql = $"UPDATE {TableName} " +
                    $"SET Price = {data.Price.ToString(CultureInfo.InvariantCulture)}, Rating = '{data.Rating.ToString("g").ToUpper()}', " +
                    $"Description = '{data.Description}', BarCode = '{data.BarCode}'" +
                    $"WHERE Id = {id}";

                using SqlCommand command = new SqlCommand(sql, connection);
                var affectedRows = command.ExecuteNonQuery();

                if (affectedRows == 0) throw new NotFoundException("There is no store ice cream associated to this id");

                result = new StoreIceCream(
                    id: id, 
                    price: data.Price,
                    rating: data.Rating,
                    description: data.Description,
                    barCode: data.BarCode
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

                if (affectedRows == 0) throw new NotFoundException("There is no store ice cream associated to this id");
            }

            return Task.CompletedTask;
        }
    }
}
