using System.Collections.Generic;

namespace WPFUtility.Persistance
{
    public interface IRepository<T> where T : IPersistable, new()
    {
        public T Create(string text);

        public T Retrieve(int id);

        public List<T> RetrieveAll();

        public void Update(T entity);
        
        public void Delete(T entity);
    }
}