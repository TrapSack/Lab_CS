using System;

namespace Lab3
{
    class Program
    {
        static void Main(string[] args)
        {
            Human god = new Human(DateTime.MinValue, "God");
            god[DateTime.MinValue] = "TEST";
            god[DateTime.MinValue] += "; separation of light from darkness";
            god[DateTime.MinValue.AddDays(1)] = "creation of firmament";
            god["planting"] = DateTime.MinValue.AddDays(2);
            god.AddEvent(DateTime.MinValue.AddDays(3), "addition of luminaries");
            god[DateTime.MinValue.AddDays(4)] = "making animals";
            god[DateTime.MinValue.AddDays(5)] = "fashioning human";
            Console.Write(god.History);
            god.Say("Hello World!");

            Creation();
            GC.Collect(); GC.WaitForPendingFinalizers(); 

            Human norman = new Human("Norman");
            norman[DateTime.Now] = "birth";
            Console.WriteLine($"{norman.Name} hates his name!");
            norman.Name = "John Doe";
            norman.AddEvent("test");
            norman.AddEvent(DateTime.UnixEpoch, "test");
            Console.Write($"History of {norman.Name}:\n{norman.History}");
            norman.DelEvent("test");
            Console.Write($"History of {norman.Name}:\n{norman.History}");

            Console.WriteLine($"So, totally were born {god.PeopleWereBorn} humans"); ;
            Console.WriteLine($"Age of the world is {god.Age} years"); ;
            
            return;
        }
        static void Creation()
        {
            Human adam = new Human("Adam");
            Human eve = new Human("Eve");
            Console.WriteLine("God's wrath!");
        }
    }
}
