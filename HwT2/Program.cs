using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HwT2
{
    //Евдохин Денис
    //2. а) С клавиатуры вводятся числа, пока не будет введен 0 (каждое число в новой строке).
    //Требуется подсчитать сумму всех нечетных положительных чисел.Сами числа и сумму
    //вывести на экран; Используя tryParse;
    //б) Добавить обработку исключительных ситуаций на то, что могут быть введены некорректные
    //данные.При возникновении ошибки вывести сообщение.
    //Напишите соответствующую функцию

    class Program
    {
        static void Main(string[] args)
        {
            PartA();
            Console.ReadLine();
            Console.Clear();
            PartB();
            Console.ReadLine();
        }

        static void PartA()
        {
            List<int> list = new List<int>();
            int numb = 0;
            string str;
            do
            {
                Console.Clear();
                Console.WriteLine("Введи число, 0 - окончание ввода");
                str = Console.ReadLine();
                if (int.TryParse(str, out numb))
                {
                    if (numb > 0 && (numb % 2) == 1) list.Add(numb);
                }
                else
                {
                    numb = 1;
                }
            } while (numb != 0);
            Console.Clear();
            foreach (var i in list)
            {
                Console.WriteLine(i);
            }
            Console.WriteLine($"Сумма = {list.Sum()}");
        }
        static void PartB()
        {
            List<int> list = new List<int>();
            int numb = 0;
            string str;
            do
            {
                Console.Clear();
                Console.WriteLine("Введи число, 0 - окончание ввода");
                str = Console.ReadLine();
                try
                {
                    numb = int.Parse(str);
                    if (numb > 0 && (numb % 2) == 1) list.Add(numb);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    Console.WriteLine("\nТеперь по русски:\nВведены некорректыные данные, вводите числа!\nEnter для продолжения");
                    Console.ReadLine();
                }
            } while (numb != 0);
            Console.Clear();
            foreach (var i in list)
            {
                Console.WriteLine(i);
            }
            Console.WriteLine($"Сумма = {list.Sum()}");
        }

    }
}
