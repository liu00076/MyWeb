using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace TestClass
{
    public class PLinqTest
    {

        public static List<int> nums = Enumerable.Range(1, 100).ToList();


        public void GetStart()
        {
            var scanLines = from n in nums.AsParallel()
                            .WithMergeOptions(ParallelMergeOptions.AutoBuffered)
                            where n % 2 == 0
                            select ExpensiveFunc(n);
            Stopwatch sw = Stopwatch.StartNew();
            foreach (var line in scanLines)
            {
                Console.WriteLine(line);
            }
            Console.WriteLine("++++++++++++++++++++++++++++++++++++++++++++++++++++");

            scanLines.ForAll(m => Console.WriteLine(m));
            Console.WriteLine("Elapsed time: {0} ms. Press any key to exit.",
                            sw.ElapsedMilliseconds);
        }

        static string ExpensiveFunc(int i)
        {
            Thread.SpinWait(1000000);
            return String.Format("{0} *****************************************", i);
        }


        public void CancelParaller()
        {
            int[] source = Enumerable.Range(1, 10000000).ToArray();
            CancellationTokenSource cs = new CancellationTokenSource();

            // Start a new asynchronous task that will cancel the 
            // operation from another thread. Typically you would call
            // Cancel() in response to a button click or some other
            // user interface event.
            Task.Factory.StartNew(() =>
            {
                UserClicksTheCancelButton(cs);
            });

            int[] results = null;
            try
            {
                results = (from num in source.AsParallel().WithCancellation(cs.Token)
                           where num % 3 == 0
                           orderby num descending
                           select num).ToArray();

            }

            catch (OperationCanceledException e)
            {
                Console.WriteLine("捕获 异步操作被取消……");
                Console.WriteLine(e.Message);
            }

            catch (AggregateException ae)
            {
                Console.WriteLine("捕获 异步返回结果合并时被取消……");
                if (ae.InnerExceptions != null)
                {
                    foreach (Exception e in ae.InnerExceptions)
                        Console.WriteLine(e.Message);
                }
            }

            if (results != null)
            {
                foreach (var v in results)
                    Console.WriteLine(v);
            }
            Console.WriteLine();
        }

        static void UserClicksTheCancelButton(CancellationTokenSource cs)
        {
            // Wait between 150 and 500 ms, then cancel.
            // Adjust these values if necessary to make
            // cancellation fire while query is still executing.
            Random rand = new Random();
            Thread.Sleep(rand.Next(150, 350));
            cs.Cancel();
        }


        public void Aggerate()
        {
            // Create a data source for demonstration purposes.
            int[] source = new int[100000];
            Random rand = new Random();
            for (int x = 0; x < source.Length; x++)
            {
                // Should result in a mean of approximately 15.0.
                source[x] = rand.Next(10, 20);
            }

            // Standard deviation calculation requires that we first
            // calculate the mean average. Average is a predefined
            // aggregation operator, along with Max, Min and Count.
            double mean = source.AsParallel().Average();


            // We use the overload that is unique to ParallelEnumerable. The 
            // third Func parameter combines the results from each thread.
            double standardDev = source.AsParallel().Aggregate(
                // initialize subtotal. Use decimal point to tell 
                // the compiler this is a type double. Can also use: 0d.
                0.0,

                // do this on each thread
                 (subtotal, item) => subtotal + Math.Pow((item - mean), 2),

                 // aggregate results after all threads are done.
                 (total, thisThread) => total + thisThread,

                // perform standard deviation calc on the aggregated result.
                (finalSum) => Math.Sqrt((finalSum / (source.Length - 1)))
            );
            Console.WriteLine("Mean value is = {0}", mean);
            Console.WriteLine("Standard deviation is {0}", standardDev);
        }


        public void GetPLine()
        {
            FileIteration_1(@"E:\Apache2.2");
        }

        struct FileResult
        {
            public string Text;
            public string FileName;
        }

        // Use Directory.GetFiles to get the source sequence of file names.
        public static void FileIteration_1(string path)
        {
            var sw = Stopwatch.StartNew();
            int count = 0;
            string[] files = null;
            try
            {
                files = Directory.GetFiles(path, "*.*", SearchOption.AllDirectories);
            }
            catch (UnauthorizedAccessException e)
            {
                Console.WriteLine("You do not have permission to access one or more folders in this directory tree.");
                return;
            }

            catch (FileNotFoundException)
            {
                Console.WriteLine("The specified directory {0} was not found.", path);
            }

            var fileContents = from file in files.AsParallel()
                               let extension = Path.GetExtension(file)
                               where extension == ".txt" || extension == ".htm"
                               let text = File.ReadAllText(file)
                               select new FileResult { Text = text, FileName = file }; //Or ReadAllBytes, ReadAllLines, etc.              

            try
            {
                foreach (var item in fileContents)
                {
                    Console.WriteLine(Path.GetFileName(item.FileName) + ":" + item.Text.Length);
                    count++;
                }
            }
            catch (AggregateException ae)
            {
                ae.Handle((ex) =>
                {
                    if (ex is UnauthorizedAccessException)
                    {
                        Console.WriteLine(ex.Message);
                        return true;
                    }
                    return false;
                });
            }

            Console.WriteLine("FileIteration_1 processed {0} files in {1} milliseconds", count, sw.ElapsedMilliseconds);
        }

        public void GetOrderBy()
        {
            var source = Enumerable.Range(9, 10000);

            // Source is ordered; let's preserve it.
            var parallelQuery = from num in source.AsParallel().AsOrdered()
                                where num % 3 == 0
                                select num;

            // Use foreach to preserve order at execution time.
            foreach (var v in parallelQuery)
                Console.Write("{0} ", v);

            Console.WriteLine();

            //Use ForAll to preserve order at execution time.
            parallelQuery.ForAll(m => Console.Write("{0} ", m));

            Console.WriteLine();

            // Some operators expect an ordered source sequence.
            var lowValues = parallelQuery.Take(10).ToList();
            lowValues.ForEach(m => Console.Write("{0} ", m));
        }

    }
}
