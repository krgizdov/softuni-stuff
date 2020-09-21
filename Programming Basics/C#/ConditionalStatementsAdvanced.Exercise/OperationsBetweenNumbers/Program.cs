using System;

namespace OperationsBetweenNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            int num1 = int.Parse(Console.ReadLine());
            int num2 = int.Parse(Console.ReadLine());
            string operand = Console.ReadLine();

            double operationResult = 0;
            string result = string.Empty;

            if (operand == "+" || operand == "-" || operand == "*")
            {
                switch (operand)
                {
                    case "+": operationResult = num1 + num2; break;
                    case "-": operationResult = num1 - num2; break;
                    case "*": operationResult = num1 * num2; break;
                }

                string evenOdd = operationResult % 2 == 0 ? "even" : "odd";

                result = $"{operationResult} - {evenOdd}";
            }
            else if (operand == "/" || operand == "%")
            {
                if (num2 == 0)
                {
                    Console.WriteLine($"Cannot divide {num1} by zero");
                    return;
                }

                switch (operand)
                {
                    case "/": operationResult = (double)num1 / num2; break;
                    case "%": operationResult = num1 % num2; break;
                }

                result = operand == "/" ? $"{operationResult:f2}" : $"{operationResult}";
            }

            Console.WriteLine($"{num1} {operand} {num2} = {result}");
        }
    }
}
