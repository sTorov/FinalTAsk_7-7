namespace Order
{
    enum OrderStatus
    {
        Canceled = 0,
        Awaiting,
        Received
    }

    abstract class AllOrders 
    {
        public uint Number { get; protected set; }
    }

    abstract class Order<TDelivery> : AllOrders
        where TDelivery : Delivery
    {
        public TDelivery Delivery { get; protected set; }
        public Product Prodact { get; }
        public Client Client { get; }
        public string Description { get; }
        public OrderStatus Status { get; protected set; }
        
        public Order(Client client, Product prodact, uint number, string description)
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

    class OrderCollection
    {
        public AllOrders[] Orders { get; protected set; }

        public OrderCollection()
        {
            Orders = new AllOrders[0];
        }

        public AllOrders this[uint number]
        {
            get
            {
                for(int i = 0; i < Orders.Length; i++)
                    if (Orders[i].Number == number)
                        return Orders[i];

                return null;
            }
        }

        public void AddOrder<TDelivery>(params AllOrders[] order) where TDelivery : Delivery
        {
            for (int i = 0; i < order.Length; i++)
            {
                if (order[i] is Order<TDelivery>)
                {
                    var newCollection = new AllOrders[Orders.Length + 1];

                    if (Orders.Length != 0)
                    {
                        for (int j = 0; j < Orders.Length; j++)
                            newCollection[j] = Orders[j];
                    }

                    newCollection[newCollection.Length - 1] = (Order<TDelivery>)order[i];

                    Orders = newCollection;
                }
            }
        }
        public void AddOrder(params AllOrders[] order)
        {
            for (int i = 0; i < order.Length; i++)
            {
                var newCollection = new AllOrders[Orders.Length + 1];

                if (Orders.Length != 0)
                {
                    for (int j = 0; j < Orders.Length; j++)
                        newCollection[j] = Orders[j];
                }

                newCollection[newCollection.Length - 1] = order[i];

                Orders = newCollection;
            }
        }
    }

    class HomeOrder : Order<HomeDelivery>
    {
        public HomeOrder(Client client, Product prodact, uint number, string description, string address, Staff courier) : base (client, prodact, number, description)
        {
            Delivery = new HomeDelivery(address, courier);
        }

        public override void DisplayOrderTime()
        {
            base.DisplayOrderTime();
            Console.WriteLine($"Приблизительное время доставки: {Delivery.TimeOfDelivery}");
        }
    }
    class PickPointOrder : Order<PickPointDelivery>
    {
        public PickPointOrder(Client client, Product prodact, uint number, string description, string address) : base(client, prodact, number, description)
        {
            Delivery = new PickPointDelivery(address);
        }

        public override void DisplayOrderTime()
        {
            base.DisplayOrderTime();
            Console.WriteLine($"Дата окончания хранения: {Delivery.StorageEndTime}");
        }

    }
    class ShopOrder : Order<ShopDelivery>
    {
        public ShopOrder(Client client, Product prodact, uint number, string description) : base(client, prodact, number, description)
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
