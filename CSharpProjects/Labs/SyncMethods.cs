using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Labs
{
    internal class SyncMethods
    {
        // method has async for await used in the program and return task instead of void
        public static async Task Main()
        {
            Console.WriteLine($"Current Thread: {Thread.CurrentThread}"); // return thread objects
            Console.WriteLine($"CurrentProcessorId is : {Thread.GetCurrentProcessorId()}");

            Console.WriteLine($"Current Thread manager id: {Thread.CurrentThread.ManagedThreadId}");
            PrintThreadPollInfo();


            Console.WriteLine(" Thread sleeping");
            TestThreadSleep();

            Console.WriteLine("Task Delay Method"); // No blocking
            await TestTaskDelay(); // wait untill the task was completed

            Console.WriteLine(" Task.Run Method ");
            await TestTaskRun();

            Console.WriteLine(" Task.Wait method ");
            TestTaskWait();

        }

        static void PrintThreadPollInfo()
        {
            ThreadPool.GetAvailableThreads(out int workerThreads, out int completionPortThreads);
            Console.WriteLine($"Available Worker Threads: {workerThreads}");
            Console.WriteLine($"Available CompletionPort Threads: {completionPortThreads}");
        }

        public static void TestThreadSleep()
        {
            Console.WriteLine($"sleep Thread: {Thread.CurrentThread.ManagedThreadId}");
            Thread.Sleep(3000);  // Blocks thread
            Console.WriteLine($"sleep Thread: {Thread.CurrentThread.ManagedThreadId}");
        }

        public static async Task TestTaskDelay()
        {
            await Task.Run(() => //send to thread pool
            {
                Console.WriteLine($"Inside task run - Thread: {Thread.CurrentThread.ManagedThreadId}");
                Thread.Sleep(1000);
                Console.WriteLine("Task was completed");
            });
        }

        static async Task TestTaskRun()
        {
            await Task.Run(() =>
            {
                Console.WriteLine($"Inside Task.Run - Thread {Thread.CurrentThread.ManagedThreadId}");
                Thread.Sleep(2000);
                Console.WriteLine($"Task.Run Finished - Thread {Thread.CurrentThread.ManagedThreadId}");
            });

        }

        static void TestTaskWait()
        {
            Task t = Task.Run(() =>
            {
                Console.WriteLine($"Task started  - Thread: {Thread.CurrentThread.ManagedThreadId}");
                Thread.Sleep(3000);
                Console.WriteLine($"Task finished - Thread: {Thread.CurrentThread.ManagedThreadId}");

            });
            Console.WriteLine("Waiting using .Wait()...");
            t.Wait(); // BLOCKING
            Console.WriteLine("Wait completed");
        }

    }
}
