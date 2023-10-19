namespace Lab_4
{
    class Cylinder
    {
        protected double r; 
        protected double h; 

        public Cylinder(double radius, double height)
        {
            r = radius;
            h = height;
        }

        public void Print()
        {
            Console.WriteLine($"r: {r}");
            Console.WriteLine($"h: {h}");
        }

        public virtual double Sqr()
        {
            // Площа поверхнi цилiндра
            double surfaceArea = 2 * Math.PI * r * (h + r);
            return surfaceArea;
        }

        public virtual double V()
        {
            // Об'єм цилiндра
            double volume = Math.PI * r * r * h;
            return volume;
        }
    }

    class Equilateral : Cylinder
    {
        public Equilateral(double radius) : base(radius, radius)
        {

        }

        public override double Sqr()
        {
            // Площа рiвностороннього цилiндра
            double surfaceArea = 6 * Math.PI * r * r;
            return surfaceArea;
        }

        public override double V()
        {
            // Об'єм рiвностороннього цилiндра
            double volume = 2 * Math.PI * r * r * r;
            return volume;
        }

        public double Volume()
        {
            double volume = (4.0 / 3.0) * Math.PI * r * r * r;
            return volume;
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            Random random = new Random();

            for (int i = 0; i < 3; i++)
            {
                double radius = random.Next(1, 10);
                double height = random.Next(5, 15); 

                Cylinder cylinder;
                if (i % 2 == 0)
                {
                    cylinder = new Cylinder(radius, height);
                    Console.WriteLine("Звичайний цилiндр:");
                }
                else
                {
                    cylinder = new Equilateral(radius);
                    Console.WriteLine("Рiвносторонiй цилiндр:");
                }

                cylinder.Print();
                Console.WriteLine($"Площа поверхнi: {cylinder.Sqr()}");
                Console.WriteLine($"Об'єм: {cylinder.V()}");

                if (cylinder is Equilateral equilateralCylinder)
                {                   
                    Console.WriteLine($"Об'єм вписаної кулi: {equilateralCylinder.Volume()}");
                }

                Console.WriteLine();
            }
        }
    }
}