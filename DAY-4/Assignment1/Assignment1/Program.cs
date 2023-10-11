using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment1
{

    internal class Program
    {
        static void Main(string[] args)
        {
            Car car = new Car(4, "Petrol") { Make = "Toyota", Model = "Corolla", Year = 2022, Color = "Blue" };
            car.Start();
            car.Stop();

            Bicycle bicycle = new Bicycle(21, "Aluminum") { Make = "Giant", Model = "Defy", Year = 2021, Color = "Red" };
            bicycle.Start();
            bicycle.pedal();
            bicycle.Stop();

            Motorcycle motorcycle = new Motorcycle { Make = "Honda", Model = "CBR", Year = 2020, Color = "Black" };
            motorcycle.Start();
            motorcycle.StartEngine();
            motorcycle.Stop();
        }
    }
    public class Vehicle
    { // Common properties for all vehicles
        protected internal string Make { get; set; }
        protected internal string Model { get; set; }
        protected internal int Year { get; set; }
        protected internal string Color { get; set; }

        // Common methods for all vehicles
        public virtual void Start()
        {
            Console.WriteLine("Vehicle starting...");
        }

        public void Stop()
        {
            Console.WriteLine("Vehicle stopping...");
        }
    }

    public class Car : Vehicle
    {
        // Specific properties for Car
        private int NumberOfDoors { get; set; }
        private string FuelType { get; set; }

        // Constructor
        public Car(int numberOfDoors, string fuelType)
        {
            NumberOfDoors = numberOfDoors;
            FuelType = fuelType;
        }

        public override void Start()
        {
            Console.WriteLine("Car starting...");
        }
    }

    public class Bicycle : Vehicle
    {
        // Specific properties for Bicycle
        private int NumberOfGears { get; set; }
        private string FrameMaterial { get; set; }

        // Constructor
        public Bicycle(int numberOfGears, string frameMaterial)
        {
            NumberOfGears = numberOfGears;
            FrameMaterial = frameMaterial;
        }

        public void pedal()
        {
            Console.WriteLine("Bicycle pedaling");
        }
    }

    public class Motorcycle : Vehicle
    {
        public void StartEngine()
        {
            Console.WriteLine("Motorcycle engine starting...");
        }
    }

}
