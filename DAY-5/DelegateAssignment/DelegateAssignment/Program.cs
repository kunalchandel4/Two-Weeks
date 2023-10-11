using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

delegate int MyDelegate(int num);

namespace DelegateAssignment
{
    internal class Program
    {
      
        static void Main(string[] args)
        {

            Main mainInstance = new Main();
            Cube cubeInstance = new Cube();

            // Subscribe to the event
            mainInstance.OnEvent += cubeInstance.cubeCal;

            // Get input from the user
            Console.Write("Enter a number to calculate its cube: ");
            if (int.TryParse(Console.ReadLine(), out int userInput))
            {
                // Raise the event and get the result
                int cubeResult = mainInstance.raiseEvent(userInput);
                Console.WriteLine("Cube of {0} is: {1}", userInput, cubeResult);
            }
            else
            {
                Console.WriteLine("Invalid input. Please enter a valid Number.");
            }

            Console.ReadLine();

        }
    }

    class Main
    {
        public event MyDelegate OnEvent;

        public int raiseEvent(int num)
        {
           return  OnEvent?.Invoke(num) ?? 0;
        }
    }

    class Cube
    {
        public int cubeCal(int num)
        {
            int result = num*num*num;
            return result;
        }
    }
}
