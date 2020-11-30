namespace Lab5.ClientCreation
{
    public class ClientBuilder : IBuilder
    {
        private string _name;
        private string _surname;
        private string _adress;
        private string _passport;
        
        public IBuilder SetName(string name)
        {
            _name = name;
            return this;
        }

        public IBuilder SetSurname(string surname)
        {
            _surname = surname;
            return this;
        }

        public IBuilder SetAdress(string adress)
        {
            _adress = adress;
            return this;
        }

        public IBuilder SetPassport(string passport)
        {
            _passport = passport;
            return this;
        }

        public Client Build()
        {
            return new Client(_name, _surname, _passport, _adress);
        }
    }
}