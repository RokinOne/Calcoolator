using System;
using System.Collections.Generic;

public class Calcool
{
        public static void PrintListInt (List <double> listForPrint) {
                Console.Write("\nLIST:");
                foreach (double element in listForPrint) { Console.Write(" "  + element); }
        }
        public static void PrintListStr (List <string> listForPrint) {
                Console.Write("\nLIST:");
                foreach (string element in listForPrint) { Console.Write(" " + element); }
        }
        public static void PrintCurrentExpression (List <double> numbers, List <string> operators) {
                Console.Write("\n");
                        Console.Write(numbers[0]);
                for (int  i = 1; i < numbers.Count; i++) {
                        Console.Write(operators[i]);
                        Console.Write(numbers[i]);
                }
        }

	public static double Add (double a, double b)
	{
		return a + b;
	}

	public static double Subtract (double a, double b)
	{
		return a - b;
	}

	public static double Multiply (double a, double b)
	{
		return a * b;
	}

	public static double Divide (double a, double b)
	{
		return a / b;
	}

	public static void InputNumbers (int operation)
	{
		char operatorSymbol = '?';
		double result = 0;
		Console.WriteLine ("\nEnter first number: ");
		string ae = Console.ReadLine ();
		Console.WriteLine ("\nEnter second number: ");
		string be = Console.ReadLine ();
		double a = Convert.ToDouble (ae);
	        double b = Convert.ToDouble (be);
		switch (operation) {
		case '1':
			operatorSymbol = '+';
			result = Add (a, b);
			break;
		case '2':
			operatorSymbol = '-';
			result = Subtract (a, b);
			break;
		case '3':
			operatorSymbol = '*';
			result = Multiply (a, b);
			break;
		case '4':
			operatorSymbol = '/';
			result = Divide (a, b);
			break;
		default:
			Console.WriteLine ("Invalid input");
			break;
		}
		Console.WriteLine ("\n" + ae + " " + operatorSymbol + " " + be + " = " + result + "\n\n");
	}

	public static void inputExpression ()
	{
		string expression;
		Console.WriteLine ("\nInput expression, end with '=':\n");
		expression = Console.ReadLine ();

                // numbers
		string[] numberString = expression.Split('+','-','*','/');
                List <double> numberList = new List<double> ();
		foreach (string no in numberString) {
			Console.Write (no + " ");
                        numberList.Add(Convert.ToDouble(no));
		}

                // operators
		string[] operators = expression.Split ('0', '1', '2', '3', '4', '5', '6', '7', '8', '9');
                List <string> operatorList = new List <string> (operators);

                Console.Write ("\nNCOUNT: " + numberList.Count);
                Console.Write ("\nOCOUNT: " + (operatorList.Count -2)); // ima prazno na pocetku i kraju, zasto?
                PrintListInt(numberList);
                PrintListStr(operatorList);
                PrintCurrentExpression(numberList, operatorList);
		Console.WriteLine ("\n");

                for (int i = 0; i < (operatorList.Count-1); i++) {
                        if (operatorList[i] == "*") {
                                numberList[i-1] = Multiply (numberList[i-1], numberList[i]);
                                numberList.RemoveAt(i);
                                operatorList.RemoveAt(i);
                                i--;
                                PrintCurrentExpression(numberList, operatorList);
                        }
                }

                for (int i = 0; i < (operatorList.Count-1); i++) {
                        if (operatorList[i] == "/") {
                                numberList[i-1] = Divide (numberList[i-1], numberList[i]);
                                numberList.RemoveAt(i);
                                operatorList.RemoveAt(i);
                                i--;
                                PrintCurrentExpression(numberList, operatorList);
                        }
                }

                for (int i = 0; i < (operatorList.Count-1); i++) {
                        if (operatorList[i] == "-") {
                                numberList[i-1] = Subtract (numberList[i-1], numberList[i]);
                                numberList.RemoveAt(i);
                                operatorList.RemoveAt(i);
                                i--;
                                PrintCurrentExpression(numberList, operatorList);
                        }
                }

                for (int i = 0; i < (operatorList.Count-1); i++) {
                        if (operatorList[i] == "+") {
                                numberList[i-1] = Add (numberList[i-1], numberList[i]);
                                numberList.RemoveAt(i);
                                operatorList.RemoveAt(i);
                                i--;
                                PrintCurrentExpression(numberList, operatorList);
                        }
                }

                Console.Write("\n\nNOLIST:");
                foreach(int number in numberList) {
                        Console.Write (number + " ");
                }
	}

	public static char MainMenu ()
	{
		string input;
		Console.WriteLine ("\nCalcoolator\n\nSelect:");
		Console.WriteLine ("1 +");
		Console.WriteLine ("2 -");
		Console.WriteLine ("3 *");
		Console.WriteLine ("4 /");
		Console.WriteLine ("5 expression");
		Console.WriteLine ("0 exit");
		input = Console.ReadLine ();
		return Convert.ToChar (input);
	}

	public static void Main (string[] args)
	{
		bool open = true;
		while (open) {
			char choice = MainMenu ();
			choice = Convert.ToChar (choice);
			if (choice == '0') {
				Console.WriteLine ("exiting...");
				open = false;
			} else if (choice == '5') {
				inputExpression ();
			} else {
				InputNumbers (choice);
			}
		}
	}
}
