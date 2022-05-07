using WPFUtility.Persistance;

namespace Example.Models
{
    public class Person : IPersistable
    {
        public int ID { get; set; }

        public string Name { get; set; }

        public string Format()
        {
            return ID.ToString() + ";" + Name;
        }

        public void Parse(string line)
        {
            string[] parts = line.Split(';');

            ID = int.Parse(parts[0]);
            Name = parts[1];
        }
    }
}