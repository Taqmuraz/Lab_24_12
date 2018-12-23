using System;
using System.Collections.Generic;

namespace Laboratornaya
{
	public static class Extentions
	{
		public static void WriteInConsole<T> (this IEnumerable<T> collection)
		{
			foreach (var item in collection) {
				Console.WriteLine (item.ToString());
			}
		}
		public static int ToInt (this string s)
		{
			int resoult = 0;
			int.TryParse (s, out resoult);
			return resoult;
		}
		public static void Swap<T> (this T[] array, int a, int b)
		{
			T temp = array [a];
			array [a] = array[b];
			array [b] = temp;
		}
		public static void Swap<T> (this T[] array, int a, int b, SortOperation operation)
		{
			Swap (array, a, b);
			operation.Swap ();
		}
		public static int CompareAct<T> (this T act, T other, SortOperation operation) where T : IComparable
		{
			operation.Compare ();
			return act.CompareTo (other);
		}
		public static void BubbleSort<T> (this T[] array, SortOperation operation) where T : IComparable
		{
			for (int j = 0; j < array.Length; j++) {
				for (int i = 0; i < array.Length - 1; i++) {
					if (array[i].CompareAct(array[i + 1], operation) > 0) {
						array.Swap (i, i + 1, operation);
					}
				}
			}
		}
		public static void BetterBubbleSort<T> (this T[] array, SortOperation operation) where T : IComparable
		{
			bool hasChange = true;
			while (hasChange) {
				hasChange = false;
				for (int i = 0; i < array.Length - 1; i++) {
					if (array[i].CompareAct(array[i + 1], operation) > 0) {
						array.Swap (i, i + 1, operation);
						hasChange = true;
					}
				}
			}
		}
		public static void ShakerSort<T> (this T[] array, SortOperation operation) where T : IComparable
		{
			int length = array.Length;
			int left = 1;	// левая граница
			int right = length-1;	// правая граница
			int j = right;
			int k = right;
			do {
				for (j = right; j >= left; j--)
					if (array [j - 1].CompareAct (array [j], operation) > 0) {
						array.Swap(j, j - 1, operation);
						k = j;
					}
				left = k + 1;
				for (j = left; j <= right; j++)
					if (array [j - 1].CompareAct (array [j], operation) > 0) {
						array.Swap(j, j - 1, operation);
						k = j;
					}
				right = k - 1;
			} while (left <= right);
		}
		public static void ShellSort<T> (this T[] array, SortOperation operation) where T : IComparable
		{
			int j;
			int step = array.Length / 2;
			while (step > 0)
			{
				for (int i = 0; i < (array.Length - step); i++)
				{
					j = i;
					while ((j >= 0) && (array[j].CompareAct(array[j + step], operation) > 0))
					{
						array.Swap (j, j + step, operation);
						j-=step;
					}
				}
				step = step / 2;
			}
		}
		public static void InsertionSort<T> (this T[] array, SortOperation operation) where T : IComparable
		{
			for (int i = 1; i < array.Length; i++)
			{
				T cur = array[i];
				int j = i;
				while (j > 0 && cur.CompareAct(array[j - 1], operation) < 0)
				{
					array[j] = array[j - 1];
					j--;
				}
				array[j] = cur;
				operation.Swap ();
			}
		}
		public static void QuickSort<T> (this T[] array, SortOperation operation) where T : IComparable
		{
			array.QuickSort (0, array.Length - 1, operation);
		}
		static void QuickSort<T> (this T[] array, int left, int right, SortOperation operation) where T : IComparable
		{
			int i = left;
			int j = right;
			T pivot = array[(left + right) / 2];

			while (i <= j)
			{
				while (array[i].CompareAct(pivot, operation) < 0)
				{
					i++;
				}
				while (array[j].CompareAct(pivot, operation) > 0)
				{
					j--;
				}
				if (i <= j)
				{
					array.Swap (i, j, operation);

					i++;
					j--;
				}
			}
			if (left < j)
			{
				array.QuickSort(left, j, operation);
			}
			if (i < right)
			{
				array.QuickSort(i, right, operation);
			}
		}
	}
}

