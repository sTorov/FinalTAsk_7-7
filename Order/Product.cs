namespace Product
{
    abstract class Product
    {
        protected internal string Name { get; internal set; }
        protected internal double Cost { get; internal set; }
        protected internal string Model { get; internal set; }
        protected internal string Description { get; internal set; }
    }

    class PowerSupply : Product 
    {
        protected internal int Power { get; internal set; }
    }
    class Processor : Product
    {
        protected internal double Frequency { get; internal set; }
    }
    class HardDrive : Product
    {
        protected internal double Memory { get; internal set; }
    }
    class ComputerPart
    {
        protected internal PowerSupply PowerSupply { get; internal set; }
        protected internal HardDrive HardDrive { get; internal set; }
        protected internal Processor Processor { get; internal set; }
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

        protected internal Dimensions(int Width, int Height, int Length)
        {
            this.Width = Width;
            this.Height = Height;
            this.Length = Length;
        }
    }

    abstract class Corps : Product
    {
        protected internal string CorpsMaterial { get; set; }

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

        protected internal abstract void ChangeComputerPart<TComputerPart>(TComputerPart newPart) where TComputerPart : ComputerPart;

    }

    class ATXComputer<TComputer> : Computer<ATX<Corps>> 
    {
        protected internal override void ChangeComputerPart<TComputerPart>(TComputerPart newPart) 
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
        protected internal override void ChangeComputerPart<TComputerPart>(TComputerPart newPart) 
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
