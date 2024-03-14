using System;

// Інтерфейси .NET
public interface ITransport
{
    void DisplayInformation();
}

public interface Trans : ITransport
{
    double LoadCapacity { get; }
}

// Базовий клас для транспортних засобів
public abstract class Vehicle : Trans
{
    public string Brand { get; set; }
    public string RegistrationNumber { get; set; }
    public int Speed { get; set; }
    public double LoadCapacity { get; protected set; }

    public Vehicle(string brand, string regNumber, int speed, double loadCapacity)
    {
        Brand = brand;
        RegistrationNumber = regNumber;
        Speed = speed;
        LoadCapacity = loadCapacity;
    }

    public abstract void DisplayInformation();
}

// Легкова машина
public class Car : Vehicle
{
    public Car(string brand, string regNumber, int speed, double loadCapacity) : base(brand, regNumber, speed, loadCapacity) { }

    public override void DisplayInformation()
    {
        Console.WriteLine($"Car: Brand - {Brand}, Registration Number - {RegistrationNumber}, Speed - {Speed}, Load Capacity - {LoadCapacity}");
    }
}

// Мотоцикл
public class Motorcycle : Vehicle
{
    public bool Sidecar { get; set; }

    public Motorcycle(string brand, string regNumber, int speed, double loadCapacity, bool sidecar) : base(brand, regNumber, speed, loadCapacity)
    {
        Sidecar = sidecar;
        if (!sidecar)
            LoadCapacity = 0;
    }

    public override void DisplayInformation()
    {
        Console.WriteLine($"Motorcycle: Brand - {Brand}, Registration Number - {RegistrationNumber}, Speed - {Speed}, Load Capacity - {LoadCapacity}");
    }
}

// Вантажівка
public class Truck : Vehicle
{
    public bool Trailer { get; set; }

    public Truck(string brand, string regNumber, int speed, double loadCapacity, bool trailer) : base(brand, regNumber, speed, loadCapacity)
    {
        Trailer = trailer;
        if (trailer)
            LoadCapacity *= 2;
    }

    public override void DisplayInformation()
    {
        Console.WriteLine($"Truck: Brand - {Brand}, Registration Number - {RegistrationNumber}, Speed - {Speed}, Load Capacity - {LoadCapacity}");
    }
}

class Program
{
    static void Main(string[] args)
    {
        Vehicle[] vehicles = new Vehicle[]
        {
            new Car("Toyota", "AB1234", 120, 400),
            new Motorcycle("Honda", "XY5678", 180, 200, true),
            new Truck("Volvo", "CD9012", 80, 2000, false)
        };

        foreach (var vehicle in vehicles)
        {
            vehicle.DisplayInformation();
        }

        // Пошук транспортних засобів з вантажопідйомністю більше 500
        Console.WriteLine("\nVehicles with load capacity greater than 500:");
        foreach (var vehicle in vehicles)
        {
            if (vehicle.LoadCapacity > 500)
                vehicle.DisplayInformation();
        }
    }
}
