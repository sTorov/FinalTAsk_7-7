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

            //Client client = new Client("Ivan", null, "44", null, null);
            //Staff staff = new Staff("123", "123", "123", "123", "123");
            //ShopDelivery shop = new ShopDelivery();
            //HomeDelivery home = new HomeDelivery();
            //PickPointDelivery point = new PickPointDelivery();

            //Order<Delivery, int, Product> order = shop.CheckoutOrder<Delivery, int, Product>(1234, "desc", client, Shop.Address, computer1);
            //Order<Delivery, int, Product> order2 = home.CheckoutOrder<Delivery, int, Product>(1234, "desc", client, "Add", computer1, staff);
            //Order<Delivery, int, Product> order3 = point.CheckoutOrder<Delivery, int, Product>(1234, "desc", client, "Address 5", computer1);

            //client.GetInfo();
            //staff.GetInfo();

            Console.ReadKey();
        }
    }
}
