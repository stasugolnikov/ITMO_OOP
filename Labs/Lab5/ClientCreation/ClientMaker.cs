namespace Lab5.ClientCreation
{
    public class ClientMaker
    {
        public IBuilder builder { get; }

        public ClientMaker(IBuilder builder, string name, string surname)
        {
            this.builder = builder;
            builder.SetName(name).SetSurname(surname);
        }
    }
}