using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Car car = new Car { Make = "Toyota", Model = "Corolla", Year = 2022, Color = "Blue", NumberOfDoors = 4, FuelType = "Petrol" };
            car.Start();
            car.StartEngine();
            Console.WriteLine("Fuel Efficiency: " + car.CalculateFuelEfficiency());
            car.Stop();

            Bicycle bicycle = new Bicycle { Make = "Giant", Model = "Defy", Year = 2021, Color = "Red", NumberOfGears = 21, FrameMaterial = "Aluminum" };
            bicycle.Start();
            bicycle.StartEngine(); // Bicycle doesn't have an engine
            Console.WriteLine("Fuel Efficiency: " + bicycle.CalculateFuelEfficiency());
            bicycle.Stop();

            Motorcycle motorcycle = new Motorcycle { Make = "Honda", Model = "CBR", Year = 2020, Color = "Black" };
            motorcycle.Start();
            motorcycle.StartEngine();
            Console.WriteLine("Fuel Efficiency: " + motorcycle.CalculateFuelEfficiency());
            motorcycle.Stop();

        }
    }

    public class Vehicle
    {
        public string Make { get; set; }
        public string Model { get; set; }
        public int Year { get; set; }
        public string Color { get; set; }

        public void Start()
        {
            Console.WriteLine("Vehicle starting...");
        }

        public void Stop()
        {
            Console.WriteLine("Vehicle stopping...");
        }
    }


    public interface IVehicleOperations
    {
        void StartEngine();
        double CalculateFuelEfficiency();
    }
    public class Car : Vehicle, IVehicleOperations
    {
        public int NumberOfDoors { get; set; }
        public string FuelType { get; set; }

        public void StartEngine()
        {
            Console.WriteLine("Car engine starting...");
        }

        public double CalculateFuelEfficiency()
        {
            // Calculate fuel efficiency for a car
            return 25.0; // Dummy value for demonstration
        }
    }

    public class Bicycle : Vehicle, IVehicleOperations
    {
        public int NumberOfGears { get; set; }
        public string FrameMaterial { get; set; }

        public void StartEngine()
        {
            Console.WriteLine("Bicycle doesn't have an engine.");
        }

        public double CalculateFuelEfficiency()
        {
            // Bicycle doesn't use fuel, so return 0
            return 0;
        }
    }

    public class Motorcycle : Vehicle, IVehicleOperations
    {
        public void StartEngine()
        {
            Console.WriteLine("Motorcycle engine starting...");
        }

        public double CalculateFuelEfficiency()
        {
            // Calculate fuel efficiency for a motorcycle
            return 30.0; // Dummy value for demonstration
        }
    }


}
