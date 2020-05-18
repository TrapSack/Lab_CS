using System;
using System.Collections.Generic;

namespace Lab3
{
    class Human
    {
        private static int id = 0;
        public readonly int Passport;
        public int PeopleWereBorn => id;

        public readonly DateTime Birthday;
        public int Age
        {
            get
            {
                int t = (DateTime.Now.Year - Birthday.Year);
                if ((DateTime.Now.Month < Birthday.Month) ||
                    (DateTime.Now.Month == Birthday.Month &&
                    DateTime.Now.Day < Birthday.Day))
                {
                    t--;
                }
                return t;
            }
        }

        private string name;
        public string Name
        {
            get
            {
                if (name == null)
                {
                    return "N/A";
                }
                return name;
            }
            set
            {
                if (value == null)
                {
                    throw new Exception("You can't nullify someone's name!");
                }
                Console.WriteLine($"Human #{Passport} {Name} changed name to {value}");
                name = value;
            }
        }

        SortedDictionary<DateTime, string> history = new SortedDictionary<DateTime, string>();
        public string History
        {
            get
            {
                string hist = "";
                foreach (var i in history)
                {
                    hist += i.Key.ToString();
                    hist += " -- ";
                    hist += i.Value.ToString();
                    hist += "\n";
                }
                return hist;
            }
        }
        public string this[DateTime index]
        {
            get
            {
                try
                {
                    return history[index];
                }
                catch
                {
                    return null;
                }
            }
            set
            {
                history.Remove(index);
                history.Add(index, value);
            }
        }
        public DateTime this[string index]
        {
            get
            {
                foreach (var i in history)
                {
                    if (i.Value == index)
                    {
                        return i.Key;
                    }
                }
                throw new Exception("There was no such event!");
            }
            set
            {
                history.Remove(value);
                history.Add(value, index);
            }
        }
        public void AddEvent(DateTime date, string action)
        {
            history.Remove(date);
            history.Add(date, action);
        }
        public void AddEvent(string action)
        {
            AddEvent(DateTime.Now, action);
        }
        public void DelEvent(DateTime date)
        {
            history.Remove(date);
        }
        public void DelEvent(string action)
        {
            foreach (var i in history)
            {
                if (i.Value == action)
                {
                    history.Remove(i.Key);
                    break;
                }
            }
        }

        public void Say()
        {
            Say("Hi!");
        }
        public void Say(string whatToSay)
        {
            Console.WriteLine("{0}: {1}", Name, whatToSay);
        }

        public Human() : this(DateTime.Now)
        {
        }
        public Human(DateTime birthTime) : this(birthTime, null)
        {
        }
        public Human(string babyName) : this(DateTime.Now, babyName)
        {
        }
        public Human(string humanName, DateTime birthTime) : this(birthTime, humanName)
        {
        }
        public Human(DateTime birthTime, string humanName)
        {
            Birthday = birthTime;
            name = humanName;
            id++;
            Passport = id;
            Console.WriteLine($"Welcome, human #{Passport} {Name}!");
        }
        ~Human()
        {
            history.Clear();
            Console.WriteLine("Oh no, human {0} (#{1}) is dead!", Name, Passport);
        }
    }
}
