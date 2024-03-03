using System;
using System.Text.RegularExpressions;
//using System.Linq;

class MainClass
{
    
    public static void printArr (string[] a)
    {
        foreach (var x in a)
            Console.Write($"{x} ");
    }
    //Задание 1
    //Функция возвращающая новый массив строк, в котором каждая из строк исходного массива дополнена пробелами до длины самой длинной строки массива. 
    public static string[] task1(string[] input)
    {
        if (input.Length % 2 == 0)
            throw new ArgumentException("Длина массива должна быть нечётной");

        int maxLength = 0;
        foreach (string str in input)
            if (str.Length > maxLength)
                maxLength = str.Length;

        string[] output = new string[input.Length];
        for (int i = 0; i < input.Length; i++)
        {
            int st = (maxLength - input[i].Length) / 2;
            string s = new string(' ', st);
            output[i] = s + input[i] + s;
        }

        return output;
    }
    //Задание 2
    //Заменяет все запрещённые слова в тексте звёздочками
    static string task2(string[] forbiddenWords, string text)
    {
        foreach (string word in forbiddenWords)
        {
            string replace = new string('*', word.Length);
            text = Regex.Replace(text, "\\b" + word + "\\b", replace, RegexOptions.IgnoreCase);
        }
        return text;
    }
    //Задание 3
    //Функция должна возвращает массив, состоящий из самых длинных слов в каждой строке, отсортированный по возрастанию их длин.
    static string[] task3(string[] input)
    {
        string[] longestWords = new string[input.Length];

        for (int i = 0; i < input.Length; i++)
        {
            string[] words = input[i].Split(new char[] { ' ', '.', ',', '!', '?' }, StringSplitOptions.RemoveEmptyEntries);
            string longestWord = words.OrderByDescending(w => w.Length).FirstOrDefault();
            longestWords[i] = longestWord;
        }

        Array.Sort(longestWords, (x, y) => x.Length.CompareTo(y.Length));

        return longestWords;
    }
    //Задание 4
    //Реализовать функцию, получающую на вход строку. Функция должна возвращать массив слов, приведённых к нижнему регистру. 
    static string[] task4(string input)
    {
        string[] words = input.Split(new char[] { '.', ',', ':', ';', '-', '!', '?',' ', '\n' }, StringSplitOptions.RemoveEmptyEntries);

        for (int i = 0; i < words.Length; i++)
            words[i] = words[i].ToLower();       
        return words;
    }
    //Задание 5
    //Написать функцию, принимающую на вход строку, состоящую из слов. Функция должна определять количество входящих в заданную строку почтовых индексов.
    static bool IsPostalCode(string word)
    {
        if (word.Length != 6) return false;

        foreach (char c in word)
            if (!char.IsDigit(c)) return false;

        return true;
    }
    static int task5(string input)
    {
        int count = 0;
        for (int i = 0; i < input.Length - 5; i++)
            if (IsPostalCode(input.Substring(i, 6))) count++;
            
        return count;
    }
    //Задание 6
    //Определите новую функцию, решающую предыдущую задачу с помощью регулярных выражений.
    static int task6(string input)
    {
        Regex regex = new Regex(@"\b\d{6}\b");
        MatchCollection matches = regex.Matches(input);
        return matches.Count;
    }

    public static void Main(string[] args)
    {
        Console.WriteLine("Задание 1");
        string[] input = { "abc", "abcde", "a", "abcdefg", "abcdefghi" };
        string[] output = task1(input);
        foreach (string str in output)
            Console.WriteLine(str);
        Console.WriteLine("\n\n");
        string[] input2 = { "dsdddd", "d", "rr"};
        output = task1(input2);
        foreach (string str in output)
            Console.WriteLine(str);
        Console.WriteLine("\n\n");

        Console.WriteLine("Задание 2");
        string[] forbiddenWords = { "дурак", "гадкий", "пр" };
        string text = "привет дурак коплват дурака гадкий пр";
        Console.WriteLine(task2(forbiddenWords, text));
        Console.WriteLine("\n\n");

        Console.WriteLine("Задание 3");
        string[] input3 = { "ggggg, dfd. rrr !wwwwwwww", "sffs f ?dsa .trtttt", "dfkdlfh!  ,fddf", "f!" };
        output = task3(input3);
        foreach (string word in output)
            Console.WriteLine(word);
        Console.WriteLine("\n\n");

        Console.WriteLine("Задание 4");
        string input4 = " Реализовать функцию, получающую на вход строку, представляющую\n собой текст со - всеми: присущими ему; знаками препинания!";
        output = task4(input4);
        foreach (string word in output)
            Console.WriteLine(word);
        Console.WriteLine("\n\n");

        Console.WriteLine("Задание 5");
        string input5 = "gdrgdkl 123456 kldfg 321432 fkg 3232, 932012";
        Console.WriteLine("Количество почтовых индексов: " + task5(input5));
        Console.WriteLine("\n\n");

        Console.WriteLine("Задание 6");
        string input6 = "gdrgdkl 123456 kldfg 321432 fkg 3232, 932012";
        Console.WriteLine("Количество почтовых индексов: " + task6(input6));
    }


}
/*
log1
Задание 1
   abc
  abcde
    a
 abcdefg
abcdefghi



dsdddd
  d
  rr



Задание 2
привет ***** коплват дурака ****** **



Задание 3
f
trtttt
dfkdlfh
wwwwwwww



Задание 4
реализовать
функцию
получающую
на
вход
строку
представляющую
собой
текст
со
всеми
присущими
ему
знаками
препинания



Задание 5
Количество почтовых индексов: 3



Задание 6
Количество почтовых индексов: 3
*/