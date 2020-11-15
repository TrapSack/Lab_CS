using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab2
{
    public class DeleteFile
    {
        readonly string path;
        public DeleteFile(string x)
        {
            path = x;
        }
        public void Execute()
        {
            try
            {
                var FileInf = new FileInfo(path);
                if (FileInf.Exists)
                {
                    FileInf.Delete();
                }
                else
                    Console.WriteLine("This file doesn't exist");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                throw;
            }
        }
    }
}
