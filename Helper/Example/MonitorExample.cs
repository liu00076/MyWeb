using System;
using System.Collections;
using System.Threading;

namespace Example {
    //使用Monitor 类同步两个线程
    class MonitorExample {
        #region 线程的同步问题

        const int Max = 5;
        Queue myQueue;

        public MonitorExample() {
            myQueue = new Queue();
        }

        public void FirstThread() {
            int count = 0;
            lock(myQueue) {
                Console.WriteLine("firstTh lock 锁定对象。");
                while(count < Max) {
                    Console.WriteLine("firstTh wait");
                    Monitor.Wait(myQueue);
                    Console.WriteLine("firstTh start");
                    myQueue.Enqueue(count);
                    Console.WriteLine("向myQueue中添加数据：" + count);                    
                    Monitor.Pulse(myQueue);
                    count++;
                }
                Console.WriteLine("firstTh is Closeing");
            }
        }

        public int GetQueueCount() {
            return myQueue.Count;
        }

        public void SecondThread() {
            lock(myQueue) {
                Console.WriteLine("secondTh lock 锁定对象。");
                Monitor.Pulse(myQueue);
                Console.WriteLine("secondTh wait");
                while(Monitor.Wait(myQueue,1000)) {
                    Console.WriteLine("secondth start");
                    int count = (int)myQueue.Dequeue();
                    Console.WriteLine(count.ToString());
                    Monitor.Pulse(myQueue);
                }
                Console.WriteLine("secondTh is Closeing");                
            }
        }

        //private static void Main() {
        //    MonitorExample pro = new MonitorExample();
        //    Thread firstTh = new Thread(new ThreadStart(pro.FirstThread));

        //    Thread secondTh = new Thread(new ThreadStart(pro.SecondThread));


        //    firstTh.Start();
        //    secondTh.Start();
        //    firstTh.Join();
        //    secondTh.Join();
        //    Console.WriteLine("Queue Count = " + pro.GetQueueCount().ToString());
        //    Console.ReadLine();

        //    Person per = new Person() { Name = "Luu", Age = 20, LastLoginTime = DateTime.Now };
        //    Person pers = new Person() { Name = "Luu", Age = 20, LastLoginTime = DateTime.Now };

        //    Thread perTh = new Thread(new ThreadStart(pers.GetLastDateTime));
        //    perTh.Start();
        //    per.GetLastDateTime();
        //    perTh.Join();
        //    perTh.Start();
        //    Console.ReadLine();
        //}
        #endregion
    }
}
