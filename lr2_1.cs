using System;
using System.Collections.Generic;
using System.Runtime.InteropServices.ComTypes;
using System.Globalization;

class Programm
{

    static CultureInfo getVar()
    {
        Console.WriteLine("Let me know which language is prefered (eng, rus, french, dutch): ");
        var temp = Console.ReadLine(); 
        
        if (temp == "eng")
        {
            return new CultureInfo("en-Us");
        }
        else if (temp == "rus")
        {
            return new CultureInfo("ru");
        }
        else if (temp == "french")
        {
            return new CultureInfo("fr");    
        }
        else if (temp == "dutch")
        {
            return new CultureInfo("nl");
        }
        else
        {
            Console.WriteLine("Write in an appropriate format");
            return new CultureInfo("ru-BY");
        }
    }
    
    static List<string> GetMonthNamesByCulture(CultureInfo culture)
    {
        return new List<string>
        {
            culture.DateTimeFormat.GetMonthName(1),
            culture.DateTimeFormat.GetMonthName(2),
            culture.DateTimeFormat.GetMonthName(3),
            culture.DateTimeFormat.GetMonthName(4),
            culture.DateTimeFormat.GetMonthName(5),
            culture.DateTimeFormat.GetMonthName(6),
            culture.DateTimeFormat.GetMonthName(7),
            culture.DateTimeFormat.GetMonthName(8),
            culture.DateTimeFormat.GetMonthName(9),
            culture.DateTimeFormat.GetMonthName(10),
            culture.DateTimeFormat.GetMonthName(11),
            culture.DateTimeFormat.GetMonthName(12),
        };
    }
    
    static void Main(string[] args)
    {
        
        CultureInfo ci = getVar();


        List<string> mNames = GetMonthNamesByCulture(ci);

        mNames.ForEach(month =>
        {
            Console.WriteLine(month);
        });

        
    }
}