namespace Lab5.ClientCreation
{
    public class ClientBuilder : IBuilder
    {
        private Client _client = new Client();
        
        public IBuilder SetName(string name)
        {
            _client.Name = name;
            return this;
        }

        public IBuilder SetSurname(string surname)
        {
            _client.Surname = surname;
            return this;
        }

        public IBuilder SetAdress(string adress)
        {
            _client.Adress = adress;
            return this;
        }

        public IBuilder SetPassport(string passport)
        {
            _client.Passport = passport;
            return this;
        }

        public Client Build()
        {
            return _client;
        }
    }
}