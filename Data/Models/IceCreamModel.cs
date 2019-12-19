using IceCreamDesktop.Core.Entities;
using IceCreamDesktop.Data.Interfaces;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace IceCreamDesktop.Data.Models
{
    public class IceCreamModel : IModel<IceCream>
    {
        private const string ConnectionUrl = "Server=localhost;Database=icecreamdesktop;Trusted_Connection=True;";
        private const string TableName = "IceCream";

        private SqlConnection Connection { get; }

        public IceCreamModel()
        {
            Connection = new SqlConnection(ConnectionUrl);
            Connection.Open();
        }

        public IceCream FindById(string iceCreamId)
        {
            SqlCommand query = new SqlCommand($"SELECT * FROM {TableName} WHERE Id = {iceCreamId}", Connection);
            SqlDataReader reader = query.ExecuteReader();

            if (!reader.Read())
                return null;

            string id = reader.GetInt32(0).ToString();
            string name = reader.GetString(1);
            string brand = reader.GetString(2);
            string imageUrl = reader.GetString(3);

            return new IceCream(id, name, brand, imageUrl);
        }

        public List<IceCream> FindAll()
        {
            SqlCommand query = new SqlCommand($"SELECT * FROM {TableName}", Connection);
            SqlDataReader reader = query.ExecuteReader();

            List<IceCream> result = new List<IceCream>();

            while (reader.Read())
            {
                string id = reader.GetInt32(0).ToString();
                string name = reader.GetString(1);
                string brand = reader.GetString(2);
                string imageUrl = reader.GetString(3);

                IceCream iceCream = new IceCream(id, name, brand, imageUrl);
                result.Add(iceCream);
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

        ~IceCreamModel()
        {
            Connection.Close();
        }
    }
}
