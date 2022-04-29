using System;
using System.Data.SqlClient;
using System.Collections.Generic;

namespace WPFUtility.Persistance
{
    public class SQLRepository<T> : IRepository<T> where T : IPersistable, new()
    {
        /// <summary>
        /// The connection to the SQL Database.
        /// </summary>
        private readonly SqlConnection connection = new(string.Empty);

        public T Create(string text)
        {
            CheckConnection();

            T obj = new();
            obj.Parse(text);
            return obj;
        }

        public T Retrieve(int id)
        {
            CheckConnection();

            return default;
        }

        public List<T> RetrieveAll()
        {
            CheckConnection();

            List<T> result = new();
            
            connection.Open();
            SqlCommand command = new("", connection);

            command.Parameters.Add(new SqlParameter("fn", ""));

            using (SqlDataReader reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    //result.Add(reader.GetString(0));
                }
            }
            connection.Close();

            return result;
        }

        public void Update(T entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(T entity)
        {
            CheckConnection();
        }

        private void CheckConnection()
        {
            if (connection.ConnectionString == string.Empty)
                throw new NotImplementedException("Connection string is not yet defined. Check line 12 in SQLRepository.");
        }
    }
}