using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace PicArchive
{
    public static class DirectoryCopy
    {
        public static void Copy(string startLocation, string destination, bool recursive)
        {
            // Get the subdirectories for the specified directory.
            DirectoryInfo dir = new DirectoryInfo(startLocation);

            if (!dir.Exists)
            {
                throw new DirectoryNotFoundException(
                    "Source directory does not exist or could not be found: "
                    + startLocation);
            }

            DirectoryInfo[] dirs = dir.GetDirectories();
            // If the destination directory doesn't exist, create it.
            if (!Directory.Exists(destination))
            {
                Directory.CreateDirectory(destination);
            }

            // Get the files in the directory and copy them to the new location.
            FileInfo[] files = dir.GetFiles();
            foreach (FileInfo file in files)
            {
                if (!File.Exists(Path.Combine(destination, file.Name)))
                {
                    string temppath = Path.Combine(destination, file.Name);
                    file.CopyTo(temppath, false);
                }
            }

            // If copying subdirectories, copy them and their contents to new location.
            if (recursive)
            {
                foreach (DirectoryInfo subdir in dirs)
                {
                    //little modification mum requested
                    if(subdir.FullName.ToLower().Contains("mum"))
                    {
                        string temppath = Path.Combine(destination, subdir.Name);
                        Copy(subdir.FullName, temppath, recursive);
                    }
                    
                }
            }
        }
    }
}
