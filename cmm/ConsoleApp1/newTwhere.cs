using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;

namespace ConsoleApp1
{
    class newTwhere
    {
      /*  static void Main(string[] args)
        {

        }*/
    }

   /* /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        #region T:结构
        /// <summary>
        /// 调用：
        /// float _float = StructA<float>(1);   //结果：2.0，约束为返回float类型
        /// </summary>
        /// <typeparam name="T">约束T</typeparam>
        /// <param name="arg">int</param>
        /// <returns>返回T</returns>
        private T StructA<T>(int arg) where T : struct
        {
            double db = 1.0 + arg;
            return (T)Convert.ChangeType(db, typeof(T));
        }
        /// <summary>
        /// 调用：
        /// int _int = StructB<int>(1);         //结果：2，约束为返回int类型
        /// </summary>
        /// <typeparam name="T">约束T</typeparam>
        /// <param name="arg">任意类型</param>
        /// <returns>返回T</returns>
        private T StructB<T>(T arg) where T : struct
        {
            double db = 1.0 + (double)Convert.ChangeType(arg, typeof(double));
            return (T)Convert.ChangeType(db, typeof(T));
        }
        /// <summary>
        /// 调用：
        /// float? y = 1;
        /// float _float = StructC(y);         //结果：2.0，约束为返回float类型
        /// </summary>
        /// <typeparam name="T">约束T</typeparam>
        /// <param name="arg">任意可空类型</param>
        /// <returns>返回T</returns>
        private T StructC<T>(T? arg) where T : struct
        {
            double db = 1.0 + (double)Convert.ChangeType(arg, typeof(double));
            return (T)Convert.ChangeType(db, typeof(T));
        }
        #endregion

        private T Foo<T>(T arg) where T : class
        {
            double db = 1.0 + (double)Convert.ChangeType(arg, typeof(double));
            return (T)Convert.ChangeType(db, typeof(T));
        }
        public MainWindow()
        {
            InitializeComponent();
            *//*泛型模板实例化*//*

            //T:class
            实现<类别> gci = new 实现<类别>();
            gci.Insert(new 类别() { _int = 1, _float = 2, _double = 3.0 });

            //T:new()
            InstanceA<string> testa = new InstanceA<string>("hello");
            string str = testa.obj;
            //调用委托
            InstanceA<float>.StackDelegate ds = DoWork;

            InstanceB<类别> testb = new InstanceB<类别>();
            //委托
            //调用方式一
            DelegateT<string> dt = Method;
            string dts = dt("hello");       //结果：hello
            //调用方式二
            DelegateT<string> d = new DelegateT<string>(Method);
            dts = dt("hello");

        }
        static string Method(string s) { return s; }
        delegate string DelegateT<T>(T value);
        delegate T MyDelegate<T>() where T : new();
        private static void DoWork(float[] items) { }
        //自定义泛型约束
        //public bool MyMethod<T>(T t) where T : IMyInterface { }
    }
    #region T:new()
    //<T>为任意类型
    public class InstanceA<T>
    {
        public T obj { set; get; }
        public InstanceA(T obj)
        {
            this.obj = obj;
        }
        //创建泛型实例对像
        public static T Instance()
        {
            T t = System.Activator.CreateInstance<T>();
            return t;
        }
        public delegate void StackDelegate(T[] items);
    }
    //where T：new()指明了创建T的实例时应该具有构造函数。
    //new()约束，要求类型参数必须提供一个无参数的构造函数。 
    public class InstanceB<T> where T : new()
    {
        public static T Instance()
        {
            T t = new T();
            return t;
        }
    }
    //where T: 类别,T表示类型变量是继承于“类别”
    public class InstanceC<T> where T : 类别
    { }
    #endregion

    #region T:class
    interface 接口<T> where T : class
    {
        void Insert(T entity);
        void Update(T entity);
    }
    public class 实现<T> : 接口<T> where T : class
    {
        public void Insert(T entity)
        {

        }
        public void Update(T entity)
        {

        }
    }
    public class 类别
    {
        public 类别() { }
        public int _int { set; get; }
        public float _float { set; get; }
        public double _double { set; get; }
    }
    #endregion

    // 传人T类型，但T类型必须是IComparable类型
    public class GenericClass<T> where T : IComparable { }
    //传人T和U类型，但T类型必须是class类型，U类型必须是struct类型
    public class MyClass<T, U> where T : class where U : struct { }*/


}
