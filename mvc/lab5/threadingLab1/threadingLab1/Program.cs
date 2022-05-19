using System.Diagnostics;

namespace threadingLab1;
class program
{
   public static void Main()
    {
        Stopwatch sp = new Stopwatch();
        sp.Start();
        Thread t1 = new Thread(method1);//create new thread
        t1.Start();
       // method1();
       Thread t2 =new Thread(method2);
        t2.Start();
        //method2();
        sp.Stop();
        Console.WriteLine(sp.ElapsedMilliseconds);
    }
    public static void method1()
    {
        Console.WriteLine("method1 start...");
        Thread.Sleep(5000);
        Console.WriteLine("method1 end...");
    }
    public static void method2()
    {
        Console.WriteLine("method2 start...");
        Thread.Sleep(3000);//stop the thread for 3s(method take 3s)
        Console.WriteLine("method2 end...");
    }
}


