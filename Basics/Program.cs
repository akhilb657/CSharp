﻿namespace Basics
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            Task firstTask = new Task(() => {
                Thread.Sleep(100);
                Console.WriteLine("Task 1");
            });

            firstTask.Start();

            await firstTask;
            
            Console.WriteLine("After the task was created");
        }

    }
}