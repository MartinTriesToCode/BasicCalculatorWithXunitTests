using System;
using System.Collections.Generic;
using System.Collections;
using System.Text;
using System.Text.RegularExpressions;
using static System.Console;

namespace BasicCalculator
{
    public class Calculator
    {
       
       public static void Main(string[] args)
        {
            bool running = true;
            bool DivideByZero = false;
            bool invalid;
            int choice;
            double[] userNumbers;
            double result = 0;
            double nr1 = 0;
            double nr2 = 0;
            string op = "";
            List<double> multipleValues = new List<double>();
            double[] multiValues = null;

            ShowInformation();

            while (running)
            {
                invalid = false;
                choice = GetUserChoice();

                if (choice > 0 && choice < 5)
                {
                    userNumbers = GetUserNumbers();
                    nr1 = userNumbers[0];
                    nr2 = userNumbers[1];
                }
                else if (choice!=0 && choice>=5 && choice<=6)
                {
                    string input = getInput();
                    string cleanInput = RemoveExtraSpaces(input);
                    cleanInput = cleanInput.Replace(".", ",");
                    multipleValues = GetMultipleValues(cleanInput);
                    multiValues = multipleValues.ToArray();
                    
                }
                switch (choice)
                {

                    case 0:   
                        running = false;
                        break;
                    case 1:   
                        result = Add(nr1, nr2);
                        op = "+";
                        break;
                    case 2:   
                        result = Subtract(nr1, nr2);
                        op = "-";
                        break;
                    case 3:   
                        result = Multiply(nr1, nr2);
                        op = "*";
                         break;
                    case 4:   
                        try { result = Divide(nr1, nr2); }
                        catch (DivideByZeroException)
                        {
                            WriteLine("\nDividend must be larger than zero.");
                            DivideByZero = true;
                        }
                        op = "/";
                        break;
                    case 5:
                        result = Add(multiValues);
                        op = "+";
                        break;
                    case 6:
                        result = Subtract(multiValues);
                        op = "-";
                        break;
                    case 7:
                        Clear();
                        ShowInformation();
                        break;
                    default:  
                        WriteLine("\nInvalid option.");
                        invalid = true;
                        break;
                }

                if (choice > 0 && choice <5 && !DivideByZero && running && !invalid)
                    WriteLine($"{nr1} {op} {nr2} = {result}");
                else if (choice >= 5 && choice <=6 && !DivideByZero && running && !invalid)
                {
                    DisplayResult(multipleValues, op, result);

                }
                else if (DivideByZero)
                {
                    
                    DivideByZero = false;
                }
                else if (invalid)
                    WriteLine("Choose option between 0 and 7.");
                else if (choice!=7)
                {
                    WriteLine("Program has ended.");
                    
                }
            }
            ReadKey();
        }

        private static string RemoveExtraSpaces(string input)
        {
           
            string temp = String.Join(" ", input.Split(new string[] { " " },
                StringSplitOptions.RemoveEmptyEntries));

            return temp;
        }

        private static void DisplayResult(List<double> multipleValues, string op, double result)
        {
            string s = string.Join(op, multipleValues);
            string sign = " ";
            string par = " ";


           
            if (op.Equals("+"))
            {
               
                par = Regex.Replace(s, @"\+-", "-");
                sign = par.Replace(op, " + ");
                sign = sign.Replace("-", " - ");
            }
            else
            {
                par = Regex.Replace(s, @"\--", "+");
                sign = par.Replace(op, " - ");
                sign = sign.Replace("+", " + ");
            }
     

            Write(sign + " = " + result +"\n\n");

        }

        private static string getInput()
        {
            bool valuesOK = false;
            string input = " ";

            WriteLine("\nDifferent values must be separated by blank space.\n");

            while (!valuesOK)
            {
                Write("Enter values: ");
                input = ReadLine();
                valuesOK = ParseInput(input);
                if (!valuesOK)
                {
                    WriteLine("\nOnly real numbers are allowed.\n");
                }
            }
            return input;
        }

        private static List<double> GetMultipleValues(string input)
        {
            bool succeed = false;
            double temp = 0;
            string[] values;
            List<double> dlist = new List<double>();

            values = input.Split(' ');
            double[] doubles = new double[input.Length];
               
            for (int i = 0; i < values.Length; i++)
            {
                succeed = double.TryParse(values[i], out temp);
                dlist.Add(temp);
            }

            return dlist;
        }

        private static bool ParseInput(string values)
        {
            bool validValues = true;
            char[] tokens = values.ToCharArray();

            for (int i = 0; i < values.Length; i++)
            {
                if (!Char.IsDigit(tokens[i]) && !tokens[i].Equals(' ')
                    && !tokens[i].Equals(',') && !tokens[i].Equals('-')
                    && !tokens[i].Equals('.'))
                {
                    validValues = false;
                       
                }

            }

            return validValues;
        }

        public static void ShowInformation()
        {
            WriteLine("Basic calculator. Available options:\n");
            WriteLine("1: Addition. 2: Subtraction.");
            WriteLine("3: Multiplication. 4: Division.");
            WriteLine("5: Add multiple values.");
            WriteLine("6: Subtract multiple values.");
            WriteLine("7: Clear history.");
            WriteLine("0: Quit.\n");
        }

        public static int GetUserChoice()
        {
            bool succeded = false;
            int choice = 0;

            while (!succeded)
            {
                Write("\nEnter option: ");
                try { choice = int.Parse(ReadLine()); }
                catch (SystemException)
                {
                    WriteLine("\nOnly real numbers are allowed..\n");
                    continue;
                }
                succeded = true;
            }

            return choice;
        }

        public static double[] GetUserNumbers()
        {
            bool NumberIsFine = false;
            double[] numbers = new double[2];
            

            while (!NumberIsFine)
            {
                Write("\nEnter number 1: ");
                NumberIsFine = double.TryParse(ReadLine(), out numbers[0]);
                if (!NumberIsFine)
                {
                    WriteLine("\nOnly real numbers are allowed.");
                }

            }

            NumberIsFine = false;

            while (!NumberIsFine)
            {
                Write("\nEnter number 2: ");
                NumberIsFine = double.TryParse(ReadLine(), out numbers[1]);
                if (!NumberIsFine)
                {
                    WriteLine("\nOnly real numbers are allowed.");
                }
            }

            return numbers;
        }

        public static double Add(double a, double b)
        {
            return a + b;
        }

        public static double Add(double[] values)
        {
            double sum = values[0];

            for (int i = 1; i < values.Length; i++)
            {
                sum += values[i];
            }

            return sum;
        }

        public static double Subtract(double a, double b)
        {
            return a - b;
        }

        public static double Subtract(double[] values)
        {
            double difference = values[0];

            for (int i = 1; i < values.Length; i++)
            {
                difference -= values[i];
            }

            return difference;
        }

        public static double Multiply(double a, double b)
        {
            return a * b;
        }

        public static double Divide(double a, double b)
        {
     
            if (b == 0)
            {
                throw new DivideByZeroException("Divide by zero error.");
            }

            return a / b;

        }
      

    }
}
