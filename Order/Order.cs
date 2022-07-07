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
        public uint Number { get; }
        public Client Client { get; protected set; }
        public string Description { get; }
        public OrderStatus Status { get; protected set; }

        public AllOrders(Client client, uint number,  string description)
        {
            Number = number;
            Client = client;
            Description = description;
            Status = OrderStatus.Awaiting;
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
            Prodact = prodact;
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
        private AllOrders[] Orders;

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

        public AllOrders[] GetAllOrders()
        {
            return Orders;
        }

        public Order<TDelivery, TProduct>[] GetOrderCollection<TDelivery, TProduct>(params AllOrders[] order) 
            where TDelivery : Delivery
            where TProduct : Product
        {
            var collection = new Order<TDelivery, TProduct>[0];

            for (int i = 0; i < order.Length; i++)
            {
                if (order[i] is Order<TDelivery,TProduct>)
                {
                    var newCollection = new Order<TDelivery, TProduct>[collection.Length + 1];
                    
                    if(collection.Length != 0)
                    {
                        for (int j = 0; j < collection.Length; j++)
                            newCollection[j] = collection[j];
                    }
                    newCollection[newCollection.Length - 1] = (Order<TDelivery,TProduct>)order[i];

                    collection = newCollection;
                }
            }
            return collection;
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
        public void ViewAllOrders(AllOrders[] orders)
        {
            if (orders.Length != 0 || orders == null)
            {
                Console.WriteLine("Тип доставки: Любой\t\tТип товара: Любой\n");
                for (int i = 0; i < orders.Length; i++)
                    Console.WriteLine($"Заказ №{orders[i].Number}\tСтатус: {orders[i].Status}");
            }
            else
                Console.WriteLine("Данные отсутствуют");
        }
        public void ViewAllOrders<TDelivery, TProduct>(Order<TDelivery, TProduct>[] orders)
            where TDelivery : Delivery
            where TProduct : Product
        {
            if(orders.Length != 0 || orders == null)
            {
                Console.WriteLine($"Тип доставки: {orders[0].Delivery.DeliveryType}\t\tТип товара: {orders[0].Prodact.Type}\n");
                for (int i = 0; i < orders.Length; i++)
                    Console.WriteLine($"Заказ №{orders[i].Number}\tСтатус: {orders[i].Status}");
            }
            else
                Console.WriteLine("Данные отсутствуют");
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
