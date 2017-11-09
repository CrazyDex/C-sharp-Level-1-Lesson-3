using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HwT1
{
    //Евдохин Денис

    //1. а) Дописать структуру Complex, добавив метод вычитания комплексных чисел.
    //Продемонстрировать работу структуры;
    //б) Дописать класс Complex, добавив методы вычитания и произведения чисел.Проверить работу класса;



    class Program
    {
        static void Main(string[] args)
        {
            #region struct
            //Complex complex1;
            //complex1.a = 1;
            //complex1.b = 1;
            //Complex complex2;
            //complex2.a = 2;
            //complex2.b = 2;
            //Complex result = complex1.Plus(complex2);
            //Console.WriteLine(result.ToString());
            //result = complex1.Minus(complex2);
            //Console.WriteLine(result.ToString());
            //result = complex1.Umnog(complex2);
            //Console.WriteLine(result.ToString());
            //result = complex1.Deli(complex2);
            //Console.WriteLine(result.ToString());
            #endregion

            Complex c1 = new Complex
            {
                a = 1,
                b = 1
            };
            Complex c2 = new Complex
            {
                a = 2,
                b = 2
            };
            Complex result = new Complex();
            result = c1.Plus(c2);
            Console.WriteLine(result.ToStr());
            result = c1.Minus(c2);
            Console.WriteLine(result.ToStr());
            result = c1.Umnog(c2);
            Console.WriteLine(result.ToStr());
            result = c1.Deli(c2);
            Console.WriteLine(result.ToStr());


            Console.ReadLine();
        }

        #region Class
        class Complex
        {
            public double b;
            public double a;

            public Complex Plus(Complex x)
            {
                Complex y = new Complex
                {
                    b = b + x.b,
                    a = a + x.a
                };
                return y;
            }

            public Complex Minus(Complex x)
            {
                Complex y = new Complex();
                y.b = b - x.b;
                y.a = a - x.a;
                return y;
            }

            public Complex Umnog(Complex x)
            {
                Complex y = new Complex();
                y.b = b * x.b + a * x.b;
                y.a = a * x.b - b * x.a;
                return y;
            }

            public Complex Deli(Complex x)
            {
                Complex y = new Complex();
                y.b = (x.a * b - a * x.b) / (Math.Pow(x.a, 2) + Math.Pow(x.b, 2));
                y.a = (a * x.a + b * x.b) / (Math.Pow(x.a, 2) + Math.Pow(x.b, 2));
                return y;
            }

            public string ToStr()
            {
                return a + "+" + b + "i";
            }
        }

        #endregion

        #region struct
        //struct Complex
        //{
        //    public double b;
        //    public double a;

        //    public Complex Plus(Complex x)
        //    {
        //        Complex y;
        //        y.b = b + x.b;
        //        y.a = a + x.a;
        //        return y;
        //    }

        //    public Complex Minus(Complex x)
        //    {
        //        Complex y;
        //        y.b = b - x.b;
        //        y.a = a - x.a;
        //        return y;
        //    }

        //    public Complex Umnog(Complex x)
        //    {
        //        Complex y;
        //        y.b = b * x.b + a * x.b;
        //        y.a = a * x.b - b * x.a;
        //        return y;
        //    }

        //    public Complex Deli(Complex x)
        //    {
        //        Complex y;
        //        y.b = (x.a * b - a * x.b) / (Math.Pow(x.a, 2) + Math.Pow(x.b, 2));
        //        y.a = (a * x.a + b * x.b) / (Math.Pow(x.a, 2) + Math.Pow(x.b, 2));
        //        return y;
        //    }

        //    public string ToString()
        //    {
        //        return a + "+" + b + "i";
        //    }
        //}
        #endregion
    }
}
