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
        public Client Client { get; protected set; }
        public string Description { get; protected set; }
        public OrderStatus Status { get; protected set; }

        public AllOrders(Client client, uint number,  string description)
        {
            Number = number;
            Client = client;
            Description = description;
        }
        public void ShortInfo()
        {
            Console.WriteLine($"Заказ\t№{Number}\tСтатус:{Status}");
            Console.WriteLine($"Описание:\n {Description}");
        }
    }

    abstract class Order<TDelivery, TProduct> : AllOrders
        where TDelivery : Delivery
        where TProduct : Product
    {
        public TDelivery Delivery { get; protected set; }
        public TProduct Prodact { get; }
        
        public Order(Client client, TProduct prodact, uint number, string description) : base (client, number, description)
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
        public virtual void DisplayFullInfo()
        {
            Console.WriteLine($"------------------Информация о заказе № {Number}--------------------");
            Console.WriteLine($"Заказчик: {Client?.GetFullName() ?? "Нет данных"}\t\tВозраст {Client?.GetAge() ?? "Нет данных"}");
            Console.WriteLine($"Номер телефона заказчика:\t{Client?.GetPhoneNumber() ?? "Нет данных"}");
            Console.WriteLine($"Тип доставки: {Delivery.DeliveryType}\t\tСтатус: {Status}");
            Console.WriteLine($"\nОписание доставки:\n{Description}\n");
            Console.WriteLine($"Товар: {Prodact.Type}\tМодель: {Prodact?.Model ?? "Нет данных"}\tЦена: {Prodact?.Cost ?? default} Руб");
            Console.WriteLine($"\nХарактеристики:\n");
            Prodact.Characteristic();
        }
    }

    class OrderCollection
    {
        protected AllOrders[] Orders { get; set; }

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

        public Order<TDelivery, TProduct>[] GetOrderCollection<TDelivery, TProduct>(params Order<TDelivery, TProduct>[] order) 
            where TDelivery : Delivery
            where TProduct : Product
        {
            var newCollection = new Order<TDelivery, TProduct>[order.Length];

            for (int i = 0; i < order.Length; i++)
                newCollection[i] = order[i];

            return newCollection;            
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
        public void ViewAllOrders()
        {
            for(int i = 0; i < Orders.Length; i++)
                Console.WriteLine($"Заказ №{Orders[i].Number}\t\tСтатус: {Orders[i].Status}");
        }
    }

    class HomeOrder<TProduct> : Order<HomeDelivery, TProduct>
        where TProduct : Product
    {
        public HomeOrder(Client client, TProduct prodact, uint number, string description, string address, Staff courier) : base (client, prodact, number, description)
        {
            Delivery = new HomeDelivery(address, courier);
        }

        public override void DisplayOrderTime()
        {
            base.DisplayOrderTime();
            Console.WriteLine($"Приблизительное время доставки: {Delivery.TimeOfDelivery}");
        }
        public override void DisplayFullInfo()
        {
            base.DisplayFullInfo();
            Console.WriteLine();
            Console.WriteLine($"Дата оформления: {Delivery.OrderDate}\tПриблизительная дата доставки: {Delivery.TimeOfDelivery}");
            Console.WriteLine();
            Delivery.Courier.Info();
        }
    }
    class PickPointOrder<TProduct> : Order<PickPointDelivery, TProduct>
        where TProduct: Product
    {
        public PickPointOrder(Client client, TProduct prodact, uint number, string description, string address) : base(client, prodact, number, description)
        {
            Delivery = new PickPointDelivery(address);
        }

        public override void DisplayOrderTime()
        {
            base.DisplayOrderTime();
            Console.WriteLine($"Дата окончания хранения: {Delivery.StorageEndTime}");
        }
        public override void DisplayFullInfo()
        {
            base.DisplayFullInfo();
            Console.WriteLine($"\nДата оформления: {Delivery.OrderDate}\tЗаказ будет отменён: {Delivery.StorageEndTime}");
        }
    }
    class ShopOrder<TProduct> : Order<ShopDelivery, TProduct>
        where TProduct : Product
    {
        public ShopOrder(Client client, TProduct prodact, uint number, string description) : base(client, prodact, number, description)
        {
            Delivery = new ShopDelivery();
        }

        public override void DisplayOrderTime()
        {
            base.DisplayOrderTime();
            Console.WriteLine($"Дата отмены заказа: {Delivery.StorageEndTime}");
        }
        public override void DisplayFullInfo()
        {
            base.DisplayFullInfo();
            Console.WriteLine($"\nДата оформления: {Delivery.OrderDate}\tЗаказ будет отменён: {Delivery.StorageEndTime}");
        }
    }
}
