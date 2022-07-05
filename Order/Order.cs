namespace Order
{
    abstract class Order<TDelivery, TNumber, TProdact> 
        where TDelivery : Delivery
        where TProdact : Product
    {
        public TDelivery Delivery;
        public TProdact Prodact;
        public Client Client;

        public TNumber Number { get; }

        public string Description { get; }        

        public bool OrderReceived { get; protected set; }
        
        public Order(Client client, TProdact prodact, TNumber number, string description)
        {
            Client = client;
            Prodact = prodact;
            Number = number;
            Description = description;
            OrderReceived = false;
        }

        public void GetOrderTime()
        {

        }

        public void DisplayAddress()
        {
            Console.WriteLine(Delivery.Address);
        }        
    }

    class HomeOrder<TNumber, TProdact> : Order<HomeDelivery, TNumber, TProdact>
        where TProdact : Product
    {
        public HomeOrder(Client client, TProdact prodact, TNumber number, string description, string address, Staff courier) : base (client, prodact, number, description)
        {
            Delivery = new HomeDelivery(address, courier);
        }
    }
    class PickPointOrder<TNumber, TProdact> : Order<PickPointDelivery, TNumber, TProdact>
        where TProdact : Product
    {
        public PickPointOrder(Client client, TProdact prodact, TNumber number, string description, string address) : base(client, prodact, number, description)
        {
            Delivery = new PickPointDelivery(address);
        }
    }
    class ShopOrder<TNumber, TProdact> : Order<ShopDelivery, TNumber, TProdact>
        where TProdact : Product
    {
        public ShopOrder(Client client, TProdact prodact, TNumber number, string description) : base(client, prodact, number, description)
        {
            Delivery = new ShopDelivery();
        }
    }
}
