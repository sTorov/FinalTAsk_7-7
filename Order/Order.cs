namespace Order
{
    abstract class Order<TDelivery, TNumber, TProdact> 
        where TDelivery : Delivery
        where TProdact : Product
    {
        public TDelivery Delivery;
        public TProdact Prodact;
        public Client Client;

        public TNumber Number { get; set; }

        public string Description { get; set; }        

        public bool OrderReceived { get; set; }
        
        public Order(Client client, TProdact prodact, TNumber number, string description)
        {
            Client = client;
            Prodact = prodact;
            Number = number;
            Description = description;
            OrderReceived = false;
        }

        public abstract void GetCompanyInfo();

        public void GetClientInfo()
        {
            Console.WriteLine("------------------------------Информация о заказчике------------------------------");
            Console.WriteLine($"Имя:\t\t\t{Client.FirstName ?? "Нет данных"}");
            Console.WriteLine($"Фамилия:\t\t{Client.SecondName ?? "Нет данных"}");
            Console.WriteLine($"Отчество:\t\t{Client.LastName ?? "Нет данных"}");
            Console.WriteLine($"Возраст:\t\t{Client.Age ?? "Нет данных"}");
            Console.WriteLine($"Номер телефона:\t\t{Client.PhoneNumber ?? "Нет данных"}");
        }

        public void GetOrderTime()
        {

        }

        public void DisplayAddress()
        {
            Console.WriteLine(Delivery.Address);
        }        
    }

    class HomeDeliveryOrder<TNumber, TProdact> : Order<HomeDelivery, TNumber, TProdact> where TProdact : Product
    {
        public HomeDeliveryOrder(Client client, TProdact prodact, string address, TNumber number, string description, Staff courier) : base (client, prodact, number, description) 
        {
            Delivery = new HomeDelivery(address, courier);
        }

        public override void GetCompanyInfo()
        {
            Console.WriteLine("------------------------------Курьерская служба------------------------------------");
            Console.WriteLine($"Название:\t\t\t{Company.Name}");
            Console.WriteLine($"Адрес:\t\t\t\t{Company.Address}");
            Console.WriteLine($"Телефон горячей линии:\t\t{Company.HotLinePhone}");
        }
        public void GetCourierInfo()
        {
            Console.WriteLine("------------------------------Информация о курьере------------------------------");
            Console.WriteLine($"Имя:\t\t\t{Delivery?.Courier?.FirstName ?? "Нет данных"}");
            Console.WriteLine($"Фамилия:\t\t{Delivery?.Courier?.SecondName ?? "Нет данных"}");
            Console.WriteLine($"Номер телефона:\t\t{Delivery?.Courier?.PhoneNumber ?? "Нет данных"}");
        }
    }
    class PickPointDeliveryOrder<TNumber, TProdact> : Order<PickPointDelivery, TNumber, TProdact> where TProdact : Product
    {
        public PickPointDeliveryOrder(Client client, TProdact prodact, string address, TNumber number, string description) : base (client, prodact, number, description) 
        {
            Delivery = new PickPointDelivery(address);
        }

        public override void GetCompanyInfo()
        {
            Console.WriteLine("------------------------------Контакты Pick Point----------------------------------");
            Console.WriteLine($"Телефон:\t\t\t{PickPointContact.PhoneNumber}");
            Console.WriteLine($"Email:\t\t\t\t{PickPointContact.Email}");
        }
        public void GetAllPickPoint()
        {
            Console.WriteLine("------------------------------Адреса пунктов выдачи--------------------------------");
            for (int i = 0; i < PickPointCollection.collection.Length; i++)
                Console.WriteLine(PickPointCollection.collection[i].Address);
        }
    }
    class ShopDeliveryOrder<TNumber, TProdact> : Order<ShopDelivery, TNumber, TProdact> where TProdact : Product
    {
        public ShopDeliveryOrder(Client client, TProdact prodact, TNumber number, string description) : base (client, prodact, number, description) 
        {
            Delivery = new ShopDelivery();
        }

        public override void GetCompanyInfo()
        {
            Console.WriteLine("------------------------------Магазин Shop-----------------------------------------");
            Console.WriteLine($"Адрес:\t\t\t\t{Shop.Address}");
            Console.WriteLine($"Телефон:\t\t\t{Shop.PhoneNumber}");
            Console.WriteLine($"Email:\t\t\t\t{Shop.Email}");
        }
    }
}
