using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HwT3
{
    //Евдохин Денис
    //3. *Описать класс дробей - рациональных чисел, являющихся отношением двух целых чисел.
    //Предусмотреть методы сложения, вычитания, умножения и деления дробей.Написать
    //программу, демонстрирующую все разработанные элементы класса.
    class Program
    {
        static void Main(string[] args)
        {
            #region Инициализация дробей для демонстрации возможностей
            Drob drobRes = new Drob();

            Drob drob1 = new Drob(int.Parse(Console.ReadLine()), int.Parse(Console.ReadLine()));
            Console.WriteLine($"\nПервая дробь: {drob1.delimoe} / {drob1.delitel}\n");

            Drob drob2 = new Drob(int.Parse(Console.ReadLine()), int.Parse(Console.ReadLine()));
            Console.WriteLine($"\nВторая дробь: {drob2.delimoe} / {drob2.delitel}\n");
            #endregion

            #region Демонстрация возможностей класса

            drobRes = drob1.Plus(drob2);
            Console.WriteLine($"\n1я дробь + 2я = {drobRes.delimoe} / {drobRes.delitel}\n");

            drobRes = drob1.PlusUpr(drob2);
            Console.WriteLine($"\nУрощенная (1я дробь + 2я) = {drobRes.delimoe} / {drobRes.delitel}\n");

            drobRes = drob1.Minus(drob2);
            Console.WriteLine($"\n1я дробь - 2я = {drobRes.delimoe} / {drobRes.delitel}\n");

            drobRes = drob1.MinusUpr(drob2);
            Console.WriteLine($"\nУрощенная (1я дробь - 2я) = {drobRes.delimoe} / {drobRes.delitel}\n");

            drobRes = drob1.Umnog(drob2);
            Console.WriteLine($"\n1я дробь * 2я = {drobRes.delimoe} / {drobRes.delitel}\n");

            drobRes = drob1.UmnogUpr(drob2);
            Console.WriteLine($"\nУрощенная (1я дробь * 2я) = {drobRes.delimoe} / {drobRes.delitel}\n");

            drobRes = drob1.Deli(drob2);
            Console.WriteLine($"\n1я дробь / 2я = {drobRes.delimoe} / {drobRes.delitel}\n");

            drobRes = drob1.DeliUpr(drob2);
            Console.WriteLine($"\nУрощенная (1я дробь / 2я) = {drobRes.delimoe} / {drobRes.delitel}\n");

            drob1.Upr();
            Console.WriteLine($"\nУпрощенная 1я дробь: {drob1.delimoe} / {drob1.delitel}\n");
            Console.WriteLine($"Общий множитель упрощенной 1й дроби = {drob1.obmnog}");

            drobRes = drob1.StepN();
            Console.WriteLine($"1я дробь в квадрате = {drobRes.delimoe} / {drobRes.delitel}\n");

            Console.WriteLine($"Частное дроби (Double) = {drobRes.Result()}\n");

            #endregion

            Console.ReadLine();
        }
    }

    /// <summary>
    /// Представляет обычную дробь, состоящую из делимого и делителя.
    /// Также может возвращать результат вычисления дроби.
    /// </summary>
    public class Drob
    {
        public int delimoe;
        public int delitel;
        public int obmnog = 1; //общий множитель, исчисляется при упрощении дроби, может быть использован для ее восстановления после упрощения

        #region Конструкторы
        /// <summary>
        /// Создает объект с делимым 1 и частным 1
        /// </summary>
        public Drob()
        {
            delimoe = 1;
            delitel = 1;
        }

        /// <summary>
        /// Создает объект с присвоением параметров другого экземпляра
        /// </summary>
        /// <param name="Дробь"></param>
        public Drob(Drob drob)
        {
            delimoe = drob.delimoe;
            delitel = drob.delitel;
        }

        /// <summary>
        /// Создает объект с указанием делимого и делителя
        /// </summary>
        /// <param name="delimoe">Делимое</param>
        /// <param name="delitel">Делитель</param>
        public Drob(int delimoe, int delitel)
        {
            this.delimoe = delimoe;
            this.delitel = delitel;
        }
        
        /// <summary>
        /// Создает дробь вида 1/х
        /// </summary>
        /// <param name="delitel">Делитель</param>
        public Drob(int delitel)
        {
            delimoe = 1;
            this.delitel = delitel;
        }
        #endregion
        
        #region Операции

        /// <summary>
        /// Упрощает дробь. А также, возвращает упрощенную дробь
        /// Например 4/6 станет 2/3.
        /// </summary>
        public Drob Upr()
        {
            if ((delimoe < 0) && (delitel < 0))
            {
                delimoe *= -1;
                delitel *= -1;
            }
            int min = Math.Abs(delimoe) <= Math.Abs(delitel) ? delimoe : delitel;
            bool flag = true;
            if ((delimoe != 0) && (Math.Abs(delimoe) != 1))
            {
                while (flag)
                {
                    for (int i = 2; i <= Math.Abs(min); i++)
                    {
                        if ((delimoe % i == 0) && (delitel % i == 0))
                        {
                            obmnog *= i;
                            delimoe /= i;
                            delitel /= i;
                            min = delimoe <= delitel ? delimoe : delitel;
                            if (Math.Abs(min) == 1) flag = false;
                            break;
                        }
                        else if (i == Math.Abs(min))
                        {
                            flag = false;
                        }
                    }
                }
            }
            Drob drob = new Drob(delimoe, delitel);
            return drob;
        }

        /// <summary>
        /// Складывает дроби (сами дроби не изменяются)
        /// </summary>
        /// <param name="drob"></param>
        /// <returns>Возвращает результат сложения</returns>
        public Drob Plus(Drob drob)
        {
            Drob temp1 = new Drob(this);
            Drob temp2 = new Drob(drob);

            if (temp1.delitel == temp2.delitel)
            {
                temp2.delimoe += temp1.delimoe;
            }
            else
            {
                temp1.delimoe *= temp2.delitel;
                temp2.delimoe *= temp1.delitel;
                temp2.delitel *= temp1.delitel;
                temp2.delimoe += temp1.delimoe;
            }
            return temp2;
        }

        /// <summary>
        /// Складывает дроби (сами дроби не изменяются) и упрощает рузельтат
        /// </summary>
        /// <param name="drob"></param>
        /// <returns>Возвращает упрощенный результат сложения</returns>
        public Drob PlusUpr(Drob drob)
        {
            Drob res = new Drob(drob);
            res = Plus(drob);
            res.Upr();
            return res;
        }

        /// <summary>
        /// Вычитает дроби (сами дроби не изменяются)
        /// </summary>
        /// <param name="drob"></param>
        /// <returns>Возвращает результат вычитания</returns>
        public Drob Minus(Drob drob)
        {
            Drob temp1 = new Drob(this);
            Drob temp2 = new Drob(drob);

            if (temp1.delitel == temp2.delitel)
            {
                temp2.delimoe -= temp1.delimoe;
            }
            else
            {
                temp1.delimoe *= temp2.delitel;
                temp2.delimoe *= temp1.delitel;
                temp2.delitel *= temp1.delitel;
                temp2.delimoe -= temp1.delimoe;
            }
            return temp2;
        }

        /// <summary>
        /// Вычитает дроби (сами дроби не изменяются) и упрощает рузельтат
        /// </summary>
        /// <param name="drob"></param>
        /// <returns>Возвращает упрощенный результат вычитания</returns>
        public Drob MinusUpr(Drob drob)
        {
            Drob res = new Drob(drob);
            res = Minus(drob);
            res.Upr();
            return res;
        }

        /// <summary>
        /// Умножает дроби (сами дроби не изменяются)
        /// </summary>
        /// <param name="drob"></param>
        /// <returns>Возвращает результат умножения</returns>
        public Drob Umnog(Drob drob)
        {
            Drob temp1 = new Drob(this);
            Drob temp2 = new Drob(drob);

            temp2.delimoe *= temp1.delimoe;
            temp2.delitel *= temp1.delitel;
            
            return temp2;
        }

        /// <summary>
        /// Умножает дроби (сами дроби не изменяются) и упрощает рузельтат
        /// </summary>
        /// <param name="drob"></param>
        /// <returns>Возвращает упрощенный результат умножение</returns>
        public Drob UmnogUpr(Drob drob)
        {
            Drob res = new Drob(drob);
            res = Umnog(drob);
            res.Upr();
            return res;
        }

        /// <summary>
        /// Делит дроби (сами дроби не изменяются)
        /// </summary>
        /// <param name="drob"></param>
        /// <returns>Возвращает результат деления</returns>
        public Drob Deli(Drob drob)
        {
            Drob temp1 = new Drob(this);
            Drob temp2 = new Drob(drob);

            temp2.delimoe *= temp1.delitel;
            temp2.delitel *= temp1.delimoe;
            
            return temp2;
        }

        /// <summary>
        /// Делит дроби (сами дроби не изменяются) и упрощает рузельтат
        /// </summary>
        /// <param name="drob"></param>
        /// <returns>Возвращает упрощенный результат деления</returns>
        public Drob DeliUpr(Drob drob)
        {
            Drob res = new Drob(drob);
            res = Deli(drob);
            res.Upr();
            return res;
        }

        /// <summary>
        /// Возводит дробь в степень N, по умолчанию в квадрат
        /// </summary>
        /// <param name="n">Степень</param>
        /// <returns></returns>
        public Drob StepN(int n = 2)
        {
            Drob temp = new Drob(this);

            for (int i = 1; i < n; i++)
            {
                temp.delimoe *= delimoe;
                temp.delitel *= delitel;
            }

            return temp;
        }

        #region Заготовка для корней
        ///// <summary>
        ///// ВНИМАНИЕ!!! ИСКЛЮЧИТЕЛЬНО ИЗ-ЗА УСЛОВИЯ ЗАДАНИЯ ВВОДИТЬ ЦЕЛЫЕ ЧИСЛА,
        ///// ДАННЫЙ МЕТОД РАБОТАЕТ КОРРЕКТНО ТОЛЬКО В СЛУЧАЕ, ЕСЛИ КОРЕНЬ ЯВЛЯЕТСЯ ЦЕЛЫМ ЧИСЛОМ
        ///// 
        ///// 
        ///// Извлекает корень N степени, по умолчанию второй
        ///// </summary>
        ///// <param name="drob"></param>
        ///// <param name="n">Степень</param>
        ///// <returns></returns>
        //public Drob KorN(Drob drob, int n = 2)
        //{
        //    Drob temp = new Drob(drob);

        //    temp.delimoe = Convert.ToInt32(Math.Pow(Convert.ToDouble(temp.delimoe), 1.0 / Convert.ToDouble(n)));
        //    temp.delitel = Convert.ToInt32(Math.Pow(Convert.ToDouble(temp.delitel), 1.0 / Convert.ToDouble(n)));
            
        //    return temp;
        //}
        #endregion

        /// <summary>
        /// Возвращает результат дроби,
        /// например: 1/3 = 0.333333333333333
        /// </summary>
        /// <returns></returns>
        public Double Result()
        {
            Double real;
            real = Convert.ToDouble(delimoe) / Convert.ToDouble(delitel);
            return real;
        }

        #endregion
    }
}
