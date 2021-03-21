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
        /// <summary>
        /// Static method used for reading all lines in a text file
        /// </summary>
        /// <param name="filePath"></param>
        /// <returns>A list with strings where each string represents a line in the text file</returns>
        public static string[] GetInvoiceItems(string filePath)
        {
            if (String.IsNullOrWhiteSpace(filePath))
            {
                throw new ArgumentNullException("filePath", "filePath cannot be null or empty");
            }

            try
            {
                return File.ReadAllLines(filePath);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
