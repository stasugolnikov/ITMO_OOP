namespace Lab5.ClientCreation
{
    public class Client
    {
        public int Id { get; }
        public string Name { get; }
        public string Surname { get; }
        public string Adress { get; }
        public string Passport { get; }
        private static int _idCounter = 0;
        
        public Client(string name, string surname, string adress, string passport)
        {
            Id = _idCounter++;
            Name = name;
            Surname = surname;
            Adress = adress;
            Passport = passport;
        }
    }
}