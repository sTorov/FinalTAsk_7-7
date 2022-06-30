namespace Order
{
    using Person;
    using Product;

    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF7;
            Console.InputEncoding = System.Text.Encoding.UTF7;

            Staff staff = new Staff();
            staff.GetInfo();
            staff.GetCompanyInfo();

            //Console.WriteLine();

            //ATXComputer<ATX<Corps>> computer = new ATXComputer<ATX<Corps>>();
            //MiniITXComputer<MiniITX<Corps>> computer1 = new MiniITXComputer<MiniITX<Corps>>();
            //ComputerPart newPart = new ComputerPart { 
            //    Processor = new Processor{ Frequency = 2.5, Model = "xxx", Cost = 10000, Description = "dsa", Name = "Proc"},
            //    PowerSupply = new PowerSupply { Cost = 2500, Description = "dsa", Model = "qwe", Name = "Pow", Power = 25},
            //    HardDrive = new HardDrive { Cost = 12345, Name = "Name", Description = "dsaasd", Memory = 34, Model = "Dsa123"}
            //};
            //computer.ChangeComputerPart(newPart);
            //ComputerPart computerPart = new ComputerPart
            //{
            //    Processor = new Processor { Frequency = 4 }
            //};
            //computer.ChangeComputerPart(computerPart);

            Console.ReadKey();
        }
    }
}
