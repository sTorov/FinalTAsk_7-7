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
            Client client3 = new Client("Anton", null, "", "22 age", "111111");

            Staff staff1 = new Staff("Vasya", "Iridin", "123123");
            Staff staff2 = new Staff("Name", "Surname", "123123a");

            ShopOrder order1 = new (client1, processor, 4431, "......");
            PickPointOrder order2 = new(client2, atx, 12, "////", "Address 3");
            HomeOrder order3 = new(client3, powerSupply, 4512, "//..,,,", "ADDress", staff2);
            HomeOrder order4 = new(client3, powerSupply, 123, "//..,,,", "ADDress", staff2);

            order3.Delivery.Courier.Info();

            OrderCollection collection = new();
            collection.AddOrder<HomeDelivery>(order1, order2, order3);

            OrderCollection collection2 = new();
            collection2.AddOrder(order1, order2, order3, order4);

            AllOrders or = collection2[12];
            AllOrders or2 = collection[12];

            PickPointOrder pickOr = (PickPointOrder)or;


            string fullName = client1.GetFullName();
            string fullName2 = client2.GetFullName();
            string fullName3 = client3.GetFullName();

            Console.ReadKey();
        }
    }
}
