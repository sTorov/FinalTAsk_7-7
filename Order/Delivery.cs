namespace Order
{
    abstract class Delivery
    {
        public string Address;
        public DateTime OrderDate;

        public Delivery (string address)
        {
            Address = address;
            OrderDate = DateTime.Now;
        }

    }

    class HomeDelivery : Delivery
    {
        public Staff Courier;
        public DateTime TimeOfDelivery;

        public HomeDelivery(string address, Staff courier) : base (address) 
        {
            Courier = courier;
            TimeOfDelivery = OrderDate.AddDays(1);
        }          
    }

    class PickPointDelivery : Delivery
    {
        public DateTime StorageEndTime;

        public PickPointDelivery(string address) : base (null)
        {
            
            for (int i = 0; i < PickPointCollection.collection.Length ; i++)
            {
                if (PickPointCollection.collection[i].Address == address)
                    Address = address;
            }
            Address ??= "Пункта выдачи по данному адресу не существует!";

            StorageEndTime = OrderDate.AddDays(5);
        }       

               
    }

    class ShopDelivery : Delivery
    {
        public DateTime StorageEndTime;

        public ShopDelivery() : base (Shop.Address)
        {
            StorageEndTime = OrderDate.AddDays(3);
        }        
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
}
