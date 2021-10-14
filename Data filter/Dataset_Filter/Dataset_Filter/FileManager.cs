using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Dataset_Filter
{
    class FileManager
    {
        /// <summary>
        /// Get .txt file's directory
        /// </summary>
        /// <param name="fileName">.txt file's name</param>
        public string GetFilePath(string fileName)
        {
            return Path.Combine(Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location), fileName);
        }

        /// <summary>
        /// Create a filtered dataset
        /// </summary>
        /// <param name="filePath">Unfiltered dataset</param>
        /// <param name="name">Filtered dataset</param>
        public void CreateFile(string filePath, string name)
        {
            string fileName = Path.Combine(Directory.GetParent(Environment.CurrentDirectory).Parent.FullName, name);

            try
            {
                // Check if file already exists. If yes, delete it.     
                if (File.Exists(fileName))
                {
                    File.Delete(fileName);
                }

                // Open the stream and read it back.
                using (StreamWriter wr = new StreamWriter(fileName))
                {
                    using (StreamReader sr = File.OpenText(filePath))
                    {
                        string line;
                        while ((line = sr.ReadLine()) != null)
                        {
                            if ((line.Length >= 3) && (line.Length <= 16))
                            {
                                wr.WriteLine(line);
                            }
                        }
                    }
                }
            }
            catch (Exception Ex)
            {
                Console.WriteLine(Ex.ToString());
            }
        }
    }
}
