namespace Delivery
{
    using Order;
    using Person;
    using Product;

    abstract class Delivery
    {
        public string Address;
        public virtual Order<TDelivery, TNumber, TProdact> CheckoutOrder<TDelivery, TNumber, TProdact>(TNumber Number, string Description, Client person, string Address, TProdact prodact, Staff Courier = null)
            where TDelivery : Delivery
            where TProdact : Product
        {
            Order<TDelivery, TNumber, TProdact> order = new();

            this.Address = Address;
            order.Prodact = prodact;
            order.Client = person;
            order.Number = Number;
            order.Description = Description;
            order.OrderDate = DateTime.Now;
            order.OrderReceived = false;


            return order;
        }

        public abstract void GetCompanyInfo();

    }

    class HomeDelivery : Delivery
    {
        public override Order<TDelivery, TNumber, TProdact> CheckoutOrder<TDelivery, TNumber, TProdact>(TNumber Number, string Description, Client person, string Address, TProdact prodact, Staff courier)
        {
            Order<TDelivery, TNumber, TProdact> order = base.CheckoutOrder<TDelivery, TNumber, TProdact>(Number, Description, person, Address, prodact);
            order.Courier = courier;

            order.StorageEndTime = order.OrderDate.AddDays(1);

            return order;
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
        public override Order<TDelivery, TNumber, TProdact> CheckoutOrder<TDelivery, TNumber, TProdact>(TNumber Number, string Description, Client person, string Address, TProdact prodact, Staff Courier = null)
        {
            Order<TDelivery, TNumber, TProdact> order = base.CheckoutOrder<TDelivery, TNumber, TProdact>(Number, Description, person, Address, prodact);
            PickPointCollection collection = new PickPointCollection();

            Address = collection[Address]?.Address ?? String.Empty;
            if (Address == String.Empty)
            {
                Console.WriteLine("Пункта выдачи по такому адресу не существует! Невозможно оформить заказ!");
                return null;
            }
            else
                this.Address = Address;

            order.StorageEndTime = order.OrderDate.AddDays(5);

            return order;
        }

        public void GetAllPickPoint()
        {
            PickPointCollection array = new PickPointCollection();
            PickPoint[] pickPoint = array.collection;

            Console.WriteLine("------------------------------Адреса пунктов выдачи-----------------------------");
            for (int i = 0; i < pickPoint.Length; i++)
            {
                Console.WriteLine(pickPoint[i].Address);
            }
        }

        public override void GetCompanyInfo()
        {
            Console.WriteLine("------------------------------Контакты Pick Point-------------------------------");
            Console.WriteLine($"Телефон:\t\t\t{PickPointContact.PhoneNumber}");
            Console.WriteLine($"Email:\t\t\t\t{PickPointContact.Email}");
        }

        class PickPoint
        {
            public string Address { get; set; }
        }
        class PickPointCollection
        {
            internal protected PickPoint[] collection = new PickPoint[]
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
    }

    class ShopDelivery : Delivery
    {
        public override Order<TDelivery, TNumber, TProdact> CheckoutOrder<TDelivery, TNumber, TProdact>(TNumber Number, string Description, Client person, string Address, TProdact prodact, Staff Courier = null)
        {
            Order<TDelivery, TNumber, TProdact> order = base.CheckoutOrder<TDelivery, TNumber, TProdact>(Number, Description, person, Address, prodact);

            order.StorageEndTime = order.OrderDate.AddDays(3);

            return order;
        }

        public override void GetCompanyInfo()
        {
            Console.WriteLine("------------------------------Магазин Shop------------------------------------");
            Console.WriteLine($"Адрес:\t\t\t\t{Shop.Address}");
            Console.WriteLine($"Телефон:\t\t\t{Shop.PhoneNumber}");
            Console.WriteLine($"Email:\t\t\t\t{Shop.Email}");
        }
    }
}
