/*
 * Source: https://docs.microsoft.com/en-us/dotnet/api/system.collections.arraylist?view=netframework-4.8
 * Definition Source (mdoc): https://docs.microsoft.com/en-us/dotnet/
 * Author: Microsoft Docs
 * Summary: 
 * Modifications: Added a namespace.
 * Student: Ted Kim
 * Capture Date: May 07, 2019
 */

using System;
using System.Collections;

namespace ArrayListMProj { 

public class SamplesArrayList  {

   public static void Main()  {

      // Initializes an ArrayList.
      // Size of an ArrayList is dynamically increased. 
      ArrayList myAL = new ArrayList();
      // Adds heterogeneous items in an ArrayList.
      // Use of List<T> is recommended for performance concerns.
      // ArrayList stores objects of each item but
      // List<T> stores items of a speecific type T. Boxing & Unboxing is not required.
      myAL.Add("Hello");
      myAL.Add("World");
      myAL.Add("!");

      
      Console.WriteLine( "myAL" );
      // ArrayList.Count returns number of elements.
      // ArrayList.Capacity returns number of elements an ArrayList can contain.
      Console.WriteLine( "    Count:    {0}", myAL.Count );
      Console.WriteLine( "    Capacity: {0}", myAL.Capacity );
      Console.Write( "    Values:" );
      // Prints each item in an ArrayList.
      PrintValues( myAL );
   }

   // Prints each itmes in a list that implements IEnumerable.
   public static void PrintValues( IEnumerable myList )  {
      foreach ( Object obj in myList )
         // Prints text implementation of an object.
         Console.Write( "   {0}", obj );
      Console.WriteLine();
   }

}

}

/* This code produces the following results:

11 chars: ABCDEFGHIJk
21 chars: Alphabet: ABCDEFGHIJK

Press any key to continue...

 */
