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
    enum MotherBoard
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

    }

    class ATX<TCorps> : Corps where TCorps : Corps
    {
        protected MotherBoard MotherBoard = MotherBoard.ATX;
        protected Dimensions Dimensions = new Dimensions(210, 410, 478);
    }

    class MiniITX<TCorps> : Corps where TCorps : Corps
    {
        protected MotherBoard MotherBoard = MotherBoard.MiniITX;
        protected Dimensions Dimensions = new Dimensions(185, 274, 360);
    }

    abstract class Computer<TCorps> : Corps where TCorps : Corps, new()
    {
        protected TCorps Corps = new TCorps();
        protected ComputerPart part = new ComputerPart();

        public abstract void ChangeComputerPart<TComputerPart>(TComputerPart newPart) where TComputerPart : ComputerPart;

    }

    class ATXComputer<TComputer> : Computer<ATX<Corps>> 
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
    class MiniITXComputer<TComputer> : Computer<MiniITX<Corps>>
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
