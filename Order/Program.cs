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

            Client client1 = new Client("Dima", "Ivanov", "Ivanovich", "12", "321321");
            Client client2 = new Client("Ivan", "Petrov", null, "23", "121212");
            Client client3 = new Client("", null, "", "22 age", "-111111");

            Staff staff1 = new Staff("Vasya", "Iridin", "123123");
            Staff staff2 = new Staff("Name", "Surname", "123123a");

            ShopOrder<Processor> order1 = new(client1, processor, 4431, "......");
            PickPointOrder<ATXComputer> order2 = new(client2, atx, 12, "////", "Address 3");
            HomeOrder<PowerSupply> order3 = new(client3, powerSupply, 4512, "//..,,,", "ADDress", staff1);
            HomeOrder<PowerSupply> order4 = new(client3, powerSupply, 123, "//..,,,", "ADDress", staff2);

            Console.Clear();

            OrderCollection collection = new();
            var allOrders = collection.GetAllOrders();
            collection.ViewAllOrders(allOrders);
            Console.WriteLine();

            collection.AddOrder(order2, order3, order1, order4);
            allOrders = collection.GetAllOrders();
            collection.ViewAllOrders(allOrders);
            Console.WriteLine();

            var array = collection.GetOrderCollection<PickPointDelivery, ATXComputer>(allOrders);
            collection.ViewAllOrders(array);

            Console.WriteLine();

            var check1 = !client1;
            var check2 = !client2;
            Console.WriteLine(!client3);


            Console.ReadKey();
        }
    }
}
