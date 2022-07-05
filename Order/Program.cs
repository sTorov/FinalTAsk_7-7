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

            ShopOrder<int, Processor> order1 = new (client, processor, 4431, "......");
            PickPointOrder<string, ATXComputer> order2 = new(client, atx, "ND-3412", "////", "Address 3");
            HomeOrder<int, PowerSupply> order3 = new(client, powerSupply, 4512, "//..,,,", "ADDress", staff);


            order2.Client.Info();

            Console.ReadKey();
        }
    }
}
