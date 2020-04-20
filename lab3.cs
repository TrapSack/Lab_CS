using System;

namespace Lab3
{
    class Person
    {
        public static int id = 0;
        private int id;
        private string name;
        private int age;

        public string Id
        {
            get { return this.id; }
        }

        public string Name
        {
            get { return this.name; }
            set { this.name = value; }
        }

        public int Age
        {
            get { return this.age; }
            set { this.age = value; }
        }
        public Person(string name, int age)
        {
            Person.id++;
            this.id = Person.id;
            this.name = name;
            this.age = age;
        }
    }

    class Sportsmen  Person
    {
        private int rank;
        private int weight;
        private int height;

        public int Rank
        {
            get { return this.rank; }
            set { this.rank = value; }
        }
        public int Weight
        {
            get { return this.weight; }
            set { this.weight = value; }
        }
        public int Height
        {
            get { return this.height; }
            set { this.height = value; }
        }

        public void Print()
        {
            Console.WriteLine(ID {0}nName {1}nAge {2}nRank {3}nWeight {4}nHeight {5}nn,
              id, Name, Age, rank, weight, height
            );
        }

        public void Print(int number)
        {
            switch (number)
            {
                case 0
                    Console.WriteLine(ID {0}nn, id);
                    break;
                case 1
                    Console.WriteLine(Name {0}nn, name);
                    break;
                case 2
                    Console.WriteLine(Age {0}nn, age);
                    break;
                case 3
                    Console.WriteLine(Rank {0}nn, rank);
                    break;
                case 4
                    Console.WriteLine(Weight {0}nn, weight);
                    break;
                case 5
                    Console.WriteLine(Height {0}nn, height);
                    break;
            }
        }

        public Sportsmen(int rank, int weight, int height, string name, int age)  base(name, age)
        {
            this.rank = rank;
            this.weight = weight;
            this.height = height;
        }
    }

    class Program
    {
        static void Main()
        {
            Sportsmen man = new Sportsmen(123, 80, 190, John Ceena!, 45);

            man.Print();
            man.Print(0);

            Console.ReadLine();
        }
    }
}