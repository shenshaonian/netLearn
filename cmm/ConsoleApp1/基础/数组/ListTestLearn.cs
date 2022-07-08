using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp1.基础.数组
{
    class ListTestLearn
    {

        static void Main(string[] args)
        {
            //newArrayList();
            //arrayIndex();
            //arrayAdd();
            //arrayInsertRange();
            //arraySort();
            arrayMysort();
        }


        #region arrayList



        public static void newArrayList()
        {
            ArrayList list4 = new ArrayList() { 1, 2, 3, 4 };
            foreach (var v in list4)
            {
                Console.WriteLine(v);
            }
        }


        public static void arrayIndex()
        {
            ArrayList arrayList = new ArrayList() { "aaa", "bbb", "abc", 123, 456 };
            int index = arrayList.IndexOf("abc");
            if (index != -1)
            {
                Console.WriteLine("集合中存在 abc 元素！" + index);
            }
            else
            {
                Console.WriteLine("集合中不存在 abc 元素！");
            }
        }


        public static void arrayAdd()
        {
            ArrayList arrayList = new ArrayList() { "aaa", "bbb", "abc", 123, 456 };
            ArrayList arrayList1 = new ArrayList();
            for (int i = 0; i < arrayList.Count; i++)
            {
                arrayList1.Add(arrayList[i]);
            }
            foreach (var item in arrayList1)
            {
                Console.WriteLine(item);
            }
        }


        public static void arrayInsertRange()
        {
            ArrayList list = new ArrayList() { "aaa", "bbb", "abc", 123, 456 };
            ArrayList insertList = new ArrayList() { "A", "B", "C" };
            insertList.InsertRange(3, list);
            foreach (var item in insertList)
            {
                Console.WriteLine(item);
            }
        }


        public static void arraySort()
        {
            ArrayList list = new ArrayList() { "aaa", "bbb", "abc","1","2","f"};
            Console.WriteLine("adsfasdf");
            list.Sort();
            Console.WriteLine("hhhhh");
            foreach (var item in list)
            {
                Console.WriteLine(item);
            }
        }


        public static void arrayMysort()
        {
            ArrayList list = new ArrayList() { "a", "b", "c", 1, 2 };
            MyCompare myCompare = new MyCompare();//创建自定义比较器实例
            list.Sort(myCompare);
            foreach (var v in list)
            {
                Console.WriteLine(v);
            }
        }

        class MyCompare : IComparer
        {
            public int Compare(object x, object y)
            {
                string str1 = x.ToString();
                string str2 = y.ToString();
                Console.WriteLine("heihei "+ str1.CompareTo(str2)+" str1 str2"+ str1+"--- " +str2);
                return str1.CompareTo(str2);
            }
        }




        #endregion



    }
}
