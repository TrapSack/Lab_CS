using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab2
{
    class Archiver
    {
        public static void Compress(string path, string cpath)
        {
            try
            {
                using (FileStream sourceStream = new FileStream(path, FileMode.OpenOrCreate))
                {
                    using (FileStream targetStream = File.Create(cpath))
                    {
                        using (GZipStream compressionStream = new GZipStream(targetStream, CompressionMode.Compress))
                        {
                            sourceStream.CopyTo(compressionStream);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                throw;
            }
        }
        
        public static void Decompress(string cpath, string path)
        {
            try
            {
                using (FileStream sourceStream = new FileStream(cpath, FileMode.OpenOrCreate))
                {
                    using (FileStream targetStream = File.Create(path))
                    {
                        using (GZipStream decompressionStream = new GZipStream(sourceStream, CompressionMode.Decompress))
                        {
                            decompressionStream.CopyTo(targetStream);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                throw;
            }
        }
    }
}
