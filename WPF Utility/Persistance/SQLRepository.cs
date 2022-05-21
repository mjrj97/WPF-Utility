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
        private readonly string connectionString = string.Empty;

        private static SQLRepository<T> _instance;
        /// <summary>
        /// Singleton instance of the repository.
        /// </summary>
        public static SQLRepository<T> Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new();
                    return _instance;
                }
                return _instance;
            }
        }

        private SQLRepository()
        {
            if (!TableExist())
            {
                CreateTable();
            }
        }

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
            List<T> list = new();

            using (SqlConnection connection = new(connectionString))
            {
                connection.Open();
                string query = $"SELECT * FROM {nameof(T)}";
                SqlCommand sQLCommand = new(query, connection);

                using SqlDataReader sqldatareader = sQLCommand.ExecuteReader();
                while (sqldatareader.Read() != false)
                {

                }
            }

            return list;
        }

        public void Update(int ID)
        {
            throw new NotImplementedException();
        }

        public void Delete(int ID)
        {
            CheckConnection();
        }

        private void CreateTable()
        {
            using SqlConnection connection = new(connectionString);
            connection.Open();
            string query = $"CREATE TABLE [{typeof(T).Name}] (\n  [id] tinyint IDENTITY(1, 1) , \n PRIMARY KEY([id])\n) ON[PRIMARY]\nGO\n";
            System.Diagnostics.Debug.WriteLine(query);
            SqlCommand sQLCommand = new(query, connection);
            sQLCommand.ExecuteNonQuery();
        }

        private void CheckConnection()
        {
            if (connectionString == string.Empty)
                throw new NotImplementedException("Connection string is not yet defined. Check line 12 in SQLRepository.");
        }

        private bool TableExist()
        {
            bool exists = false;

            using (SqlConnection connection = new(connectionString))
            {
                connection.Open();
                string query = "select case when exists((select * from information_schema.tables where table_name = '" + typeof(T).Name + "')) then 1 else 0 end";
                SqlCommand sQLCommand = new(query, connection);
                int result = (int)sQLCommand.ExecuteScalar();
                exists = result == 1;
            }

            return exists;
        }
    }
}