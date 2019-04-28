/*
 * Source: https://www.sanfoundry.com/csharp-program-count-file-extensions-linq/
 * Definition Source (mdoc): https://docs.microsoft.com/en-us/dotnet/
 * Author: Sanfoundry
 * Summary: Counts and groups file extentions.
 * Modifications: Modified project name.
 *                Removed unnecessary namespaces. 
 *                Modified variables' names for readability.
 * Student: Ted Kim
 * Capture Date: April 21, 2019
 */

using System;
using System.Linq;
using System.IO;

namespace LINQMProj
{
    class Program
    {
        public static void Main()
        {
            string[] fileList = { "aaa.txt", "bbb.TXT", "xyz.abc.pdf", "aaaa.PDF",
                             "abc.xml", "ccc.txt", "zzz.txt" };
            // Select: "projects each element of a sequence into a new form" (mdoc).
            // "a lambda expression uses =>, the lambda declaration operator 
            //  to separate the lambda's parameter list from its executable code" (mdoc).
            // Expression inside arr.Select uses "file" parameter. 
            // The expression obtains a file extension, removes "." and converts it to lowercase.
            // Then select method makes a new list with new elements resulted from the lambda expression.
            var groupedFileList = fileList.Select(file => Path.GetExtension(file).TrimStart('.').ToLower())
                       // "GroupBy": "groups the elements of a sequence 
                       // according to a specified key selector function
                       // and creates a result value from each group and its key" (mdoc).
                       // First parameter defines the key.
                       // Second parameter saves grouping result. 
                       // "ext" and "extCnt" are programmer-defined variables 
                       // that saves a key for a group and a list of group elements respectively.
                       // "new" operator: "create instances of anonymous type" (mdoc).
                       .GroupBy(fileExt => fileExt, (ext, extGroupedList) => new
                       {
                           // Group key.
                           Extension = ext,
                           // Counts group elements.
                           Count = extGroupedList.Count()
                       });

            foreach (var v in groupedFileList)
                Console.WriteLine("{0} File(s) with {1} Extension ",
                                    v.Count, v.Extension);
            Console.ReadLine();
        }
    }
}

/* This code produces the following results:

4 File(s) with txt Extension 
2 File(s) with pdf Extension 
1 File(s) with xml Extension 

*/
