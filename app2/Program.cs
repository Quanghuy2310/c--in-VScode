using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection.Emit;
using System.Text;



namespace async_await
{
    class Program
    {

        static void DoSomeThing(int seconds, string mgs, ConsoleColor color)
        {


            lock (Console.Out)
            {
                Console.ForegroundColor = color;
                Console.WriteLine($"{mgs,10} ... Start");
                Console.ResetColor();
            }

            for (int i = 0; i <= seconds; i++)
            {
                lock (Console.Out)
                {
                    Console.ForegroundColor = color;
                    Console.WriteLine($"{mgs,10} {i,2}");
                    Console.ResetColor();
                }

                Thread.Sleep(1000);
            }
            lock (Console.Out)
            {
                Console.ForegroundColor = color;
                Console.WriteLine($"{mgs,10} ... End");
            }
            // asynchronous (multithread)

        }
        static async Task Task2()
        {
            Task t2 = new Task(
                () =>
                {
                    DoSomeThing(5, "T2", ConsoleColor.Green);
                }); // k cần trả về giá trị
            t2.Start();
            await t2; //
            // t2.Wait();
            System.Console.WriteLine("T2 Finish");
        }
        static async Task Task3()
        {
            Task t3 = new Task(
                (object ob) =>
                {
                    string tentacvu = (string)ob;
                    DoSomeThing(4, tentacvu, ConsoleColor.Yellow);
                }
            , "T3");
            t3.Start();
            await t3;
            // t3.Wait();
            System.Console.WriteLine("T2 Finish");

            // return t3; k cần trả về vì await tự đọng trả về r
        }
        // async/await  
        static async Task Abc()
        {
            // Task2 task = new Task2(()=> {
            // // ... các chỉ thị

            // });
            // task.Start();
            // await task;

            await File.WriteAllTextAsync("1.txt", "dslf");
            //... 
        }
        static async Task Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;
            // synchronous
            // Task 
            // Task t2 = Task2();

            // Task t3 = Task3();

            Task<string> t4 = new Task<string>(
                () =>
                {
                    DoSomeThing(10, "T4", ConsoleColor.Green);
                    return "Return from T4";
                });  //() => {return <>}

            Task<string> t5 = new Task<string>(
                (object ob) =>{
                    string t = (string)ob;
                    DoSomeThing(4,t,ConsoleColor.Yellow);
                    return $"Return from {t}";
                }, "T5");

            // Task t3 = new Task(Action<Object>, Object); //Object ob =>{}

            // t2.Start();
            // t3.Start(); // comment code vì 1 task ko được chạy 2 lần

            t4.Start();
            t5.Start();

            DoSomeThing(6, "T1", ConsoleColor.Magenta);
            Task.WaitAll(t4, t5);
            var resultT4 = t4.Result;
            var resultT5 = t5.Result;
            System.Console.WriteLine(resultT4);
            System.Console.WriteLine(resultT5);


            // t2.Wait();
            // t3.Wait();
            // Task.WaitAll(t2, t3);
            // await t2;
            // await t3;

            // DoSomeThing(5, "Method 1", ConsoleColor.Red);
            // DoSomeThing(2, "Method 2", ConsoleColor.Yellow);
            // DoSomeThing(10, "Method 3", ConsoleColor.Magenta);

            
            Console.WriteLine("Press to End");
            Console.ReadLine();
        }
    }
}