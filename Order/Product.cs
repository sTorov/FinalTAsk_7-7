namespace Product
{
    enum ProductType
    {
        PowerSupply = 0,
        Processor,
        HardDrive,
        CorpusATX,
        CorpusMiniITX,
        ATXComputer,
        MiniITXComputer
    }
    
    abstract class Product
    {
        public double Cost { get; }
        public string Model { get; }
        public ProductType Type { get; protected set; }

        public Product(double cost, string model)
        {
            Cost = cost;
            Model = model;
        }

        public abstract void Characteristic();
    }

    class PowerSupply : ComputerPart
    {
        protected int Power;

        public PowerSupply() : base (1500, "PW-02")
        {
            Power = 25;
            Type = ProductType.PowerSupply;
        }
        public override void Characteristic() => Console.WriteLine($"Мощность блока питания:\t{Power} Вт"); 
    }
    class Processor : ComputerPart
    {
        protected double Frequency;
        public Processor() : base (5000, "Intel i3")
        {
            Frequency = 3.1;
            Type = ProductType.Processor;
        }
        public override void Characteristic() => Console.WriteLine($"Частота процессора:\t{Frequency} ГГц");
    }
    class HardDrive : ComputerPart
    {
        protected double Memory;
        public HardDrive() : base (4000, "Toshiba")
        {
            Memory = 512;
            Type = ProductType.HardDrive;
        }
        public override void Characteristic() => Console.WriteLine($"Память жесткого диска:\t{Memory} Гб");
    }


    abstract class ComputerPart : Product
    {
        public ComputerPart(double cost, string model) : base (cost, model) { }
    }


    enum MotherBoardFormFactor
    {
        ATX = 0,
        MiniITX
    }


    class Dimensions
    {
        public int Width { get; }
        public int Height { get; }
        public int Length { get; }

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

        public Corps(double cost, string model) : base (cost, model) { }
    }

    class ATXCorps : Corps
    {
        public ATXCorps() : base (3500, "ATX Corps")
        {
            MotherBoard = MotherBoardFormFactor.ATX;
            Dimensions = new Dimensions(210, 180, 220);
            CorpsMaterial = "Steel";
            Type = ProductType.CorpusATX;
        }
        public override void Characteristic()
        {
            Console.WriteLine($"Формфактор:\t\t{MotherBoard}");
            Console.WriteLine($"Ширина:\t\t\t{Dimensions.Width} мм");
            Console.WriteLine($"Высота:\t\t\t{Dimensions.Height} мм");
            Console.WriteLine($"Длина:\t\t\t{Dimensions.Length} мм");
            Console.WriteLine($"Материал корпуса:\t{CorpsMaterial}");
        }
    }

    class MiniITXCorps : Corps
    {
        public MiniITXCorps() : base (2500, "MiniITX Corps")
        {
            MotherBoard = MotherBoardFormFactor.MiniITX;
            Dimensions = new Dimensions(185, 274, 360);
            CorpsMaterial = "Aluminium";
            Type = ProductType.CorpusMiniITX;
        }
        public override void Characteristic()
        {
            Console.WriteLine($"Формфактор:\t{MotherBoard}");
            Console.WriteLine($"Ширина:\t{Dimensions.Width}");
            Console.WriteLine($"Высота:\t{Dimensions.Height}");
            Console.WriteLine($"Длина:\t{Dimensions.Length}");
            Console.WriteLine($"Материал корпуса:\t{CorpsMaterial}");
        }
    }

    abstract class Computer<TCorps> : Product where TCorps : Corps, new()
    {
        public Computer(double cost, string model) : base (cost, model) { }

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
        public ATXComputer() : base(25000, "ATX-2020") 
        {
            Type = ProductType.ATXComputer;
        }

        public override void ChangeComputerPart<TComputerPart>(TComputerPart newPart) 
        { 
            base.ChangeComputerPart<TComputerPart>(newPart);
        }
        public override void Characteristic()
        {
            powerSupply.Characteristic();
            processor.Characteristic();
            hardDrive.Characteristic();
            corps.Characteristic();
        }

    }
    class MiniITXComputer : Computer<MiniITXCorps>
    {
        public MiniITXComputer() : base(22000, "ITX-2021") 
        {
            Type = ProductType.MiniITXComputer;
        }

        public override void ChangeComputerPart<TComputerPart>(TComputerPart newPart) 
        {
            base.ChangeComputerPart<TComputerPart>(newPart);
        }
        public override void Characteristic()
        {
            powerSupply.Characteristic();
            processor.Characteristic();
            hardDrive.Characteristic();
            corps.Characteristic();
        }

    }
}
