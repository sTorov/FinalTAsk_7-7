namespace Delivery
{
    using Person;

    abstract class Delivery
    {
        public string Address;
        public Client Client;
        public DateTime OrderDate;

        public Delivery (string address, Client client)
        {
            Address = address;
            Client = client;
            OrderDate = DateTime.Now;
        }

        public abstract void GetCompanyInfo();

    }

    class HomeDelivery : Delivery
    {
        public Staff Courier;
        public DateTime TimeOfDelivery;

        public HomeDelivery(string address, Client client, Staff courier) : base (address, client) 
        {
            Courier = courier;
            TimeOfDelivery = OrderDate.AddDays(1);
        }

        public override void GetCompanyInfo()
        {
            Console.WriteLine("------------------------------Курьерская служба------------------------------------");
            Console.WriteLine($"Название:\t\t\t{Company.Name}");
            Console.WriteLine($"Адрес:\t\t\t\t{Company.Address}");
            Console.WriteLine($"Телефон горячей линии:\t\t{Company.HotLinePhone}");
        }
    }

    class PickPointDelivery : Delivery
    {
        public DateTime StorageEndTime;

        public PickPointDelivery(string address, Client client) : base (null, client)
        {
            
            for (int i = 0; i < PickPointCollection.collection.Length ; i++)
            {
                if (PickPointCollection.collection[i].Address == address)
                    Address = address;
            }
            Address ??= "Пункта выдачи по данному адресу не существует!";

            StorageEndTime = OrderDate.AddDays(5);
        }

        public override void GetCompanyInfo()
        {
            Console.WriteLine("------------------------------Контакты Pick Point----------------------------------");
            Console.WriteLine($"Телефон:\t\t\t{PickPointContact.PhoneNumber}");
            Console.WriteLine($"Email:\t\t\t\t{PickPointContact.Email}");
        }

        class PickPoint
        {
            public string Address { get; set; }
        }
        class PickPointCollection
        {
            static public PickPoint[] collection = new PickPoint[]
            {
                new PickPoint { Address = "Address 1" },
                new PickPoint { Address = "Address 2" },
                new PickPoint { Address = "Address 3" },
                new PickPoint { Address = "Address 4" },
                new PickPoint { Address = "Address 5" }
            };
            public PickPoint this[string address]
            {
                get
                {
                    for (int i = 0; i < collection.Length; i++)
                    {
                        if (collection[i].Address == address)
                            return collection[i];
                    }

                    return null;
                }
            }
        }
        public void GetAllPickPoint()
        {
            Console.WriteLine("------------------------------Адреса пунктов выдачи--------------------------------");
            for (int i = 0; i < PickPointCollection.collection.Length; i++)
                Console.WriteLine(PickPointCollection.collection[i].Address);
        }
    }

    class ShopDelivery : Delivery
    {
        public DateTime StorageEndTime;

        public ShopDelivery(Client client) : base (Shop.Address, client)
        {
            StorageEndTime = OrderDate.AddDays(3);
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
