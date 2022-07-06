namespace Order
{
    
    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF7;
            Console.InputEncoding = System.Text.Encoding.UTF7;

            MiniITXComputer miniITX = new MiniITXComputer();
            ATXComputer atx = new ATXComputer();

            Processor processor = new Processor();
            PowerSupply powerSupply = new PowerSupply();

            Client client1 = new Client("Dima", "Ivanov", "Ivanovich", "12", "-321321");
            Client client2 = new Client("Ivan", "Petrov", null, "23", "121212");
            Client client3 = new Client("Anton", null, null, "22 age", "111111");

            Staff staff1 = new Staff("Vasya", "Iridin", "123123");
            Staff staff2 = new Staff("Name", "Surname", "123123a");

            HomeDelivery home = new HomeDelivery("DDD", staff2);
            PickPointDelivery pickPoint = new PickPointDelivery("Address 3");
            ShopDelivery shop = new ShopDelivery();

            ShopOrder<int> order1 = new (client1, processor, 4431, "......");
            PickPointOrder<string> order2 = new(client2, atx, "ND-3412", "////", "Address 3");
            HomeOrder<int> order3 = new(client3, powerSupply, 4512, "//..,,,", "ADDress", staff2);

            order3.Delivery.Courier.Info();

            OrderCollection<Delivery, object, Product> collection = new();

            //collection.AddOrder(order1, order2, order3);

            Console.ReadKey();
        }
    }
}
