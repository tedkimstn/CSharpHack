/*
 * Source: https://docs.microsoft.com/en-us/dotnet/api/system.threading.thread?view=netframework-4.8
 * Definition Source (mdoc): https://docs.microsoft.com/en-us/dotnet/
 * Author: Microsoft Docs
 * Summary: Showcases multithreading capability.
 * Modifications: Added a namespace.
 *                Modified from Sleep(0) to Sleep(1) to view multithreading performance.           
 * Student: Ted Kim
 * Capture Date: May 07, 2019
 */

using System;
using System.Threading;

public class ThreadExample
{

    public static void ThreadProc()
    {
        for (int i = 0; i < 10; i++)
        {

            Console.WriteLine("ThreadProc: {0}", i);
            Thread.Sleep(1);

        }
    }

    public static void Main()
    {
        Console.WriteLine("Main thread: Start a second thread.");

        // ThreadStart Delegate: "Represents the method that executes on a Thread" (mdoc).
        // Thread: "Creates and controls a thread, sets its priority, and gets its status" (mdoc).
        // Creates the second thread that executes method ThreadProc.
        Thread t = new Thread(new ThreadStart(ThreadProc));

        // "Causes a thread to be scheduled for execution" (mdoc).
        // Executes "ThreadProc" method on a seperate thread.
        t.Start();


        // Codes on the main thread and the second thread are executed simultaneously.
        for (int i = 0; i < 4; i++)
        {

            // "Suspends the current thread for the specified amount of time" (mdoc).
            // A thread is suspended that any other threads can be executed.
            Console.WriteLine("Main thread: Do some work.");
            Thread.Sleep(1);

        }

        Console.WriteLine("Main thread: Call Join(), to wait until ThreadProc ends.");
        // "Blocks the calling thread until the thread represented by this instance terminates" (mdoc).
        // Main method thread waits until thread that executes ThreadProc ends.
        t.Join();
        Console.WriteLine("Main thread: ThreadProc.Join has returned.  Press Enter to end program.");
        Console.ReadLine();
    }
}

/* This code produces the following results:

Main thread: Start a second thread.
Main thread: Do some work.
Main thread: Do some work.
ThreadProc: 0
Main thread: Do some work.
ThreadProc: 1
Main thread: Do some work.
ThreadProc: 2
Main thread: Call Join(), to wait until ThreadProc ends.
ThreadProc: 3
ThreadProc: 4
ThreadProc: 5
ThreadProc: 6
ThreadProc: 7
ThreadProc: 8
ThreadProc: 9
Main thread: ThreadProc.Join has returned.  Press Enter to end program.

 */
