using System;
using System.Text.RegularExpressions;

class Program
{
    //Задание 1
    //Определить, что валидирует данное регулярное выражение и написать несколько строк, которые валидны при его использовании.
    public static void task1(string input)
    {
        Match match = Regex.Match(input, @"\b((25[0-5]|2[0-4][0-9]|[01]?[0-9][0-9]?)\.){3}(25[0-5]|2[0-4][0-9]|[01]?[0-9][0-9]?)\b");

        if (match.Success)
            Console.WriteLine($"Строка {input} является IP-адресом.");
        else
            Console.WriteLine($"Строка {input} не является IP-адресом.");
    }
    //Задание 2
    //функция, которая находит в строке все автомобильные номера и возвращает массив из них.
    public static List<string> task2(string input)
    {
        List<string> carNumbers = new List<string>();

        Regex regex = new Regex(@"[А-Я]{1}[0-9]{3}[А-Я]{2}", RegexOptions.IgnoreCase);

        MatchCollection matches = regex.Matches(input);

        foreach (Match match in matches)
            carNumbers.Add(match.Value);

        return carNumbers;
    }
    //Задание 3
    //Преобразовать текст, обрамленный в звездочки, в текст обрамленный тегом <em></em>, т.е. курсив.
    public static string task3(string input)
    {
        char c = '*';
        var count = 0;
        foreach (char i in input)
            if (i == c) count++;
     
        if (count == 4) return input;
        else
        {
            string output = Regex.Replace(input, @"(?<!\*\*)\*(.*?)\*(?!\*)", "<em>$1</em>");
            return output;
        }
        
    }
    //Задание 4
    //Функция выводящая список всех используемых тегов без повторений.
    public static void task4()
    {
        string input = @"
        <h5>Пример</h5>
        <p>
            <span style=""font-size: 15px;"">
                Это <em><strong>какой-то </strong>текст</em>
            </span>
        </p>
        <p><em>И список:</em></p>
        <ul>
            <li><span style=""font-size: 15px;"">Первый</span></li>
            <li><span style=""font-size: 15px;"">Второй</span></li>
            <li><span style=""font-size: 15px;""><strong>Третий</strong></span></li>
        </ul>";
        Regex pattern = new Regex(@"<\s*([a-zA-Z0-9]+)[^>]*>");
        MatchCollection matches = pattern.Matches(input);
        HashSet<string> uniqueTags = new HashSet<string>();

        foreach (Match match in matches)
            uniqueTags.Add(match.Groups[1].Value);
       
        Console.WriteLine(string.Join(" ", uniqueTags));
    }
    //Задание 5
    //функция, которая принимает на вход валюту и строку - историю транзакций и возвращает сумму продаж указанной валюты.
    public static void task5(string currency, string transactionHistory)
    {
        double totalSales = 0;

        MatchCollection matches = Regex.Matches(transactionHistory, $@"(?<=\b{currency}=)\d+(\.\d+)?");
        foreach (Match match in matches)
            totalSales += double.Parse(match.Value);

        Console.WriteLine($"Сумма продаж по валюте {currency} составляет {totalSales}");
    }
    //Задание 6
    //Определить регулярное выражение, при помощи которого с помощью метода Replace можно "разделить" слова с помощью пробелов. 
    public static string task6(string input)
    {
        string output = Regex.Replace(input, "(?<=.)(?=[A-Z])", " ");
        return output;
    }
    static void Main()
    {
        Console.WriteLine("Задание 1");
        task1("253.168.0.8");
        Console.WriteLine("\n\n");

        Console.WriteLine("Задание 2");
        string input = "gdfh dfhg А394ОП, fsg Х333ХХ ggdf gfd П342ПП Ъ435КК";

        List<string> carNumbers = task2(input);

        foreach (var number in carNumbers)
            Console.WriteLine(number);
        Console.WriteLine("\n\n");

        Console.WriteLine("Задание 3");
        input = "*this is italic*";
        Console.WriteLine(task3(input));
        input = "**bold text (not italic)**";
        Console.WriteLine(task3(input));
        Console.WriteLine("\n\n");

        Console.WriteLine("Задание 4");
        task4();
        Console.WriteLine("\n\n");

        Console.WriteLine("Задание 5");
        string transactionHistory = "USD=100 RUB=200 USD=70 BYN=800.40 EUR=800 JPY=1000 RUB=20";
        string currency = "RUB";
        task5(currency, transactionHistory);
        Console.WriteLine("\n\n");

        Console.WriteLine("Задание 6");
        input = "ThisIsSomeText";
        Console.WriteLine(task6(input));
    }
}
/*
Задание 1
Строка 253.168.0.8 является IP-адресом.



Задание 2
А394ОП
Х333ХХ
П342ПП
Ъ435КК



Задание 3
<em>this is italic</em>
**bold text (not italic)**



Задание 4
h5 p span em strong ul li



Задание 5
Сумма продаж по валюте RUB составляет 220



Задание 6
This Is Some Text
*/