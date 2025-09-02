using System;

class Program
{
    static void Main()
    {
        Console.WriteLine("=== Simple Calculator ===");

        Console.Write("Enter first number: ");
        double num1 = double.Parse(Console.ReadLine());

        Console.Write("Enter operator (+ - * /): ");
        char op = Console.ReadLine()[0];

        Console.Write("Enter second number: ");
        double num2 = double.Parse(Console.ReadLine());

        double result = 0;

        switch (op)
        {
            case '+': result = num1 + num2; break;
            case '-': result = num1 - num2; break;
            case '*': result = num1 * num2; break;
            case '/': 
                if (num2 != 0) result = num1 / num2;
                else Console.WriteLine("Error: Cannot divide by zero!");
                break;
            default: Console.WriteLine("Invalid operator"); break;
        }

        Console.WriteLine($"Result = {result}");
    }
}
