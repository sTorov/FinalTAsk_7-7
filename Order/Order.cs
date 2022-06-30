namespace Order
{
    using Delivery;

    class Order<TDelivery, TNumber> where TDelivery : Delivery
    {
        public TDelivery Delivery;
        
        private TNumber number;
        public TNumber Number
        {
            get 
            { 
                return number; 
            }
        }
        
        private string description;
        public string Description
        {
            get 
            { 
                return description; 
            }
            private set
            {
                description = value;
            }
        }

        private bool orderReceived;
        public bool OrderReceived { get; private set; }

        public void DisplayAddress()
        {
            Console.WriteLine(Delivery.Address);
        }
        
        // ... Другие поля
    }
}
