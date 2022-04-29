using System.Collections.Generic;
using System.IO;

namespace WPFUtility.Persistance
{
    public class CSVRepository<T> : IRepository<T> where T : IPersistable, new()
    {
        protected List<T> List { get; set; }

        private static CSVRepository<T> _instance;
        public static CSVRepository<T> Instance 
        { 
            get
            {
                if (Instance == null)
                {
                    _instance = new();
                    return _instance;
                }
                return _instance;
            }
        }

        private readonly string path;

        private CSVRepository()
        {
            path = "../../../" + typeof(T).Name + ".csv";
            Load();
        }

        public void Create(T obj)
        {
            List.Add(obj);
            Save();
        }

        public T Retrieve(int ID)
        {
            if (List.Count > 0)
            {
                int i = 0;
                while (i < List.Count && List[i].ID != ID)
                {
                    i++;
                }
                return List[i];
            }
            else
                return default;
        }

        public List<T> RetrieveAll()
        {
            return List;
        }

        public void Update(T obj)
        {
            if (obj != null)
                Save();
        }

        public void Delete(T obj)
        {
            List.Remove(obj);
            Save();
        }

        protected virtual void Load()
        {
            if (!File.Exists(path))
                File.Create(path).Close();
            using StreamReader reader = new(path);
            List = new();

            string line;
            while ((line = reader.ReadLine()) != null)
            {
                T p = new();
                p.Parse(line);
                List.Add(p);
            }
        }

        protected virtual void Save()
        {
            using StreamWriter writer = new(path);
            for (int i = 0; i < List.Count; i++)
            {
                writer.WriteLine(List[i].Format());
            }
        }
    }
}