using System;

namespace OOP
{

    class Vehical
    {

    }

    class Car
    {
        int price;
        //{get; set;}  // it will work like getter and setter using . operator
        int modelYear;
        string brand;

        Car(int a, int b, string c)
        {
            price = a;
            modelYear = b;
            brand = c;
        }


        // Interface with Inheritance
        interface IAnimal
        {
            void animalSound(); // interface method (does not have a body)
        }

        // Pig "implements" the IAnimal interface
        class Pig : IAnimal
        {
            public void animalSound()
            {
                // The body of animalSound() is provided here
                Console.WriteLine("The pig says: wee wee");
            }
        }
        static void Main(string[] args)
        {
            Car obj1 = new Car(999, 1987, "Ford");
            Console.WriteLine($"Price : {obj1.price}");
            Console.WriteLine($"Year : {obj1.modelYear}");
            Console.WriteLine($"Brand : {obj1.brand}");

            Pig myPig = new Pig();  // Create a Pig object
            myPig.animalSound();
        }

    }

}