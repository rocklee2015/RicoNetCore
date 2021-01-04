using BookDemo.S04.S401;
using BookDemo.S08.S801;
using BookDemo.S08.S802;
using BookDemo.S08.S803;
using BookDemo.S08.S804;
using BookDemo.S08.S805;
using System;

namespace BookDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("示例开始".PadLeft(30, '-').PadRight(64, '-') + "\r\n");

            IBookDemo bookDemo;
            //bookDemo = new S401();

            //第八章  诊断日志(上)
            //bookDemo = new S801();
            //bookDemo = new S802();
            //bookDemo = new S803();
            //bookDemo = new S804();
            bookDemo = new S805();

            bookDemo.Main();

            Console.WriteLine("\r\n");
            Console.WriteLine("示例结束".PadLeft(30, '-').PadRight(64, '-'));

            Console.ReadKey();
        }
    }
}
