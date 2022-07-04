namespace Order
{
    using Delivery;
    using Product;

    class Order<TDelivery, TNumber, TProdact> 
        where TDelivery : Delivery
        where TProdact : Product
    {
        public TDelivery Delivery;
        public TProdact Prodact;

        public TNumber Number { get; set; }

        public string Description { get; set; }        

        public bool OrderReceived { get; set; }
        
        public Order(TDelivery delivery, TProdact prodact, TNumber number, string description)
        {
            Delivery = delivery;
            Prodact = prodact;
            Number = number;
            Description = description;
        }


        public void GetOrderTime(Order<TDelivery, TNumber, TProdact> order)
        {

        }

        public void DisplayAddress()
        {
            Console.WriteLine(Delivery.Address);
        }        
    }
}
