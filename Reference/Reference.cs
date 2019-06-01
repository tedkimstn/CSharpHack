/*
 * Source: https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/keywords/ref
 * Definition Source (mdoc): https://docs.microsoft.com/en-us/dotnet/
 * Author: Microsoft Docs
 * Summary: Pass an reference type argument and modify.
 * Modifications: Added a namespace.
 *                Moved methods into class Product.
 *                Added a main method that calls ModifyProductsByReference.
 * Student: Ted Kim
 * Capture Date: May 09, 2019
 */

namespace Reference
{
    class Product
    {
        static void Main(string[] args)
        {
            // Modify an item passed by reference.
            ModifyProductsByReference();
        }

        // A constructor consisted of a name and an id.
        public Product(string name, int newID)
        {
            ItemName = name;
            ItemID = newID;
        }

        public string ItemName { get; set; }
        public int ItemID { get; set; }

        // Modifies a product passed by reference.
        private static void ChangeByReference(ref Product itemRef)
        {
            // Replaces contents of itemRef from Fasteners to Stapler.
            itemRef = new Product("Stapler", 99999);
            // Replaces itemRef ItemID with 12345.
            itemRef.ItemID = 12345;
        }

        // Creates a product, pass it onto another method by reference.
        private static void ModifyProductsByReference()
        {
            // Instantiate a product.
            Product item = new Product("Fasteners", 54321);
            // Prints product values.
            System.Console.WriteLine("Original values in Main.  Name: {0}, ID: {1}\n",
                item.ItemName, item.ItemID);

            // Another method changes the product pass by reference.
            // Changes made are preserved as it was passed by a reference, not a value.
            ChangeByReference(ref item);

            // Prints changed product values.
            System.Console.WriteLine("Back in Main.  Name: {0}, ID: {1}\n",
                item.ItemName, item.ItemID);
        }
    }

   
}

/* This code produces the following results:

Original values in Main.  Name: Fasteners, ID: 54321

Back in Main.  Name: Stapler, ID: 12345


Press any key to continue...

 */
