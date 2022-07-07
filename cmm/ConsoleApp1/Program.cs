using System;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            string s = "12月";
            string v = s.Replace("岁", "").Replace("月", "").Replace("周", "").Replace("天", "");
            Console.WriteLine(v);

            DemoOrderDto demoOrderDto = new DemoOrderDto();
           /* demoorderdto demoorderdto1 = new demoorderdto();
            demoorderdto1.pat_birthday = new datetime(1995, 12, 21, 2, 30, 49);*/
            demoOrderDto.Pat_Birthday = new DateTime(1995, 12, 21);

            DemoDto agedto = DemoUtils.getAgeNew((DateTime)demoOrderDto.Pat_Birthday, DateTime.Now.Date, false);
            Console.WriteLine("age:" + agedto.Age+" ageunit: "+ agedto.AgeUnit +"agereort "+ agedto.Report_Age);

            string birthTime = "20181123051641";
            DemoDto agedto1 = new DemoDto();
            DemoOrderDto demoOrderDto1 = new DemoOrderDto();
            demoOrderDto1.Pat_Birthday = DateTime.ParseExact(birthTime, "yyyyMMddHHmmss", System.Globalization.CultureInfo.CurrentCulture);
            Console.WriteLine(" demoOrderDto1 " + demoOrderDto1.Pat_Birthday);

            // ??
            string wenhao = "空接合操作符";
            string wenhao1 = "";
            string wenhao11 = null;
            string tw = wenhao1 ?? "heihei";
            Console.WriteLine("tw: "+ tw);
        }
    }
}
