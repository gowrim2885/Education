namespace Labs
{
    public class StudentThread
    {
        static int StudentCount = 0;
        static object locker = new object();
        public static void Main()
        {
            Console.WriteLine("Main Thread Start");
            //AddStudent();
            StudentDeadLock.Start();

            Console.WriteLine("Main thread End");
        }

        public static void SingleThread()
        {
            LoadStudents();
            GenerateStudent();
            SendEmail();
        }

        public static void MultipleThreadSample()
        {
            //create the thread for each task
            Thread T1 = new Thread(LoadStudents);
            Thread T2 = new Thread(GenerateStudent);
            Thread T3 = new Thread(SendEmail);

            T1.Start();
            T2.Start();
            T3.Start();

            // Join Method is Wait untill the thread finsh the task
            T1.Join();
            T2.Join();
            T3.Join();
        }

        public static void ParallelMethod()
        {
            Parallel.Invoke(
                LoadStudents, GenerateStudent, SendEmail
            );
            Console.WriteLine("All Task Complete the Execution");
        }

        public static void AddStudent()
        {
            Thread Addthread1 = new Thread(CreateStudent);
            Thread Addthread2 = new Thread(CreateStudent);

            Addthread1.Start();
            Addthread2.Start();

            Addthread1.Join();
            Addthread2.Join();
            Console.WriteLine("Final Count" + StudentCount);
        }

        public static void CreateStudent()
    {
            for (int i = 0; i < 30; i++)
            {
                lock (locker)
                {
                    StudentCount++;
                }
                //Monitor.Enter(locker);
                //try
                //{
                //    StudentCount++;
                //}
                //catch
                //{
                //    Monitor.Exit(locker);
                //}
            }

        }
        public static void LoadStudents()
        {
            for(int i=1; i<= 3; i++)
            {
                Console.WriteLine($"Start Loading Student {i} Information...");
                Thread.Sleep(3000);
                Console.WriteLine($"End Loading Student{i} Information...");
            }

        }
        public static void GenerateStudent()
        {
            for (int i = 1; i <= 3; i++)
            {
                Console.WriteLine($"Start Generate Student {i} Reports...");
                Thread.Sleep(3000);
                Console.WriteLine($"End Generate Student {i} Reports...");
            }

        }
        public static void SendEmail()
        {
            for (int i = 1; i <= 3; i++)
            {
                Console.WriteLine($"Start Send Mail to Student {i}...");
                Thread.Sleep(3000);
                Console.WriteLine($"End Send Mail to Student {i}...");
            }
            
        }
    }


    public class StudentDeadLock
    {
        public static void Start()
        {
            Console.WriteLine("Main Thread Start");

            Thread t1 = new Thread(SendStudentReport);
            Thread t2 = new Thread(RegisterStudent);

            t1.Start();
            t2.Start();

            t1.Join();
            t2.Join();

            Console.WriteLine("Main Thread End");
        }

        public static void RegisterStudent()
        {
            Console.WriteLine("Thread 1 locked Student Database");
            Thread.Sleep(5000);
            Console.WriteLine("Thread 1 locked Email service");

            Console.WriteLine("Thread 1 Student Registered and Email Sent");
        }
        public static void SendStudentReport()
        {
            Console.WriteLine("Thread 2 locked Email service");
            Thread.Sleep(5000);
            Console.WriteLine("Thread 2 locked Student Database");

            Console.WriteLine("Thread 2 Student Registered and Email Sent");
        }
    }
}

