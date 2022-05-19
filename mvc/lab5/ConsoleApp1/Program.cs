namespace n1;
public class program
{
    public static async Task Main()
    {
        /*Task<int> t1= method1();
          int z =await t1;
          Console.WriteLine("abc"+z);

          Task t2=  method2();
          t2.Wait();
        */
      Task t1=  method1();
       
        t1.Wait();
        
        Task t2= method2();
        t2.Wait();
        Console.WriteLine("x");

    }
    public static async Task<int> method1()
    {
        // forground thread=>if main thread is ended first,will wait untill the rest of threads end
        //task create background thread if mea n ended first it will end the praogrm
        /* Console.WriteLine("method1 start"+Thread.CurrentThread.ManagedThreadId);
        await Task.Delay(3000);//await create new task that will wait the task to end
         Console.WriteLine("method1 end" + Thread.CurrentThread.ManagedThreadId);
         return 10;*/
        Console.WriteLine("method1 start");
       await Task.Delay(3000);
        Console.WriteLine("method1 end");
        return 10;
    }
    public static async Task  method2()
    {
        /*  Console.WriteLine("method2 start" + Thread.CurrentThread.ManagedThreadId);
         await Task.Delay(3000); 
          Console.WriteLine("method2 end" + Thread.CurrentThread.ManagedThreadId);
        */
        Console.WriteLine("method2 start");
       await Task.Delay(5000);
        Console.WriteLine("method2 end");
    }
}