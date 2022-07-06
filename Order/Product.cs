namespace Order
{
    abstract class Product
    {
        public string Name { get; }
        public double Cost { get; }
        public string Model { get; }

        public Product(string name, double cost, string model)
        {
            Name = name;
            Cost = cost;
            Model = model;
        }

    }

    class PowerSupply : ComputerPart
    {
        protected int Power;

        public PowerSupply() : base ("Power", 1500, "PW-02")
        {
            Power = 25;
        }
    }
    class Processor : ComputerPart
    {
        protected double Frequency;
        public Processor() : base ("Processor", 5000, "Intel i3")
        {
            Frequency = 3.1;
        }
    }
    class HardDrive : ComputerPart
    {
        protected double Memory;
        public HardDrive() : base ("Disk", 4000, "Toshiba")
        {
            Memory = 512;
        }
    }


    class ComputerPart : Product
    {
        public ComputerPart(string name, double cost, string model) : base (name, cost, model) { }
    }


    enum MotherBoardFormFactor
    {
        ATX = 0,
        MiniITX
    }


    class Dimensions
    {
        private int Width;
        private int Height;
        private int Length;

        public Dimensions(int Width, int Height, int Length)
        {
            this.Width = Width;
            this.Height = Height;
            this.Length = Length;
        }
    }

    abstract class Corps : Product
    {
        protected string CorpsMaterial { get; set; }
        protected MotherBoardFormFactor MotherBoard { get; set; }
        protected Dimensions Dimensions { get; set; }

        public Corps(string name, double cost, string model) : base (name, cost, model) { }
    }

    class ATXCorps : Corps
    {
        public ATXCorps() : base ("Corpus", 3500, "ATX Corps")
        {
            MotherBoard = MotherBoardFormFactor.ATX;
            Dimensions = new Dimensions(210, 180, 220);
            CorpsMaterial = "Steel";
        }
    }

    class MiniITXCorps : Corps
    {
        public MiniITXCorps() : base ("Corpus", 2500, "MiniITX Corps")
        {
            MotherBoard = MotherBoardFormFactor.MiniITX;
            Dimensions = new Dimensions(185, 274, 360);
            CorpsMaterial = "Aluminium";
        }
    }

    abstract class Computer<TCorps> : Product where TCorps : Corps, new()
    {
        public Computer(string name, double cost, string model) : base (name, cost, model) { }

        protected PowerSupply powerSupply = new PowerSupply();
        protected Processor processor = new Processor();
        protected HardDrive hardDrive = new HardDrive();
        protected TCorps corps = new TCorps();

        public virtual void ChangeComputerPart<TComputerPart>(TComputerPart newPart) where TComputerPart : ComputerPart
        {
            processor = newPart as Processor ?? processor;
            powerSupply = newPart as PowerSupply ?? powerSupply;
            hardDrive = newPart as HardDrive ?? hardDrive;
        }

    }

    class ATXComputer : Computer<ATXCorps> 
    {
        public ATXComputer() : base("ATXComp", 25000, "ATX-2020") { }
        public override void ChangeComputerPart<TComputerPart>(TComputerPart newPart) 
        { 
            base.ChangeComputerPart<TComputerPart>(newPart);
        }
    }
    class MiniITXComputer : Computer<MiniITXCorps>
    {
        public MiniITXComputer() : base("MiniITXComp", 22000, "ITX-2021") { }
        public override void ChangeComputerPart<TComputerPart>(TComputerPart newPart) 
        {
            base.ChangeComputerPart<TComputerPart>(newPart);
        }
    }
}
