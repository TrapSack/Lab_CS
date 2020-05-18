using System;
using System.Collections.Generic;
using System.Text;
using System.Globalization;

namespace Lab2
{
    static class MonthsNames
    {
        static public string LanguageList()
        {
            string write = "";
            HashSet<string> set = new HashSet<string>();
            for (char let = 'A'; let <= 'Z'; let++)
            {
                write += String.Format("{0}: ", let);
                foreach (CultureInfo ci in CultureInfo.GetCultures(CultureTypes.AllCultures))
                {
                    if (!set.Contains(ci.TwoLetterISOLanguageName) && ci.TwoLetterISOLanguageName.Length == 2 && ci.EnglishName.Length <= 10 && ci.EnglishName.StartsWith(let))
                    {
                        write += String.Format(String.Format(" {0} ({1});", ci.EnglishName, ci.TwoLetterISOLanguageName));
                        set.Add(ci.TwoLetterISOLanguageName);
                    }
                }
                write += '\n';
            }
            write += '\n';
            return write;
        }
        static public string GetMonths(CultureInfo ci)
        {
            var lastCulture = System.Threading.Thread.CurrentThread.CurrentCulture;
            var lastUICulture = System.Threading.Thread.CurrentThread.CurrentUICulture;
            System.Threading.Thread.CurrentThread.CurrentCulture = ci;
            System.Threading.Thread.CurrentThread.CurrentUICulture = ci;
            string write = "";
            write += String.Format("   {0} \n", ci.EnglishName);
            for (int i = 0; i < 12; i++)
            {
                write += String.Format("{0,2}: {1}\n", i + 1, DateTimeFormatInfo.CurrentInfo.MonthNames[i]);
            }
            System.Threading.Thread.CurrentThread.CurrentCulture = lastCulture;
            System.Threading.Thread.CurrentThread.CurrentUICulture = lastUICulture;
            return write;
        }
        static public CultureInfo LanguageToCulture(string lang)
        {
            lang = lang.Trim().ToLowerInvariant();
            if (lang.Length < 2)
            {
                throw new Exception("Неверный язык");
            }
            if (lang.Length > 2)
            {
                foreach (CultureInfo ci in CultureInfo.GetCultures(CultureTypes.AllCultures))
                {
                    if (ci.EnglishName.ToLowerInvariant().StartsWith(lang))
                    {
                        lang = ci.TwoLetterISOLanguageName;
                        break;
                    }
                }
            }
            CultureInfo culInf = new CultureInfo(lang);
            if (culInf.EnglishName.StartsWith("Unknown"))
            {
                throw new Exception("Неверный язык");
            }
            return culInf;
        }
    }
}
