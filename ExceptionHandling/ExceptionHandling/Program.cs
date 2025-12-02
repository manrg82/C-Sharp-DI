using ExceptionHandling;
using System;

class Program
{
    static void Main(string[] args)
    {
        int[] numbers = { 10, 20, 30, 40, 50 };

        try
        {
            Console.WriteLine("Enter the first number for division:");
            int num1 = int.Parse(Console.ReadLine());

            Console.WriteLine("Enter the second number (divisor):");
            int num2 = int.Parse(Console.ReadLine());

            if (num1 < 0 || num2 < 0)
            {
                throw new NegativeNumberException("Numbers cannot be negative.");
            }

            int result = num1 / num2;
            Console.WriteLine("Division Result: " + result);

            Console.WriteLine("Enter an index to access the array:");
            int index = int.Parse(Console.ReadLine());

            Console.WriteLine("Value at index: " + numbers[index]);
        }
        catch (DivideByZeroException)
        {
            Console.WriteLine("Error: cannot divide by zero.");
        }
        catch (IndexOutOfRangeException)
        {
            Console.WriteLine("Error: Index is out of bounds.");
        }
        catch (NegativeNumberException ex)
        {
            Console.WriteLine("Custom Error: " + ex.Message);
        }
        catch (FormatException)
        {
            Console.WriteLine("Please enter valid integer numbers.");
        }
        finally
        {
            Console.WriteLine("Program execution finished.");
        }
    }
}