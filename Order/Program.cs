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

            Processor processor = new Processor(33.33, "PPPPPP");
            PowerSupply powerSupply = new PowerSupply(150, "QWERTY");

            atx.ChangeComputerPart(powerSupply);

            Client client = new Client("Name", "Surname", "Lastname", "23", "321321");
            Staff staff = new Staff("Name", "Surname", "123123");

            HomeDelivery home = new HomeDelivery("DDD", staff);
            PickPointDelivery pickPoint = new PickPointDelivery("Address 3");
            ShopDelivery shop = new ShopDelivery();

            ShopDeliveryOrder<int, Processor> order1 = new (client, processor, 4431, "......");
            PickPointDeliveryOrder<string, ATXComputer> order2 = new(client, atx, "Address 3", "ND-3412", "////");
            HomeDeliveryOrder<int, PowerSupply> order3 = new(client, powerSupply, "ADDres" , 4512, "//..,,,", staff);

            //string asd = PickPointCollection.collection["asd"];

            order2.GetAllPickPoint();

            Console.ReadKey();
        }
    }
}
