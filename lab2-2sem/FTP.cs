using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Security.Cryptography;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Lab2
{
    class FTP
    {
        FileSystemWatcher watcher = new FileSystemWatcher();

        public void Execute()
        {
            watcher.Path = Path.GetDirectoryName(@"F:\3semestr\ISP(C#)\2 lab\source\");
            watcher.NotifyFilter = NotifyFilters.LastAccess
                                | NotifyFilters.Size
                                | NotifyFilters.LastWrite
                                | NotifyFilters.FileName
                                | NotifyFilters.DirectoryName;
            watcher.Filter = "*.txt";
            watcher.Created += new System.IO.FileSystemEventHandler(OnCreate);
            watcher.EnableRaisingEvents = true;

        }

        //watcher.Deleted += new System.IO.FileSystemEventHandler(OnDelete);
        //watcher.Renamed += new System.IO.RenamedEventHandler(OnRenamed);
        //watcher.Changed += new System.IO.FileSystemEventHandler(OnChanged);

        private static void OnCreate(object sender, FileSystemEventArgs e)
        {
            DateTime now = DateTime.Now;
            string recentName = now.ToString("yyyy_MM_dd_HH_mm_ss");
            string FileName = "Sales_" + recentName;
            string recentDir = Path.Combine(now.ToString("yyyy"), now.ToString("MM"), now.ToString("dd"));
            recentDir += '\\';

            var path = @"F:\3semestr\ISP(C#)\2 lab\source\" + e.Name;
            var FileInf = new FileInfo(path);
            DirectoryInfo dirInfo1 = new DirectoryInfo(@"F:\3semestr\ISP(C#)\2 lab\source\copy\");
            dirInfo1.Create();
            FileInf.CopyTo(@"F:\3semestr\ISP(C#)\2 lab\source\copy\" + e.Name, true);
            //DeleteFile x = new DeleteFile(@"F:\3semestr\ISP(C#)\2 lab\source\" + e.Name);
            //x.Execute();
            var cipher = new Crypto();
            Console.WriteLine("enter the secet key:");
            var secretKey = int.Parse(Console.ReadLine());
            string encryptedText; string decryptedText;
            
            using (StreamReader sr = new StreamReader(@"F:\3semestr\ISP(C#)\2 lab\source\copy\" + e.Name))
            {
                string message = sr.ReadToEnd();
                encryptedText = cipher.Encrypt(message, secretKey);
                Console.WriteLine(message);
                sr.Close();
            }
            using (StreamWriter sw = new StreamWriter(@"F:\3semestr\ISP(C#)\2 lab\source\copy\" + e.Name, false, System.Text.Encoding.Default))
            {
                sw.WriteLine(encryptedText);
                sw.Close();
            }
            
            DirectoryInfo dirInfo2 = new DirectoryInfo(@"F:\3semestr\ISP(C#)\2 lab\target\archive\" + recentDir);
            dirInfo2.Create();
            
            Archiver.Compress(@"F:\3semestr\ISP(C#)\2 lab\source\copy\" + e.Name, @"F:\3semestr\ISP(C#)\2 lab\target\" + Path.GetFileNameWithoutExtension(e.Name) + ".gz");
            Archiver.Decompress(@"F:\3semestr\ISP(C#)\2 lab\target\" + Path.GetFileNameWithoutExtension(e.Name) + ".gz", @"F:\3semestr\ISP(C#)\2 lab\target\archive\" + recentDir + FileName + ".txt");
            FileInf = new FileInfo(@"F:\3semestr\ISP(C#)\2 lab\source\copy\" + e.Name);
            FileInf.Delete();
            dirInfo1.Delete();

            var cipher1 = new Crypto();
            using (StreamReader sr = new StreamReader(@"F:\3semestr\ISP(C#)\2 lab\target\archive\" + recentDir + FileName + ".txt"))
            {
                string message1 = sr.ReadToEnd();
                decryptedText = cipher1.Decrypt(encryptedText, secretKey);
                sr.Close();
            }
            using (StreamWriter sw = new StreamWriter(@"F:\3semestr\ISP(C#)\2 lab\target\archive\" + recentDir + FileName + ".txt", false, System.Text.Encoding.Default))
            {
                sw.WriteLine(decryptedText);
                sw.Close();
            }

        }
    }
}
