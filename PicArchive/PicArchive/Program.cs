using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;


namespace PicArchive
{
    class Program
    {
        static void Main(string[] args)
        {
            string from = Environment.GetFolderPath(Environment.SpecialFolder.MyPictures);
            string to = @"Picture_Backup\";

            DirectoryCopy.Copy(from, to, true);
        }
    }
}
