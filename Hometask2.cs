using System;
using System.ComponentModel.DataAnnotations;
using System.Runtime.InteropServices;
namespace ConsoleApp1
{

    class Program
    {
        public static void Print (int[] a)
        {
            foreach (var x in a)
                Console.Write($"{x} ");
        }
        public static void PrintMatr(int[,] a)
        {
            for (int i = 0; i < a.GetLength(0); i++)
            {
                for (int j = 0; j < a.GetLength(1); j++)
                    Console.Write(a[i, j] + " ");
                Console.WriteLine();
            }
                
        }
        //Задание 1
        //функция, которая принимает на вход одно целое число и возвращает массив цифр данного числа. 
        public static int[] NumbersToArray(int n)
        {
            var count = 0;
            var stop = Math.Abs(n);
            n = Math.Abs(n);
            if (n != 0)
            {
                while (n > 0)
                {
                    n = n / 10;
                    count++;
                }
                int[] arr = new int[count];
                while (stop > 0)
                {
                    arr[--count] = stop % 10;
                    stop /= 10;
                }
                return arr;
            }
            else {int[] arr = { 0 }; return arr;};

        }
        //Задание 2
        //Создать новый массив, в котором удалены все элементы, не удовлетворяющие предикату.
        public static int[] ForAll(int[] arr, Func<int, bool> f)
        {
            
            var count = 0;
            foreach (int num in arr) 
                if (f(num)) count++;

            int[] newArr = new int[count];
            int index = 0;
            foreach (int num in arr)
                if (f(num))
                {
                    newArr[index] = num;
                    index++;
                }
            return newArr;
        }
        //Задание 3
        //Дан массив целых чисел с чётным количеством элементов. Поменять местами его первую и вторую половины.
        public static int[] task3(int[] arr)
        {
            int[] arr1 = new int[arr.Length / 2];
            int[] arr2 = new int[arr.Length / 2];
            if (arr.Length % 2 == 0)
            {
                arr1 = arr[0..(arr.Length / 2)];
                arr2 = arr[(arr.Length / 2)..arr.Length];
                arr = new int[arr.Length];
                arr = arr2.Concat(arr1).ToArray();
            }
            else throw new ArgumentException("Количество элементов в массиве должно быть четным");
            return arr;
        }
        //Задание 4
        //Написать метод, выводящий её элементы в следующем порядке: первая строка слева направо, вторая строка справа налево
        public static void task4(int[,] matr)
        {
            for (int i = 0; i <  matr.GetLength(1); i++)
            {
                for (int j = matr.GetLength(0)-1; j >= 0;  j--)
                {
                    if (i % 2 != 0)
                    {
                        Console.Write($"{matr[i, j]} ");
                    }
                    else
                    {
                        Console.Write($"{matr[i, matr.GetLength(1) - j - 1]} ");
                    }
                }
                Console.WriteLine();
                    
            }
        }
        //Задание 5
        //Определить метод, находящий номер ее строки с наибольшей суммой элементов, а также значение наибольшей суммы.
        
        public static void task5(int[,] matr, out int number, out int ressum)
        {
            ressum = int.MinValue;
            number = 0;
            for (int i = 0; i < matr.GetLength(0); i++)
            {
                int sum = 0;
                for (int j = 0; j < matr.GetLength(1); j++)
                    sum += matr[i, j];
                if (sum >= ressum)
                {
                    ressum = sum;
                    number = i + 1;
                }
            }
                
        }
        //Задание 6
        //Найти максимальное значение среди всех средних значений строк массива.
        public static double task6(int[][] arr)
        {
            double max = double.MinValue;
            for (int i = 0; i < arr.Length; i++)
            {
                double sum = 0.0;
                for (int j = 0; j < arr[i].Length; j++)
                {
                    sum += arr[i][j];
                }
                double rowAvg = (double)(sum / arr[i].Length);
                max = rowAvg > max ? rowAvg : max;
            }
            return max;
        }
        static void Main(string[] args)
        {
            Console.WriteLine("Задание 1");
            Console.WriteLine("Начальное число: -2324");
            Print(NumbersToArray(-2324));
            Console.WriteLine();
            Console.WriteLine("Начальное число: 1734");
            Print(NumbersToArray(1734));
            Console.WriteLine();
            Console.WriteLine("Начальное число: 0");
            Print(NumbersToArray(0));
            Console.WriteLine("\n\n");
            Console.WriteLine("Задание 2");
            int[] arr = {1, 2, 3, 4, 5, 6, 7, 8, 9, 10};
            Console.WriteLine($"Начальный массив: ");
            Print(arr);
            Console.WriteLine();
            Console.WriteLine("Предикат: x => x % 2 == 0");
            Print(ForAll(arr, x => x % 2 == 0));
            Console.WriteLine();
            Console.WriteLine("Предикат: x => x % 3 == 0");
            Print(ForAll(arr, x => x % 3 == 0));
            Console.WriteLine();
            Console.WriteLine("Предикат: x => x % 11 == 0");
            Print(ForAll(arr, x => x % 11 == 0));
            Console.WriteLine("\n\n");
            Console.WriteLine("Задание 3");
            Console.WriteLine($"Начальный массив: ");
            Print(arr);
            Console.WriteLine();
            Console.WriteLine($"Подученный массив: ");
            Print(task3(arr));
            Console.WriteLine("\n\n");
            Console.WriteLine("Задание 4");
            int[,] matr = {{1, 2, 3}, {4, 5, 6}, {7, 8, 9}};
            PrintMatr(matr);
            Console.WriteLine();
            task4(matr);
            Console.WriteLine("\n\n");
            Console.WriteLine("Задание 5");
            PrintMatr(matr);
            task5(matr, out var number, out var ressum);
            Console.WriteLine($"Номер: {number} Сумма: {ressum}");
            Console.WriteLine("\n\n");
            int[][] arrs = new int[][] { new int[] { 2, 3 }, new int[] { 2, 3, 4, }, new int[] { 2, 3, 4, 5, } };
            Console.WriteLine("Задание 6");
            Console.WriteLine(task6(arrs));
        }
    }
}
/*
Задание 1
Начальное число: -2324
2 3 2 4
Начальное число: 1734
1 7 3 4
Начальное число: 0
0


Задание 2
Начальный массив:
1 2 3 4 5 6 7 8 9 10
Предикат: x => x % 2 == 0
2 4 6 8 10
Предикат: x => x % 3 == 0
3 6 9
Предикат: x => x % 11 == 0



Задание 3
Начальный массив:
1 2 3 4 5 6 7 8 9 10
Подученный массив:
6 7 8 9 10 1 2 3 4 5


Задание 4
1 2 3
4 5 6
7 8 9

1 2 3
6 5 4
7 8 9



Задание 5
1 2 3
4 5 6
7 8 9
Номер: 3 Сумма: 24



Задание 6
3,5
*/