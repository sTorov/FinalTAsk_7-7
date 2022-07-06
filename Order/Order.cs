namespace Order
{
    enum OrderStatus
    {
        Canceled = 0,
        Awaiting,
        Received
    }
    
    abstract class Order<TDelivery, TNumber> 
        where TDelivery : Delivery
    {
        public TDelivery Delivery { get; protected set; }
        public Product Prodact { get; }
        public Client Client { get; }
        public TNumber Number { get; }
        public string Description { get; }
        public OrderStatus Status { get; protected set; }
        
        public Order(Client client, Product prodact, TNumber number, string description)
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

    class OrderCollection<TDelivery, TNumber, TProdact>
        where TDelivery : Delivery
        where TNumber : new()
        where TProdact : Product
    {
        //private HomeOrder<TNumber, TProdact>[] homeDelivCollection;
        //private PickPointOrder<TNumber,TProdact>[] pointDelivCollection;
        //private ShopOrder<TNumber, TProdact>[] shopDelivCollection;

        public OrderCollection()
        {
            //homeDelivCollection = new HomeOrder<TNumber, TProdact>[0];
            //pointDelivCollection = new PickPointOrder<TNumber, TProdact>[0];
            //shopDelivCollection = new ShopOrder<TNumber, TProdact>[0];
        }

        //public void AddOrder(params object[] order)
        //{
        //    for (int i = 0; i < order.Length; i++)
        //    {
        //        if (order[i] is HomeOrder<TNumber, TProdact> convOrder)
        //        {
        //            convOrder = (HomeOrder<TNumber, TProdact>)order[i];
        //            var newCollection = new HomeOrder<TNumber, TProdact>[homeDelivCollection.Length + 1];

        //            for (int j = 0; j < newCollection.Length; j++)
        //                newCollection[i] = homeDelivCollection[i];

        //            newCollection[newCollection.Length - 1] = convOrder;

        //            homeDelivCollection = newCollection;
        //        }
        //    }           
        //}
    }

    class HomeOrder<TNumber> : Order<HomeDelivery, TNumber>
    {
        public HomeOrder(Client client, Product prodact, TNumber number, string description, string address, Staff courier) : base (client, prodact, number, description)
        {
            Delivery = new HomeDelivery(address, courier);
        }

        public override void DisplayOrderTime()
        {
            base.DisplayOrderTime();
            Console.WriteLine($"Приблизительное время доставки: {Delivery.TimeOfDelivery}");
        }
    }
    class PickPointOrder<TNumber> : Order<PickPointDelivery, TNumber>
    {
        public PickPointOrder(Client client, Product prodact, TNumber number, string description, string address) : base(client, prodact, number, description)
        {
            Delivery = new PickPointDelivery(address);
        }

        public override void DisplayOrderTime()
        {
            base.DisplayOrderTime();
            Console.WriteLine($"Дата окончания хранения: {Delivery.StorageEndTime}");
        }

    }
    class ShopOrder<TNumber> : Order<ShopDelivery, TNumber>
    {
        public ShopOrder(Client client, Product prodact, TNumber number, string description) : base(client, prodact, number, description)
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
