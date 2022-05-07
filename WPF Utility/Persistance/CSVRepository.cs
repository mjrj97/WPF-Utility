using System.Collections.Generic;
using System.IO;

namespace WPFUtility.Persistance
{
    public class CSVRepository<T> : IRepository<T> where T : IPersistable, new()
    {
        /// <summary>
        /// Cached list of the items to be persisted.
        /// </summary>
        protected List<T> List { get; set; }

        private static CSVRepository<T> _instance;
        /// <summary>
        /// Singleton instance of the repository.
        /// </summary>
        public static CSVRepository<T> Instance 
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

        private readonly string path;

        private CSVRepository()
        {
#if DEBUG
            path = "../../../" + typeof(T).Name + ".csv";
#else
            path = typeof(T).Name + ".csv";
#endif
            Load();
        }

        public T Create(string text)
        {
            T obj = new();
            obj.Parse(text);
            List.Add(obj);
            Save();
            return obj;
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

        public void Update(int ID)
        {
            bool found = false;
            foreach (T item in List)
            {
                if (item.ID == ID)
                    found = true;
            }
            if (found)
                Save();
        }

        public void Delete(int ID)
        {
            int i = 0;
            bool found = false;
            while (i < List.Count && !found)
            {
                if (List[i].ID == ID)
                {
                    List.RemoveAt(i);
                    found = true;
                }
                else
                    i++;
            }
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