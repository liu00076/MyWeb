using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace TestClass
{
    /// <summary>
    /// 使用Mutex 用于进程间的同步
    /// </summary>
    class MutexTest
    {
        private const int NumIterations = 1;
        private const int NumThreads = 3;
        // Create a new Mutex. The creating thread does not own the
        // Mutex.
        private static readonly Mutex Mut = new Mutex(false, "hello");

        private static void Main()
        {
            // Create the threads that will use the protected resource.
            for (var i = 0; i < NumThreads; i++)
            {
                var myThread = new Thread(MyThreadProc) { Name = string.Format("Thread{0}", i + 1) };
                myThread.Start();
            }

            // The main thread exits, but the application continues to
            // run until all foreground threads have exited.
            Console.ReadKey();
        }

        private static void MyThreadProc()
        {
            for (var i = 0; i < NumIterations; i++)
            {
                UseResource();
            }
        }

        // This method represents a resource that must be synchronized
        // so that only one thread at a time can enter.
        private static void UseResource()
        {
            if (Thread.CurrentThread.Name != null)
            {
                Thread.CurrentPrincipal = new GenericPrincipal(
                           new GenericIdentity(Guid.NewGuid().ToString("N"), "BasicAuth"), null);
                var i = Convert.ToInt32(Thread.CurrentThread.Name.Substring(Thread.CurrentThread.Name.Length - 1, 1));
                // Wait until it is safe to enter.
                Mut.WaitOne();
                if (Thread.CurrentPrincipal.Identity.IsAuthenticated)
                {
                    Console.WriteLine("获取当前线程Identity名称：" + Thread.CurrentPrincipal.Identity.Name);
                    Console.WriteLine("当前用户认证类型：" + Thread.CurrentPrincipal.Identity.AuthenticationType);
                }

                Console.WriteLine("{0} has entered the protected area{1}",
                    Thread.CurrentThread.Name, i);
            }

            // Place code to access non-reentrant resources here.

            // Simulate some work.
            Thread.Sleep(500);

            Console.WriteLine("{0} is leaving the protected area\r\n", Thread.CurrentThread.Name);

            // Release the Mutex.
            Mut.ReleaseMutex();
        }
    }
}
