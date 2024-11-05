using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace calculator1
{
    public class Calculator
    {
        public double Add(double a, double b) { return a + b; }
        public double Subtract(double a, double b) { return a - b; }
        public double Multiply(double a, double b) { return a * b; }
        public double Divide(double a, double b)
        {
            if (b == 0)
            {
                Console.WriteLine("Cannot divide by zero.");
                return 0;
            }
            return a / b;
        }
    }


    public class ScientificOperations
    {
        public double SquareRoot(double a) { return Math.Sqrt(a); }
        public double Power(double a, double b) { return Math.Pow(a, b); }
    }

    public class TrigonometricOperations
    {
        public double Sin(double angle) { return Math.Sin(angle); }
        public double Cos(double angle) { return Math.Cos(angle); }
        public double Tan(double angle) { return Math.Tan(angle); }
    }

    public class CalculatorService
    {
        private Calculator calculator = new Calculator();
        private ScientificOperations scientific = new ScientificOperations();
        private TrigonometricOperations trigonometric = new TrigonometricOperations();

        public double BasicOperation(string operation, double a, double b)
        {
            if (operation == "+" || operation == "add") return calculator.Add(a, b);
            if (operation == "-" || operation == "subtract") return calculator.Subtract(a, b);
            if (operation == "*" || operation == "multiply") return calculator.Multiply(a, b);
            if (operation == "/" || operation == "divide") return calculator.Divide(a, b);

            if (operation != "+" || operation != "-" || operation != "*" || operation != "/")
            {
                if (operation != "add" || operation != "subtract" || operation != "multiply" || operation != "divide")
                {
                    Console.WriteLine("Invalid Operation!");
                }
            }

            return 0;
        }
        public double Scientific(string operation, double a, double b = 0)
        {
            if (operation == "sqrt") return scientific.SquareRoot(a);
            if (operation == "pow") return scientific.Power(a, b);

            return 0;
        }
        public double Trigonometric(string operation, double angle)
        {
            if (operation == "sin") return trigonometric.Sin(angle);
            if (operation == "cos") return trigonometric.Cos(angle);
            if (operation == "tan") return trigonometric.Tan(angle);
            return 0;
        }
    }
    public class HandleInput
    {
        private CalculatorService service = new CalculatorService();

        public void Start()
        {
            Console.WriteLine("Simple Scientific Calculator");



            Console.Write("Enter first number: ");
            double a = double.Parse(Console.ReadLine());

            Console.Write("Enter operation (+, -, *, /, sqrt, pow, sin, cos, tan): ");
            string operation = Console.ReadLine().ToLower();

            if (operation == "sin" || operation == "cos" || operation == "tan")
            {
                double result = service.Trigonometric(operation, a);
                Console.WriteLine("Result: " + result);
            }
            else if (operation == "sqrt")
            {
                double result = service.Scientific(operation, a);
                Console.WriteLine("Result: " + result);
            }
            else if (operation == "pow")
            {
                Console.Write("Enter second number (exponent): ");
                double b = double.Parse(Console.ReadLine());
                double result = service.Scientific(operation, a, b);
                Console.WriteLine("Result: " + result);
            }
            else
            {
                Console.Write("Enter second number: ");
                double b = double.Parse(Console.ReadLine());
                double result = service.BasicOperation(operation, a, b);
                Console.WriteLine("Result: " + result);
            }

        }
    }

    class Program
    {

        static void Main(string[] args)
        {
            HandleInput ui = new HandleInput();
            ui.Start();
        }
    }
}