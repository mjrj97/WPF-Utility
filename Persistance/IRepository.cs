using System.Collections.Generic;

namespace WPFUtility.Persistance
{
    public interface IRepository<T> where T : IPersistable, new()
    {
        public static IRepository<T> Instance { get; }

        public T Create(string text);

        public T Retrieve(int ID);

        public List<T> RetrieveAll();

        public void Update(T entity);
        
        public void Delete(int ID);
    }
}