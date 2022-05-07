using System.Collections.Generic;

namespace WPFUtility.Persistance
{
    public interface IRepository<T> where T : IPersistable, new()
    {
        /// <summary>
        /// Returns the singleton instance of the repository.
        /// </summary>
        public static IRepository<T> Instance { get; }

        /// <summary>
        /// Creates the object and uses it's parse with the given text and returns the object.
        /// </summary>
        /// <param name="text">Text to be parsed (IPersistable)</param>
        public T Create(string text);

        /// <summary>
        /// Returns the object with the given ID.
        /// </summary>
        public T Retrieve(int ID);

        /// <summary>
        /// Returns a list of all objects in the repository.
        /// </summary>
        public List<T> RetrieveAll();

        /// <summary>
        /// Used to notify the repository of an update to a object.
        /// </summary>
        public void Update(int ID);
        
        /// <summary>
        /// Deletes the object with the given ID.
        /// </summary>
        public void Delete(int ID);
    }
}