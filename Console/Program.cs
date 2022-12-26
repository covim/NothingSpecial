using LiteDB_Class;
using System.ComponentModel.DataAnnotations;
using Types;

namespace Console
{
    internal partial class Program
    {
        static void Main(string[] args)
        {
            System.Console.WriteLine("Hello, World!");
            
            var database = Database.OpenOrCreateDatabase();
            var collection = Database.GetOrCreateCollection(database);

            var cu1 = new Customer { Id = Guid.NewGuid().ToString(), Name = "Susanne", Phones = new string[] { "2433", "2265" } };
            collection.Insert(cu1);

            var cu2 = new Customer();
            cu2 = collection.FindOne(x => x.Name == "Susanne");
            cu2.Id= Guid.NewGuid().ToString();  
            collection.Insert(cu2);

            System.Console.WriteLine();
            System.Console.WriteLine("die gesuchten Nummern lauten:");
            for (int i = 0; i < cu2.Phones.Length; i++)
            {
                System.Console.WriteLine(cu2.Phones[i]);
            }

        }
  
    }
}