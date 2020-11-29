namespace Lab5
{
    public class Client
    {
        public int Id { get; }
        public string Name { get; }
        public string Surname { get; }
        public string Adress { get; set; }
        public string Passport { get; set; }

        public Client(int id, string name, string surname)
        {
            Id = id;
            Name = name;
            Surname = surname;
        }
    }
}