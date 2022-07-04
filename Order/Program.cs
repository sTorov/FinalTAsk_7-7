namespace Order
{
    using Person;
    using Product;
    using Delivery;
    using Order;

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

            Client client = new Client("CLient", null, "44", null, null);
            Staff staff = new Staff("Staff", "123", "123", "123", "123");

            HomeDelivery home = new HomeDelivery("DDD", client, staff);
            PickPointDelivery pickPoint = new PickPointDelivery("Address 3", client);
            ShopDelivery shop = new ShopDelivery(client);

            home.GetCompanyInfo(); pickPoint.GetCompanyInfo(); shop.GetCompanyInfo();
            pickPoint.GetAllPickPoint();

            Console.ReadKey();
        }
    }
}
