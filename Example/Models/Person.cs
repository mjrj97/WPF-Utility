using WPFUtility.Persistance;

namespace Example.Models
{
    public class Person : IPersistable
    {
        public int ID { get; set; }

        public string Format()
        {
            return ID.ToString();
        }

        public void Parse(string line)
        {
            ID = int.Parse(line);
        }
    }
}