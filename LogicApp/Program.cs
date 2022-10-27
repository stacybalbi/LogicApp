using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;


namespace LogicApp
{
	class Program
	{
		static void Main(string[] args)
		{
			Console.WriteLine(" 1. Random Number \n 2. Get Bank Notes \n 3. Prime Numbers \n 4. Coincidence ");
			Console.Write("Elija la option");
			int option = int.Parse(Console.ReadLine());
			switch (option)
			{
				case 1:
					Console.WriteLine("Digite la cantidad");
					int quantity = int.Parse(Console.ReadLine());
					Console.WriteLine("Digite el valor maximo");
					int maxValue = int.Parse(Console.ReadLine());
					var numbers = RandomNumber(quantity, maxValue);
					var result = ("[{0}]", string.Join(", ", numbers));
					Console.WriteLine(result);
					Console.ReadKey();
					break;
                case 2:
					Console.WriteLine("Digite una cantidad");
					int quantityBank= int.Parse(Console.ReadLine());
					getBanknotes(quantityBank);
					Console.ReadKey();
					break;

				case 3:
					Console.WriteLine("Digite una cantidad");
					int quantityPrime = int.Parse(Console.ReadLine());
					if (quantityPrime >= 9) { isPrime(quantityPrime); }
					else { Console.WriteLine("Número no valido");
						Console.ReadKey();
						Main(args); }
					break;
				case 4:
					Coincidence();
					break;

			}
        }


		private static bool isPrime(int number)
		{
			for (int i = 2; i < number; i++)
			{
				if (number % i == 0) return false;
			}
			return true;
		}

		private static int[] fibonnacciSequence(int n)
		{
			int[] fib = new int[n];
			fib[0] = 0;
			fib[1] = 1;
			for (int i = 2; i < n; i++)
			{
				fib[i] = fib[i - 1] + fib[i - 2];
			}
			return fib;
		}

		public static int[] RandomNumber(int quantity = 5, int maxValue = 100)
		{
			if (quantity == 0) quantity = 5;
			var numbers = new List<int>();
			for (int i = 0; i < quantity; i++)
			{
				var number = new Random().Next(1, maxValue);
				if (numbers.Contains(number)) i--;
				else numbers.Add(number);
				if (numbers.Count == 20) break;
			}
			return numbers.ToArray();
		}

		public static int[] getBanknotes(int quantity)
		{
			int[] banknotes = { 2000, 1000, 500, 200, 100, 50, 25, 10, 5, 1 };
			int[] banknotesFound = new int[banknotes.Length];
			for (int i = 0; i < banknotes.Length; i++)
			{
				banknotesFound[i] = quantity / banknotes[i];
				quantity = quantity % banknotes[i];
			}
			return banknotesFound;
		}

		public static int[] primeNumbers(int quantity = 9)
		{
			int[] primeNumbers = new int[quantity];
			int i = 1;
			int j = 0;
			while (j < quantity)
			{
				if (isPrime(i))
				{
					primeNumbers[j] = i;
					j++;
				}
				i++;
			}
			return primeNumbers;
		}

		public static int[] Coincidence()
		{
			List<int> primesNumbers = new List<int>();
			Array.ForEach(RandomNumber(499, 500), element =>
			{
				if (isPrime(element)) primesNumbers.Add(element);
			});
			int mayorValue = primesNumbers.Max();
			int[] serie = fibonnacciSequence(mayorValue);
			return serie;
		}

	}

}

