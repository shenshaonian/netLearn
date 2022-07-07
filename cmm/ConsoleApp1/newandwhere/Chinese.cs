using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp1.newandwhere
{
    class Chinese : INationality
    {
        public Chinese()
        {
            Console.WriteLine("bbbb");
        }

        public string Nationality
        {
            set
            {
                _Nationality = value;
            }
        }

        public string GetNationality()
        {
            return string.IsNullOrEmpty(_Nationality) ? "Chinese." : _Nationality;
        }

        private string _Nationality;

        public Chinese(string DefaultNationality)
        {
            _Nationality = DefaultNationality;
        }
    }

    /// &lt;summary&gt;
    /// 美国人
    /// &lt;/summary&gt;
    public class American : INationality
    {
        public American()
        {
            Console.WriteLine("aaaa");
        }

        public American(string DefaultNationality)
        {
            _Nationality = DefaultNationality;
        }
        private string _Nationality;
        public string Nationality
        {
            set { _Nationality = value; }
        }

        public string GetNationality()
        {
            return string.IsNullOrEmpty(_Nationality) ? "American." : _Nationality;
        }
    }

    /// &lt;summary&gt;
    ///
    /// &lt;/summary&gt;
    /// &lt;typeparam name="T"&gt;&lt;/typeparam&gt;
   /* public class PrintNationality<T> where T : INationality, new()//由于此处有new()的约束，所以编译器编译的时候无法通过，那么就将new()去掉，或者为继承INationality的类增加public类型的无参构造函数
    {
        //T item = new T();     在这个地方就不能创建实例化对象了，会提示错误“必须有具有公共无参构造函数的非抽象类型，才能用作泛型类型或方法"xxxx"中的参数T”
        public void Print()
        {
            //Console.WriteLine(string.Format("Nationality:{0}", item.GetNationality()));
        }
    }*/

   /* public class PrintNationality<T> where T : INationality, new()//由于此处有new()的约束，所以编译器编译的时候无法通过，那么就将new()去掉，或者为继承INationality的类增加public类型的无参构造函数
    {
        //T item = new T();     在这个地方就不能创建实例化对象了，会提示错误“必须有具有公共无参构造函数的非抽象类型，才能用作泛型类型或方法"xxxx"中的参数T”
        public void Print()
        {
            //Console.WriteLine(string.Format("Nationality:{0}", item.GetNationality()));
        }
    }*/
}
