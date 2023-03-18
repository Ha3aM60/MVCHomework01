internal class Car
{
    public string Name;
    public string Color;
    public string Author;
    public string Year;
    public string Motor;
    public Car()
    {

    }
}
public class CarController
{
    private List<Car> cars;

    public CarController()
    {
        cars = new List<Car>();
    }
    public void SaveToFile(string filePath)
    {
        using (StreamWriter writer = new StreamWriter(filePath))
        {
            foreach (var c in cars)
            {
                writer.WriteLine(c.Name);
                writer.WriteLine(c.Year);
                writer.WriteLine(c.Motor);
                writer.WriteLine(c.Color);
                writer.WriteLine(c.Author);
            }
        }
    }

    public void LoadFromFile(string filePath)
    {
        using (StreamReader reader = new StreamReader(filePath))
        {
            while (!reader.EndOfStream)
            {
                Car с = new Car();
                с.Name = reader.ReadLine();
                с.Year = reader.ReadLine();
                с.Motor = reader.ReadLine();
                с.Color = reader.ReadLine();
                с.Author = reader.ReadLine();
                cars.Add(с);
            }
        }
    }
    public void AddCar()
    {
        Car c = new Car();
        Console.WriteLine("Enter name:");
        c.Name = Console.ReadLine();
        Console.WriteLine("Enter color:");
        c.Color = Console.ReadLine();
        Console.WriteLine("Enter year:");
        c.Year = Console.ReadLine();
        Console.WriteLine("Enter motor:");
        c.Motor = Console.ReadLine();
        Console.WriteLine("Enter author:");
        c.Author = Console.ReadLine();
        cars.Add(c);
    }

    public void ShowCars()
    {
        Console.WriteLine("Cars:");
        foreach (var car in cars)
        {
            Console.WriteLine($"{car.Name} {car.Year} {car.Color} {car.Motor} {car.Author}");
        }
    }
}

internal class Drob
{
    public int Numerator;
    public int Denominator;
    public Drob()
    {
    }

    public Drob(int chiselnik, int znamennuk)
    {
        this.Numerator = chiselnik;
        this.Denominator = znamennuk;
    }
    public static Drob operator +(Drob a, Drob b)
    {
        int one = a.Numerator * b.Denominator + a.Denominator * b.Numerator;
        int two = a.Denominator * b.Denominator;
        return new Drob(one, two);
    }
    public static Drob operator -(Drob a, Drob b)
    {
        int one = a.Numerator * b.Denominator - a.Denominator * b.Numerator;
        int two = a.Denominator * b.Denominator;
        return new Drob(one, two);
    }
    public static Drob operator *(Drob a, Drob b)
    {
        int one = a.Numerator * b.Numerator;
        int two = a.Denominator * b.Denominator;
        return new Drob(one, two);
    }
    public static Drob operator /(Drob a, Drob b)
    {
        int one = a.Numerator * b.Denominator;
        int two = a.Denominator * b.Numerator;
        return new Drob(one, two);
    }
}
public class DrobController
{
    private List<Drob> drobs;

    public DrobController()
    {
        drobs = new List<Drob>();
    }
    public void SaveToFile(string filePath)
    {
        using (StreamWriter writer = new StreamWriter(filePath))
        {
            foreach (var d in drobs)
            {
                writer.WriteLine(d.Denominator);
                writer.WriteLine(d.Numerator);
            }
        }
    }
    public void Calc()
    {
        var a = new Drob();
        Console.WriteLine("Enter 1 drob Numerator");
        a.Numerator = Convert.ToInt32(Console.ReadLine());
        Console.WriteLine("Enter 1 drob Denominator");
        a.Denominator = Convert.ToInt32(Console.ReadLine());
        var b = new Drob();
        Console.WriteLine("Enter 2 drob Numerator");
        b.Numerator = Convert.ToInt32(Console.ReadLine());
        Console.WriteLine("Enter 2 drob Denominator");
        b.Denominator = Convert.ToInt32(Console.ReadLine());
        Console.WriteLine("Enter action:");
        var action = Console.ReadLine();
        var result = new Drob();
        switch (action)
        {
            case "+":
                result = a + b;
                break;
            case "/":
                result = a / b;
                break;
            case "*":
                result = a * b;
                break;
            case "-":
                result = a - b;
                break;
            default:
                break;
        }
        Console.WriteLine($"{result.Numerator}/{result.Denominator}");
    }
    public void LoadFromFile(string filePath)
    {
        using (StreamReader reader = new StreamReader(filePath))
        {
            while (!reader.EndOfStream)
            {
                Drob d = new Drob();
                d.Denominator = Convert.ToInt32(reader.ReadLine());
                d.Numerator = Convert.ToInt32(reader.ReadLine());
                drobs.Add(d);
            }
        }
    }
    public void AddDrob()
    {
        Drob c = new Drob();
        Console.WriteLine("Enter denominator:");
        c.Denominator = Convert.ToInt32(Console.ReadLine());
        Console.WriteLine("Enter numerator:");
        c.Numerator = Convert.ToInt32(Console.ReadLine());
        drobs.Add(c);
    }

    public void ShowDrobs()
    {
        Console.WriteLine("Drobs:");
        foreach (var d in drobs)
        {
            Console.WriteLine($"{d.Denominator}/{d.Numerator}");
        }
    }
}

internal partial class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Enter choice");
        Console.WriteLine("1. Car");
        Console.WriteLine("2. Drob");
        string num = Console.ReadLine();
        if (num == "1")
        {
            CarController controller = new CarController();

            while (true)
            {
                Console.WriteLine("Enter choice:");
                Console.WriteLine("1. Save to file");
                Console.WriteLine("2. Read from file");
                Console.WriteLine("3. Add car");
                Console.WriteLine("4. Show");
                Console.WriteLine("5. Exit");

                var choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        controller.SaveToFile("car.txt");
                        break;
                    case "2":
                        controller.LoadFromFile("car.txt");
                        break;
                    case "3":
                        controller.AddCar();
                        break;
                    case "4":
                        controller.ShowCars();
                        break;
                    case "5":
                        return;
                    default:
                        break;
                }
            }
        }
        else if (num == "2")
        {
            DrobController controller = new DrobController();

            while (true)
            {
                Console.WriteLine("Choose an action:");
                Console.WriteLine("1. Add drob");
                Console.WriteLine("2. Show");
                Console.WriteLine("3. Save to file");
                Console.WriteLine("4. Read from file");
                Console.WriteLine("5. Calculator");
                Console.WriteLine("6. Exit");

                var choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        controller.AddDrob();
                        break;
                    case "2":
                        controller.ShowDrobs();
                        break;
                    case "3":
                        controller.SaveToFile("drob.txt");
                        break;
                    case "4":
                        controller.LoadFromFile("drob.txt");
                        break;
                    case "5":
                        controller.Calc();
                        return;
                    default:
                        break;
                }
            }
        }
    }
}
