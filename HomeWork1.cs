using System;

namespace ConsoleApp5

{

    class Program

    {
        //Задание 1
        //Дано трехзначное число. Обнулить в нем разряд десятков.
        public static int ZeroingOut(int a)
        {
            var b = a % 100;
            var c = b / 10 * 0;
            var d = a / 100 * 100;
            var e = b % 10;
            return d + c + e;
        }
        //Задание 2
        // Даны координаты поля шахматной доски x,y какой цвет имеет поле с данными координатами.
        public static void Color(int x, int y)
        {
            if ((x < 1 || x > 8) || (y < 1 || y > 8))
                throw new ArgumentException(" числа должны лежать в диапазоне 1–8");
            if ((x + y) % 2 == 0)
                Console.WriteLine("Black");
            else Console.WriteLine("White");
        }
        //Задание 3
        //Вернуть количество вещественных корней квадратного уравнения
        public static int RootsOfEquation(int a, int b,int c)
        {
            if (a == 0)
                throw new ArgumentException(" число А != 0");
            var d = b * b - 4 * a * c;
            if (d > 0)
                return 2;
            if (d == 0)
                return 1;
            else return 0;
        }
        //Задание 4
        // Создать функцию, которая возвращает минимум из двух переданных вещественных чисел.
        public static double Min(double x, double y) => x < y ? x : y;
        //Задание 5
        //Найти произведение всех чётных целых чисел от A до B включительно.
        public static double Prod(int a, int b)
        {
            var res = 1.0;
            for (int i = a;  i <= b; i++)
            {
                if (i % 2 == 0)
                    res *= i;
            }
            return res; 
        }
        //Задание 6
        //Вычислить количество чисел в наборе, меньших K, а также количество чисел, делящихся на K нацело.
        public static void CountNumbers()
        {
            Console.WriteLine("K:");
            double k = Convert.ToDouble(Console.ReadLine());
            var smalerK = 0;
            var modK = 0;
            Console.WriteLine("набор ненулевых целых чисел:");
            while (true)
            {
                double x = Convert.ToDouble(Console.ReadLine());
                if (x == 0)
                    break;
                if (x < k)
                    smalerK += 1;
                if (x % k == 0)
                    modK += 1;
            }
            Console.WriteLine($"количество чисел в наборе, меньших K: {smalerK}");
            Console.WriteLine($"количество чисел, делящихся на K нацело: {modK}");
        }
        //Задание 7
        // возвращает время года
        public static void ChooseSeason()
        {
            Console.WriteLine("Введите номер месяца:");
            int seasons = int.Parse(Console.ReadLine());

            if ((seasons > 12) || (seasons < 1))
                throw new ArgumentException("Нет такого месяца");

            switch (seasons)
            {
                case 12 or 1 or 2:
                    Console.WriteLine("Зима");
                    break;
                case 3 or 4 or 5:
                    Console.WriteLine("Весна"); 
                    break;
                case 6 or 7 or 8:
                    Console.WriteLine("Лето");
                    break;
                default:
                    Console.WriteLine("Осень");
                    break;
            }
        }
        //Задание 8
        //выводит на консоль N строк
        public static void GenerateSeasons()
        {
            Console.WriteLine("Введите количество строк:");
            int n = int.Parse(Console.ReadLine());
            Random r = new Random();
            var i = r.Next(1, 12);
            if (i == 1)
                for (int j = 1;  j <= n; j++) Console.WriteLine($"Месяц январь, его сезон: зима");               
            if (i == 2)
                for (int j = 1; j <= n; j++) Console.WriteLine($"Месяц февраль, его сезон: зима");
            if (i == 3)
                for (int j = 1; j <= n; j++) Console.WriteLine($"Месяц март, его сезон: весна");
            if (i == 4)
                for (int j = 1; j <= n; j++) Console.WriteLine($"Месяц апрель, его сезон: весна");
            if (i == 5)
                for (int j = 1; j <= n; j++) Console.WriteLine($"Месяц май, его сезон: весна");
            if (i == 6)
                for (int j = 1; j <= n; j++) Console.WriteLine($"Месяц июнь, его сезон: лето");
            if (i == 7)
                for (int j = 1; j <= n; j++) Console.WriteLine($"Месяц июль, его сезон: лето");
            if (i == 8)
                for (int j = 1; j <= n; j++) Console.WriteLine($"Месяц август, его сезон: лето");
            if (i == 9)
                for (int j = 1; j <= n; j++) Console.WriteLine($"Месяц сентябрь, его сезон: осень");
            if (i == 10)
                for (int j = 1; j <= n; j++) Console.WriteLine($"Месяц октябрь, его сезон: осень");
            if (i == 11)
                for (int j = 1; j <= n; j++) Console.WriteLine($"Месяц ноябрь, его сезон: осень");
            if (i == 12)
                for (int j = 1; j <= n; j++) Console.WriteLine($"Месяц декабрь, его сезон: зима");
        }
        static void Main()

        {
            Console.WriteLine("Задание 1");
            Console.WriteLine(ZeroingOut(394));
            Console.WriteLine(ZeroingOut(692));
            Console.WriteLine(ZeroingOut(291));

            Console.WriteLine("Задание 2");
            Color(3, 5);
            Color(1, 1);
            Color(7, 2);

            Console.WriteLine("Задание 3");
            Console.WriteLine(RootsOfEquation(1, -4, -21));
            Console.WriteLine(RootsOfEquation(1, -4, 4));
            Console.WriteLine(RootsOfEquation(1, 2, 5));

            Console.WriteLine("Задание 4");
            Console.WriteLine(Min(4.7, 9.25));
            Console.WriteLine(Min(8.41, 2.5));
            Console.WriteLine(Min(6.27, 6.37));

            Console.WriteLine("Задание 5");
            Console.WriteLine(Prod(4, 9));
            Console.WriteLine(Prod(1, 7));
            Console.WriteLine(Prod(2, 12));

            Console.WriteLine("Задание 6");
            CountNumbers();

            Console.WriteLine("Задание 7");
            ChooseSeason();

            Console.WriteLine("Задание 8");
            GenerateSeasons();
        }

    }

}
/*log1
Задание 1
304
602
201
Задание 2
Black
Black
White
Задание 3
2
1
0
Задание 4
4,7
2,5
6,27
Задание 5
192
48
46080
Задание 6
K:
5
набор ненулевых целых чисел:
9
- 5
10
15
- 20
0
количество чисел в наборе, меньших K: 2
количество чисел, делящихся на K нацело: 4
Задание 7
Введите номер месяца:
8
Лето
Задание 8
Введите количество строк:
6
Месяц июль, его сезон: лето
Месяц июль, его сезон: лето
Месяц июль, его сезон: лето
Месяц июль, его сезон: лето
Месяц июль, его сезон: лето
Месяц июль, его сезон: лето
*/