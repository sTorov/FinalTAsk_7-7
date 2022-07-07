namespace Order
{
    abstract class Delivery
    {
        public string Address { get; protected set; }
        public string OrderDate { get; }
        public DeliveryType DeliveryType { get; protected set; }

        public Delivery (string address)
        {
            Address = address;
            OrderDate = DateTime.Now.ToString();
        }

        public abstract void CompanyInfo();
    }

    enum DeliveryType
    {
        Home = 0,
        PickPoint,
        Shop
    }

    class HomeDelivery : Delivery
    {
        public Staff Courier { get; }
        public string TimeOfDelivery { get; }

        public HomeDelivery(string address, Staff courier) : base (address) 
        {
            Courier = courier;
            TimeOfDelivery = DateTime.Now.AddDays(1).ToString();
            DeliveryType = DeliveryType.Home;
        }

        public override void CompanyInfo()
        {
            Console.WriteLine("------------------------------Курьерская служба------------------------------------");
            Console.WriteLine($"Название:\t\t\t{DeliveryCompany.Name}");
            Console.WriteLine($"Адрес:\t\t\t\t{DeliveryCompany.Address}");
            Console.WriteLine($"Телефон горячей линии:\t\t{DeliveryCompany.HotLinePhone}");
        }        
    }

    class PickPointDelivery : Delivery
    {
        class PickPoint
        {
            public string Address { get; set; }
        }
        class PickPointCollection
        {
            private PickPoint[] points;
            public int Length { get; }

            public PickPointCollection()
            {
                points = new PickPoint[]
                {
                    new PickPoint { Address = "Address 1" },
                    new PickPoint { Address = "Address 2" },
                    new PickPoint { Address = "Address 3" },
                    new PickPoint { Address = "Address 4" },
                    new PickPoint { Address = "Address 5" }
                };

                Length = points.Length;
            }
            public string this[string address]
            {
                get
                {
                    for (int i = 0; i < points.Length; i++)
                    {
                        if (points[i].Address == address)
                            return points[i].Address;
                    }

                    return null;
                }
            }
            public string this[int index]
            {
                get
                {
                    if (index >= 0 && index < points.Length)
                        return points[index].Address;

                    return null;
                }
            }
        }


        public string StorageEndTime { get; }
        private PickPointCollection allPickPoint;

        public PickPointDelivery(string address) : base (null)
        {
            allPickPoint = new PickPointCollection();

            Address = allPickPoint[address];
            Address ??= "Пункта выдачи с таким адресом не существует";
            
            StorageEndTime = DateTime.Now.AddDays(5).ToString();
            DeliveryType = DeliveryType.PickPoint;
        }

        public override void CompanyInfo()
        {
            Console.WriteLine("------------------------------Контакты Pick Point----------------------------------");
            Console.WriteLine($"Телефон:\t\t\t{PickPointContact.PhoneNumber}");
            Console.WriteLine($"Email:\t\t\t\t{PickPointContact.Email}");
        }
        public void GetAllPickPoint()
        {
            PickPointCollection collection = new PickPointCollection();

            Console.WriteLine("------------------------------Адреса пунктов выдачи--------------------------------");
            for (int i = 0; i < collection.Length; i++)
                Console.WriteLine(collection[i]);
        }
    }

    class ShopDelivery : Delivery
    {
        public string StorageEndTime { get; }

        public ShopDelivery() : base (Shop.Address)
        {
            StorageEndTime = DateTime.Now.AddDays(3).ToString();
            DeliveryType = DeliveryType.Shop;
        }

        public override void CompanyInfo()
        {
            Console.WriteLine("------------------------------Магазин Shop-----------------------------------------");
            Console.WriteLine($"Адрес:\t\t\t\t{Shop.Address}");
            Console.WriteLine($"Телефон:\t\t\t{Shop.PhoneNumber}");
            Console.WriteLine($"Email:\t\t\t\t{Shop.Email}");
        }

    }

}
