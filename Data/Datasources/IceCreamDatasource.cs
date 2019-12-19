using IceCreamDesktop.Core.Entities;
using IceCreamDesktop.Data.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace IceCreamDesktop.Data.Datasources
{
    public class IceCreamDatasource : IDatasource<IceCream>
    {
        private const string ConnectionUrl = "Server=localhost;Database=icecreamdesktop;Trusted_Connection=True;";
        private const string TableName = "IceCream";

        public IceCream FindById(string iceCreamId)
        {
            string id, name, brand, imageUrl;

            using (SqlConnection connection = new SqlConnection(ConnectionUrl))
            {
                SqlCommand query = new SqlCommand($"SELECT * FROM {TableName} WHERE Id = {iceCreamId}", connection);
                connection.Open();

                using (SqlDataReader reader = query.ExecuteReader())
                {
                    if (!reader.Read())
                        return null;

                    id = reader.GetInt32(0).ToString();
                    name = reader.GetString(1);
                    brand = reader.GetString(2);
                    imageUrl = reader.GetString(3);
                }
            }

            return new IceCream(id, name, brand, imageUrl);
        }

        public List<IceCream> FindAll()
        {
            List<IceCream> result = new List<IceCream>();

            using (SqlConnection connection = new SqlConnection(ConnectionUrl))
            {
                SqlCommand query = new SqlCommand($"SELECT * FROM {TableName}", connection);
                connection.Open();

                using (SqlDataReader reader = query.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        string id = reader.GetInt32(0).ToString();
                        string name = reader.GetString(1);
                        string brand = reader.GetString(2);
                        string imageUrl = reader.GetString(3);

                        IceCream iceCream = new IceCream(id, name, brand, imageUrl);
                        result.Add(iceCream);
                    }
                }
            }

            return result;
        }

        public IceCream FindById()
        {
            throw new System.NotImplementedException();
        }

        public IceCream Create(IceCream data)
        {
            throw new System.NotImplementedException();
        }

        public IceCream Update(string id, IceCream data)
        {
            throw new System.NotImplementedException();
        }

        public bool Delete(string id)
        {
            throw new System.NotImplementedException();
        }
    }
}
