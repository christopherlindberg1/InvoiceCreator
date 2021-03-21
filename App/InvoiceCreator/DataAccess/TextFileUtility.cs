using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace DataAccess
{
    public class TextFileUtility
    {
        public static List<string> ReadLines(string filePath)
        {
            if (String.IsNullOrWhiteSpace(filePath))
            {
                throw new ArgumentNullException("filePath", "filePath cannot be null or empty");
            }

            List<string> lines = new List<string>();

            try
            {
                lines = File.ReadAllLines(filePath).ToList<string>();

                return lines;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
