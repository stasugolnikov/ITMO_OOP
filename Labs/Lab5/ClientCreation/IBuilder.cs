namespace Lab5.ClientCreation
{
    public interface IBuilder
    {
        IBuilder SetName(string name);
        IBuilder SetSurname(string surname);
        IBuilder SetAdress(string adress);
        IBuilder SetPassport(string passport);
        Client Build();
    }
}