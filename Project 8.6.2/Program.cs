using System;
using System.IO;

namespace Task2
{
    class Program
    {
        public static void Main(string[] args)
        {
            try
            {
                DirectoryInfo Folder = new DirectoryInfo("C:\\Repository");
                long TotalFolderSize = FolderSize(Folder);
                Console.WriteLine("Размер папки в байтах: " + TotalFolderSize);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        static long FolderSize(DirectoryInfo Folder)
        {
            if (Folder.Exists)
            {
                long TotalSizeOfDir = 0;

                FileInfo[] AllFiles = Folder.GetFiles();
                foreach (FileInfo File in AllFiles)
                {
                    TotalSizeOfDir += File.Length;
                }

                DirectoryInfo[] SubFolders = Folder.GetDirectories();
                foreach (DirectoryInfo dir in SubFolders)
                {
                    TotalSizeOfDir += FolderSize(dir);
                }

                return TotalSizeOfDir;

            }
            else
            {
                Console.WriteLine("Такой папки не существует");
                return 0;
            }
        }
    }
}