namespace UnitTestingWorkshopTwo
{
    public interface IOrderBuilder
    {
        IOrderBuilder Init();
        IOrderBuilder AddItems(int numItems);
        IOrderBuilder ShipTo(string contact, string address);
        Order Build();
    }
}