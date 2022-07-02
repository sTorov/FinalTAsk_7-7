namespace Product
{
    abstract class Product
    {
        public string Name { get; set; }
        public double Cost { get; set; }
        public string Model { get; set; }
    }

    class PowerSupply : Product 
    {
        public int Power { get; set; }
    }
    class Processor : Product
    {
        public double Frequency { get; set; }
    }
    class HardDrive : Product
    {
        public double Memory { get; set; }
    }


    class ComputerPart
    {
        public PowerSupply PowerSupply { get; set; }
        public HardDrive HardDrive { get; set; }
        public Processor Processor { get; set; }
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

        public Corps(string name, double cost, string model)
        {
            Name = name;
            Cost = cost;
            Model = model;
        }
    }

    class ATX : Corps
    {
        public ATX() : base ("Corps", 3500, "ATX Corps")
        {
            MotherBoard = MotherBoardFormFactor.ATX;
            Dimensions = new Dimensions(210, 180, 220);
            CorpsMaterial = "Steel";
        }
    }

    class MiniITX : Corps
    {
        public MiniITX() : base ("Corps", 2500, "MiniITX Corps")
        {
            MotherBoard = MotherBoardFormFactor.MiniITX;
            Dimensions = new Dimensions(185, 274, 360);
            CorpsMaterial = "Aluminium";
        }
    }

    abstract class Computer<TCorps> : Product where TCorps : Corps, new()
    {
        protected ComputerPart part = new ComputerPart();
        protected TCorps corps = new TCorps();

        public abstract void ChangeComputerPart<TComputerPart>(TComputerPart newPart) where TComputerPart : ComputerPart;

    }

    class ATXComputer : Computer<ATX> 
    {
        public override void ChangeComputerPart<TComputerPart>(TComputerPart newPart) 
        { 
            part = new ComputerPart
            {
                HardDrive = newPart?.HardDrive ?? part.HardDrive,
                PowerSupply = newPart?.PowerSupply ?? part.PowerSupply,
                Processor = newPart?.Processor ?? part.Processor
            };
        }
    }
    class MiniITXComputer : Computer<MiniITX>
    {
        public override void ChangeComputerPart<TComputerPart>(TComputerPart newPart) 
        {
            part = new ComputerPart
            {
                HardDrive = newPart?.HardDrive ?? part.HardDrive,
                PowerSupply = newPart?.PowerSupply ?? part.PowerSupply,
                Processor = newPart?.Processor ?? part.Processor
            };
        }
    }
}
