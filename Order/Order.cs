namespace Order
{
    enum OrderStatus
    {
        Canceled = 0,
        Awaiting,
        Received
    }
    
    abstract class Order<TDelivery, TNumber, TProdact> 
        where TDelivery : Delivery
        where TProdact : Product
    {
        public TDelivery Delivery { get; protected set; }
        public TProdact Prodact { get; }
        public Client Client { get; }
        public TNumber Number { get; }
        public string Description { get; }
        public OrderStatus Status { get; protected set; }
        
        public Order(Client client, TProdact prodact, TNumber number, string description)
        {
            Client = client;
            Prodact = prodact;
            Number = number;
            Description = description;
            Status = OrderStatus.Awaiting;
        }

        public virtual void DisplayOrderTime() => Console.WriteLine($"Дата оформления заказа: {Delivery.OrderDate}");
        public void DisplayAddress() => Console.WriteLine(Delivery.Address);
        public void ChangeStatus(OrderStatus status) => Status = status;
        public void ShortInfo()
        {
            Console.WriteLine($"Заказ {Number}\n");
            Console.WriteLine($"Товар:\n{Prodact?.Name ?? "Нет данных"} {Prodact?.Model ?? "Нет данных"}\n");
            Console.WriteLine($"Описание:\n {Description}");
        }
    }

    class HomeOrder<TNumber, TProdact> : Order<HomeDelivery, TNumber, TProdact>
        where TProdact : Product
    {
        public HomeOrder(Client client, TProdact prodact, TNumber number, string description, string address, Staff courier) : base (client, prodact, number, description)
        {
            Delivery = new HomeDelivery(address, courier);
        }

        public override void DisplayOrderTime()
        {
            base.DisplayOrderTime();
            Console.WriteLine($"Приблизительное время доставки: {Delivery.TimeOfDelivery}");
        }
    }
    class PickPointOrder<TNumber, TProdact> : Order<PickPointDelivery, TNumber, TProdact>
        where TProdact : Product
    {
        public PickPointOrder(Client client, TProdact prodact, TNumber number, string description, string address) : base(client, prodact, number, description)
        {
            Delivery = new PickPointDelivery(address);
        }

        public override void DisplayOrderTime()
        {
            base.DisplayOrderTime();
            Console.WriteLine($"Дата окончания хранения: {Delivery.StorageEndTime}");
        }

    }
    class ShopOrder<TNumber, TProdact> : Order<ShopDelivery, TNumber, TProdact>
        where TProdact : Product
    {
        public ShopOrder(Client client, TProdact prodact, TNumber number, string description) : base(client, prodact, number, description)
        {
            Delivery = new ShopDelivery();
        }

        public override void DisplayOrderTime()
        {
            base.DisplayOrderTime();
            Console.WriteLine($"Дата отмены заказа: {Delivery.StorageEndTime}");
        }

    }
}
