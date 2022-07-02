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

            //Staff staff = new Staff();
            //staff.GetInfo();
            //staff.GetCompanyInfo();

            Console.WriteLine();

            MiniITXComputer computer1 = new MiniITXComputer { Cost = 25000, Model = "PC", Name = "Asus" };
            ComputerPart newPart = new ComputerPart
            {
                Processor = new Processor {  Cost = 10000, Model = "p", Name = "Processor", Frequency = 2.5 },
                PowerSupply = new PowerSupply { Cost = 1000, Model = "pw", Name = "Power", Power = 25 },
                HardDrive = new HardDrive { Cost = 3000, Model = "hd", Name = "Disk", Memory = 34 }
            };

            computer1.ChangeComputerPart(newPart);

            Console.ReadLine();

            ComputerPart computerPart = new ComputerPart
            {
                Processor = new Processor { Frequency = 4 }
            };
            computer1.ChangeComputerPart(computerPart);

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
