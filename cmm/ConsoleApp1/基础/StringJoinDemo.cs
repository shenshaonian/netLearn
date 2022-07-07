using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp1.基础
{
    class StringJoinDemo
    {

        static void Main(string[] args)
        {

            var numbers = new string[] { "第一个", "第二个", "第三个", "第四个", "第五个", "第六个" };

            var a = string.Join("/", numbers);

            //string.Join(阻隔符号, 数组, 起始数, 总数);
            var b = string.Join("/", numbers, 1, 1);
            var c = string.Join("/", numbers, 0, 1);
            var d = string.Join("-", numbers, 1, 3);
            var e = string.Join("，", numbers, 1, 2);
            var f = string.Join("/", numbers, 0, 0);

            Console.WriteLine(a);
            Console.WriteLine(b);
            Console.WriteLine(c);
            Console.WriteLine(d);
            Console.WriteLine(e);
            Console.WriteLine(f);

        }

    }
}
