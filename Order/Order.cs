namespace Order
{
    using Delivery;
    using Person;

    class Order<TDelivery, TNumber, TProdact> where TDelivery : Delivery
    {
        private TDelivery Delivery;

        public TProdact Prodact;
        public Client Client;
        public Staff Courier;

        public DateTime OrderDate;
        public DateTime StorageEndTime;

        public TNumber Number
        {
            get { return Number; } 
            internal set { Number = value; }
        }

        public string Description
        {
            get 
            { 
                return Description; 
            }
            internal set
            {
                Description = value;
            }
        }

        public bool OrderReceived { get; internal set; }        

        public void GetOrderTime(Order<TDelivery, TNumber, TProdact> order)
        {

        }

        public void DisplayAddress()
        {
            Console.WriteLine(Delivery.Address);
        }
        
        // ... Другие поля
    }
}
