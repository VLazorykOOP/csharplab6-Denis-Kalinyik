public interface IUserInterface
{
    void Display();
}

// Інтерфейси .NET
public interface IDotNetInterface
{
    void DotNetFunctionality();
}

// Базовий клас
public abstract class Item : IUserInterface
{
    public string Name { get; set; }
    public double Weight { get; set; }

    public Item(string name, double weight)
    {
        Name = name;
        Weight = weight;
    }

    public virtual void Show()
    {
        Console.WriteLine($"Name: {Name}, Weight: {Weight}");
    }

    public virtual void Display()
    {
        Show();
    }
}

// Деталь
public class Part : Item
{
    public string Material { get; set; }

    public Part(string name, double weight, string material) : base(name, weight)
    {
        Material = material;
    }

    public override void Display()
    {
        base.Display();
        Console.WriteLine($"Material: {Material}");
    }
}

// Механізм
public class Mechanism : Item, IDotNetInterface
{
    public int NumberOfParts { get; set; }

    public Mechanism(string name, double weight, int numberOfParts) : base(name, weight)
    {
        NumberOfParts = numberOfParts;
    }

    public override void Display()
    {
        base.Display();
        Console.WriteLine($"Number of Parts: {NumberOfParts}");
    }

    public void DotNetFunctionality()
    {
        // Реалізація функціоналу інтерфейсу .NET
        Console.WriteLine("DotNetFunctionality() implemented for Mechanism");
    }
}

// Виріб
public class Product : Item, IDotNetInterface
{
    public string Category { get; set; }

    public Product(string name, double weight, string category) : base(name, weight)
    {
        Category = category;
    }

    public override void Display()
    {
        base.Display();
        Console.WriteLine($"Category: {Category}");
    }

    public void DotNetFunctionality()
    {
        // Реалізація функціоналу інтерфейсу .NET
        Console.WriteLine("DotNetFunctionality() implemented for Product");
    }
}

// Вузол
public class Node : Item
{
    public int Connections { get; set; }

    public Node(string name, double weight, int connections) : base(name, weight)
    {
        Connections = connections;
    }

    public override void Display()
    {
        base.Display();
        Console.WriteLine($"Connections: {Connections}");
    }
}

class Program
{
    static void Main(string[] args)
    {
        Part screw = new Part("Screw", 0.05, "Steel");
        screw.Display();

        Mechanism engine = new Mechanism("Engine", 120.5, 150);
        engine.Display();
        engine.DotNetFunctionality();

        Product chair = new Product("Chair", 10.0, "Furniture");
        chair.Display();
        chair.DotNetFunctionality();

        Node networkNode = new Node("Router", 2.5, 8);
        networkNode.Display();
    }
}
