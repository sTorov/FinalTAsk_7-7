namespace Product
{
    abstract class Product
    {
        public string Name { get; set; }
        public double Cost { get; set; }
        public string Model { get; set; }

        public Product(string name, double cost, string model)
        {
            Name = name;
            Cost = cost;
            Model = model;
        }

    }

    class PowerSupply : ComputerPart
    {
        public int Power { get; set; }

        public PowerSupply() : base ("Power", 1500, "PW-02")
        {
            Power = 25;
        }
        public PowerSupply(int power, string name) : base(name, 1500, "PW-02")
        {
            Power = power;
        }
    }
    class Processor : ComputerPart
    {
        public double Frequency { get; set; }
        public Processor() : base ("Processor", 5000, "Intel i3")
        {
            Frequency = 3.1;
        }
        public Processor(double frequency, string name) : base (name, 5000, "Intel i3")
        {
            Frequency = frequency;
        }
    }
    class HardDrive : ComputerPart
    {
        public double Memory { get; set; }
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
        public string CorpsMaterial { get; set; }
        public MotherBoardFormFactor MotherBoard { get; set; }
        public Dimensions Dimensions { get; set; }

        public Corps(string name, double cost, string model) : base (name, cost, model) { }
    }

    class ATX : Corps
    {
        public ATX() : base ("Corpus", 3500, "ATX Corps")
        {
            MotherBoard = MotherBoardFormFactor.ATX;
            Dimensions = new Dimensions(210, 180, 220);
            CorpsMaterial = "Steel";
        }
    }

    class MiniITX : Corps
    {
        public MiniITX() : base ("Corpus", 2500, "MiniITX Corps")
        {
            MotherBoard = MotherBoardFormFactor.MiniITX;
            Dimensions = new Dimensions(185, 274, 360);
            CorpsMaterial = "Aluminium";
        }
    }

    abstract class Computer<TCorps> : Product where TCorps : Corps, new()
    {
        protected Computer(string name, double cost, string model) : base (name, cost, model) { }

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

    class ATXComputer : Computer<ATX> 
    {
        public ATXComputer() : base("ATXComp", 25000, "ATX-2020") { }
        public override void ChangeComputerPart<TComputerPart>(TComputerPart newPart) 
        { 
            base.ChangeComputerPart<TComputerPart>(newPart);
        }
    }
    class MiniITXComputer : Computer<MiniITX>
    {
        public MiniITXComputer() : base("MiniITXComp", 22000, "ITX-2021") { }
        public override void ChangeComputerPart<TComputerPart>(TComputerPart newPart) 
        {
            base.ChangeComputerPart<TComputerPart>(newPart);
        }
    }
}
