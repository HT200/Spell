using System;

namespace Dataset_Filter
{
    class Program
    {
        static void Main(string[] args)
        {
            FileManager fileManager = new FileManager();
            fileManager.CreateFile(fileManager.GetFilePath("english3.txt"), "english.txt");
        }
    }
}
