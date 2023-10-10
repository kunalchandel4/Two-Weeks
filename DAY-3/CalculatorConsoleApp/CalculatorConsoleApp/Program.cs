using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalculatorConsoleApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to the Calculator App!");

            double firstNumber = GetValidDouble("Enter the first number: ");

            double secondNumber = GetValidDouble("Enter the second number: ");

            int operationChoice = GetValidOperationChoice();

            Console.Write("Enter the number of decimal places for the result: ");
            int decimalPlaces = GetValidDecimalPlaces();

            Console.WriteLine();  // Print a blank line for separation

            switch (operationChoice)
            {
                case 1:
                    PerformAddition(firstNumber, secondNumber, decimalPlaces);
                    break;
                case 2:
                    PerformSubtraction(firstNumber, secondNumber, decimalPlaces);
                    break;
                case 3:
                    PerformMultiplication(firstNumber, secondNumber, decimalPlaces);
                    break;
                case 4:
                    PerformDivision(firstNumber, secondNumber, decimalPlaces);
                    break;
                default:
                    Console.WriteLine("Invalid operation choice. Exiting.");
                    break;
            }

            Console.WriteLine("Press any key to exit.");
            Console.ReadKey();
        }


        // addperformance
        static void PerformAddition(double a, double b, int decimalPlaces)
        {
            double result = a + b;
            DisplayResult("Addition", a, b, result, decimalPlaces);
        }

        // substraction performance
        static void PerformSubtraction(double a, double b, int decimalPlaces)
        {
            double result = a - b;
            DisplayResult("Addition", a, b, result, decimalPlaces);
        }

        // multiplay performance

        static void PerformMultiplication(double a, double b, int decimalPlaces)
        {
            double result = a * b;
            DisplayResult("Addition", a, b, result, decimalPlaces);
        }


        // division performance 
        static void PerformDivision(double a, double b, int decimalPlaces)
        {
            // Check if division by zero
            if (b == 0)
            {
                Console.WriteLine("Cannot divide by zero. Exiting.");
                return;
            }

            double result = a * b;
            DisplayResult("Addition", a, b, result, decimalPlaces);
        }

        static void DisplayResult(string operation, double a, double b, double result, int decimalPlaces)
        {
            string resultString = Math.Round(result, decimalPlaces).ToString($"F{decimalPlaces}");
            Console.WriteLine($"Result of {operation} for {a} and {b} is: {resultString}");
        }


        // validation 

        static double GetValidDouble(string prompt)
        {
            double number;
            bool isValid = false;

            do
            {
                Console.Write(prompt);
                string userInput = Console.ReadLine();

                if (double.TryParse(userInput, out number))
                {
                    isValid = true;
                }
                else
                {
                    Console.WriteLine("Invalid input. Please enter a valid number.");
                }
            } while (!isValid);

            return number;
        }

        static int GetValidOperationChoice()
        {
            int choice;
            bool isValidChoice = false;

            do
            {
                Console.Write("Enter your choice (1-4): ");
                Console.WriteLine("Select an operation:");
                Console.WriteLine("1. Addition");
                Console.WriteLine("2. Subtraction");
                Console.WriteLine("3. Multiplication");
                Console.WriteLine("4. Division");
                string userInput = Console.ReadLine();

                if (int.TryParse(userInput, out choice) && choice >= 1 && choice <= 4)
                {
                    isValidChoice = true;
                }
                else
                {
                    Console.WriteLine("Invalid choice. Please enter a valid choice (1-4).");
                }
            } while (!isValidChoice);

            return choice;
        }
        static int GetValidDecimalPlaces()
        {
            int decimalPlaces;
            bool isValid = false;

            do
            {
                Console.Write("Enter the number of decimal places: ");
                string userInput = Console.ReadLine();

                if (int.TryParse(userInput, out decimalPlaces) && decimalPlaces >= 0)
                {
                    isValid = true;
                }
                else
                {
                    Console.WriteLine("Invalid input. Please enter a non-negative integer.");
                }
            } while (!isValid);

            return decimalPlaces;
        }



    }
}
