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
        private PickPointCollection allPickPoint;

        public PickPointDelivery(string address) : base (null)
        {
            allPickPoint = new PickPointCollection();
            Address = allPickPoint[address];
            Address ??= "Пункта выдачи с таким адресом не существует";
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
        private PickPoint[] points;
        public int Length { get; }
        
        public PickPointCollection()
        {
            points  = new PickPoint[]
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
}
