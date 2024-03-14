using System;
using System.Collections;
using System.Collections.Generic;

// Базовий клас Тварина
class Animal
{
    public string Name { get; set; }
    public int Age { get; set; }

    public Animal(string name, int age)
    {
        Name = name;
        Age = age;
    }

    public virtual void Show()
    {
        Console.WriteLine($"Тварина: {Name}, Вік: {Age} років");
    }
}

// Похідний клас Савець
class Mammal : Animal
{
    public string FurColor { get; set; }

    public Mammal(string name, int age, string furColor) : base(name, age)
    {
        FurColor = furColor;
    }

    public override void Show()
    {
        base.Show();
        Console.WriteLine($"Тип: Савець, Колір шерсті: {FurColor}");
    }
}

// Похідний клас Парнокопитне
class Ungulate : Mammal
{
    public string HoofType { get; set; }

    public Ungulate(string name, int age, string furColor, string hoofType) : base(name, age, furColor)
    {
        HoofType = hoofType;
    }

    public override void Show()
    {
        base.Show();
        Console.WriteLine($"Підтип: Парнокопитне, Тип копита: {HoofType}");
    }
}

// Похідний клас Птах
class Bird : Animal
{
    public string FeatherColor { get; set; }

    public Bird(string name, int age, string featherColor) : base(name, age)
    {
        FeatherColor = featherColor;
    }

    public override void Show()
    {
        base.Show();
        Console.WriteLine($"Тип: Птах, Колір пір'я: {FeatherColor}");
    }
}

// Клас-контейнер для тварин
class AnimalCollection : IEnumerable<Animal>
{
    private Animal[] animals;

    public AnimalCollection(Animal[] animals)
    {
        this.animals = animals;
    }

    public IEnumerator<Animal> GetEnumerator()
    {
        foreach (var animal in animals)
        {
            yield return animal;
        }
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }
}

class Program
{
    static void Main(string[] args)
    {
        // Приклад використання
        Animal[] animals = new Animal[]
        {
            new Mammal("Кіт", 3, "Чорний"),
            new Ungulate("Кінь", 5, "Коричневий", "Розгалуджене"),
            new Bird("Сорока", 2, "Сірий")
        };

        AnimalCollection animalCollection = new AnimalCollection(animals);

        foreach (Animal animal in animalCollection)
        {
            animal.Show();
            Console.WriteLine();
        }
    }
}


