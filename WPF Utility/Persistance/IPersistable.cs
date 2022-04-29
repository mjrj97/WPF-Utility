namespace WPFUtility.Persistance
{
    public interface IPersistable
    {
        /// <summary>
        /// Unique identifier of the object.
        /// </summary>
        public int ID { get; set; }

        /// <summary>
        /// Takes a string and assigns the values from this line to the objects properties.
        /// </summary>
        void Parse(string line);

        /// <summary>
        /// An alternative to ToString. Writes the object into a line that Parse(line) can use.
        /// </summary>
        string Format();
    }
}