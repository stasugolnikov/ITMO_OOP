namespace Lab5.ClientCreation
{
    public class Client
    {
        public int Id { get; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Adress { get; set; }
        public string Passport { get; set; }
        private static int _idCounter = 0;
        
        public Client()
        {
            Id = _idCounter++;
        }
    }
}