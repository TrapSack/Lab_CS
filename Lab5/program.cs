using System;

namespace lab5
{
    enum printProperty
    {
        id,
        name,
        age,
        rank,
        weight,
        height,
        sportKind
    }

    abstract class Person
    {
        public static int id = 0;
        public int Id { get; }

        public string Name { get; set; }

        public int Age { get; set; }


        public virtual void Print()
        {
            Console.WriteLine("ID: {0}\nName: {1}\nAge: {2}\nRank: {3}\nWeight: {4}\nHeight: {5}\n\n",
              Id, Name, Age
            );
        }

        public virtual void Print(printProperty property)
        {
            switch (property)
            {
                case printProperty.id:
                    Console.WriteLine("ID: {0}\n\n", Id);
                    break;
                case printProperty.name:
                    Console.WriteLine("Name: {0}\n\n", Name);
                    break;
                case printProperty.age:
                    Console.WriteLine("Age: {0}\n\n", Age);
                    break;
                default:
                    Console.WriteLine("There are no requested property in Person object.");
                    break;
            }
        }



        public Person(string name, int age)
        {
            Person.id++;
            this.Id = Person.id;
            this.Name = name;
            this.Age = age;
        }
    }

    abstract class Sportsmen : Person
    {
        public int Rank { get; set; }
        public int Weight { get; set; }
        public int Height { get; set; }

        public override void Print()
        {
            Console.WriteLine("ID: {0}\nName: {1}\nAge: {2}\nRank: {3}\nWeight: {4}\nHeight: {5}\n\n",
              Id, Name, Age, Rank, Weight, Height
            );
        }

        public override void Print(printProperty property)
        {
            switch (property)
            {
                case printProperty.id:
                    Console.WriteLine("ID: {0}\n\n", Id);
                    break;
                case printProperty.name:
                    Console.WriteLine("Name: {0}\n\n", Name);
                    break;
                case printProperty.age:
                    Console.WriteLine("Age: {0}\n\n", Age);
                    break;
                case printProperty.rank:
                    Console.WriteLine("Rank: {0}\n\n", this.Rank);
                    break;
                case printProperty.weight:
                    Console.WriteLine("Weight: {0}\n\n", this.Weight);
                    break;
                case printProperty.height:
                    Console.WriteLine("Height: {0}\n\n", this.Height);
                    break;
                default:
                    Console.WriteLine("There are no requested property in Sportsmen object.");
                    break;
            }
        }

        public Sportsmen(int rank, int weight, int height, string name, int age) : base(name, age)
        {
            this.Rank = rank;
            this.Weight = weight;
            this.Height = height;
        }
    }

    class SpecialSportsmen : Sportsmen
    {
        public string SportKind { get; set; }
        public override void Print()
        {
            Console.WriteLine("ID: {0}\nName: {1}\nAge: {2}\nRank: {3}\nWeight: {4}\nHeight: {5}\nKind of sport: {6}\n\n",
              Id, Name, Age, Rank, Weight, Height, SportKind
            );
        }

        public override void Print(printProperty property)
        {
            switch (property)
            {
                case printProperty.id:
                    Console.WriteLine("ID: {0}\n\n", Id);
                    break;
                case printProperty.name:
                    Console.WriteLine("Name: {0}\n\n", Name);
                    break;
                case printProperty.age:
                    Console.WriteLine("Age: {0}\n\n", Age);
                    break;
                case printProperty.rank:
                    Console.WriteLine("Rank: {0}\n\n", Rank);
                    break;
                case printProperty.weight:
                    Console.WriteLine("Weight: {0}\n\n", Weight);
                    break;
                case printProperty.height:
                    Console.WriteLine("Height: {0}\n\n", Height);
                    break;
                case printProperty.sportKind:
                    Console.WriteLine("Kind of Sport: {0}\n\n", this.SportKind);
                    break;
                default:
                    Console.WriteLine("There are no requested property in Sportsmen object.");
                    break;
            }
        }


        public SpecialSportsmen(int rank, int weight, int height, string name, int age, string sportKind) : base(rank, weight, height, name, age)
        {
            this.SportKind = sportKind;
        }
    }

    class Program
    {
        static void Main()
        {
            SpecialSportsmen man = new SpecialSportsmen(123, 80, 190, "John Ceena!", 45, "MMA");

            man.Print();
            man.Print(printProperty.age);

            Console.ReadLine();
        }
    }
}