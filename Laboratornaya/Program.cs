using System;
using System.Linq;

namespace Laboratornaya
{
	class MainClass
	{
		public static void Main (string[] args)
		{
			ShowWorks ("Пузырек", (int[] array) => array.BubbleSort);
			ShowWorks ("Улучшенный пузырек", (int[] array) => array.BetterBubbleSort);
			ShowWorks ("Шейкер", (int[] array) => array.ShakerSort);
			ShowWorks ("Квиксорт", (int[] array) => array.QuickSort);
			ShowWorks ("Шелл", (int[] array) => array.ShellSort);
			ShowWorks ("Вставка", (int[] array) => array.InsertionSort);
		}
		public static void ShowWorks (string algorithmName, SortOperation.ArrayDo<int> algorithm)
		{
			Write ("Алгоритмы сортировки", ConsoleColor.Magenta);
			Write ("\n\n" + algorithmName, ConsoleColor.Green);

			int[] array = Input ("Вводите числа через пробел").Split (' ').Select ((string s) => s.ToInt ()).ToArray ();

			SortOperation operation = new SortOperation (algorithm (array));

			Write ("\n\nВремя выполнения : " + operation.Do (operation) + "\nКоличество перестановок : " + operation.swapsCount
				+ "\nКоличество сравнений : " + operation.comparesCount + '\n', ConsoleColor.Red);
			array.WriteInConsole ();
		}
		public static void Write (string text)
		{
			Write (text, ConsoleColor.Gray);
		}
		public static void Write (string text, ConsoleColor color)
		{
			Console.ForegroundColor = color;
			Console.WriteLine (text);
			Console.ForegroundColor = ConsoleColor.Gray;
		}
		public static string Input (string header)
		{
			Write (header, ConsoleColor.Yellow);
			return Console.ReadLine ();
		}
	}
}
