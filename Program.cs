using System;

namespace xren
{
	class MainClass
	{
		public static void n(double x1, double x2) // поиск такого значения x, когда y = 0
		{
			double e = 0.001;
			double left, right;
			double iter = e * 10;
			double x = (x2 + x1) / 2.0; // половина суммы отрезка
			for (double i = x1; i <= x2; i += iter)
			{
				if (f(i) * f(i + iter) < 0)
				{
					left = i;
					right = i + iter;

					while (Math.Abs(right - left) > e) // пока функция f(x) будет больше чем погрешность
					{
						x = (left + right) / 2.0;
						if (f(left)*f(x) > 0) // движемся влево и интервал сужается от х1 до х
							left = x;
						else         // движемся вправо и интервал сужается от х до х2
							right = x;
					}
					Console.WriteLine(x);
				}
			}

		}
		public static void Xord(double x1, double x2) // поиск такого значения x, когда y = 0
		{
			double e = 0.001;
			double left, right;
			double iter = e * 10;
			double x = (x1 * f(x2) - x2 * f(x1)) / (f(x2) - f(x1) ) ; 
			for (double i = x1; i <= x2; i += iter)
			{
				if (f(i) * f(i + iter) < 0)
				{
					left = i;
					right = i + iter;

					while (Math.Abs(right - left) > e) 
					{
						x = (left * f(right) - right * f(left)) / (f(right) - f(left));
						if (f(left) * f(x) > 0) 
							left = x;
						else         
							right = x;
					}
					Console.WriteLine(x);
				}
			}

		}
		public static void Nuton(double x1, double x2) // поиск такого значения x, когда y = 0
		{
			double e = 0.001;
			double iter = e * 10;
			for (double i = x1; i <= x2; i += iter)
			{
				if (f(i) * f(i + iter) < 0)
				{
					double nex = 0;
					double curr = i + iter;

					if (f(i) >= 0)
						curr = i;

					do
					{
						nex = curr - (f(curr) / P_(curr));
						if (Math.Abs(curr - nex) < e)
							break;
						curr = nex;
					}
					while (true);
					Console.WriteLine(curr);
				}
				
			}

		}
		public static double P_(double x) // задание самой функции 
		{
			return 2 * x;
		}

		public static double f(double x) // задание самой функции 
		{
			return Math.Pow(x,2) - 4;
		}

		static void Main(string[] args)
		{
			Console.WriteLine("Выберите каким методом решать: \n 1 - Метод биссекции \n 2 - Метод Хорд \n 3 - Метод Ньютона ");
			switch(Console.ReadLine())
			{
				case "1":
					Console.WriteLine("Метод бисекции:");
					n(-10, 10);
				break;
				case "2":
					Console.WriteLine("Метод хорд:");
					Xord(-10, 10);
				break;
				case "3":
					Console.WriteLine("Метод Ньютона:");
					Nuton(-10,10);
				break;	
				default:
					Console.ForegroundColor = ConsoleColor.Red;
					Console.WriteLine("Некоректные символы");
					Console.ReadKey();
					Environment.Exit(1);

				break;
				
			}
			
			/*
			Console.WriteLine("Метод бисекции:");
			n(-10, 10);
			Console.WriteLine("=====================================");
			Console.WriteLine("Метод хорд:");
			Xord(-10, 10);
			Console.WriteLine("=====================================");
			Console.WriteLine("Метод Ньютона:");
			Nuton(-10,10);
			*/
		}
	}
}
