/*
 * Source: https://www.tutorialspoint.com/csharp/csharp_events.htm
 * Definition Source (mdoc): https://docs.microsoft.com/en-us/dotnet/
 * Author: tutorialspoint
 * Summary: Showcases how to publish and subscribe to an event.
 * Modifications: Modified a namespace.
 *                Removed "this" keyword when subscribing to an event.
 *                Removed redundant instantiation of MyDel when subscribing to an event.
 *                Cusomized WelcomeUser return string and string argument used to invoke an event. 
 * Student: Ted Kim
 * Capture Date: May 07, 2019
 */

using System;

namespace Event 
{

    // "A delegate is a type that represents references to methods 
    //  with a particular parameter list and return type" (mdoc).
    public delegate string MyDel(string str);
    
   class EventProgram 
   {

      // "declare an event in a publisher class" (mdoc).
      event MyDel MyEvent;

      // EventProgram consturctor.
      public EventProgram() 
      {
         MyEvent += WelcomeUser;
      }

      // Returns a string of "Welcome " + username.
      public string WelcomeUser(string username) 
      {
         return "Hello, " + username;
      }

      static void Main(string[] args) 
      {
         // Initiate an Eventprogram.
         EventProgram obj1 = new EventProgram();
         // Invokes EventHandler in EventProgram.
         // Methods that subscribes to an event is executed.
         string result = obj1.MyEvent("World!");
         // Prints result.
         Console.WriteLine(result);
      }

   }
}

/* This code produces the following results:

Hello, World!

Press any key to continue...

 */
