using WPFUtility.Persistance;

namespace Example.Models
{
    public class Person : IPersistable
    {
        public int ID { get; set; }

        public string Name { get; set; }

        public Sex Sex { get; set; }

        public string Format()
        {
            return ID.ToString() + CSVRepository<Person>.Separator + Name + CSVRepository<Person>.Separator + (int)Sex;
        }

        public void Parse(string line)
        {
            string[] parts = line.Split(CSVRepository<Person>.Separator);

            Name = parts[1];
            Sex = (Sex)int.Parse(parts[2]);
        }
    }
}