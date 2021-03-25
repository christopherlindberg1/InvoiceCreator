using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    /// <summary>
    /// Class containing file paths that are used within the app.
    /// </summary>
    public class FilePaths
    {
        private static string AppRootPath
        {
            get
            {
                return Path.GetFullPath(
                    Path.Combine(Directory.GetCurrentDirectory(), @"..\..\..\..\"));
            }
        }

        public static string DataStorageRootFolderPath
        {
            get
            {
                return Path.GetFullPath(
                    Path.Combine(AppRootPath, @".\DataAccess\Storage\"));
            }
        }

        public static string InvoicesDataFolderPath
        {
            get
            {
                return Path.GetFullPath(
                    Path.Combine(DataStorageRootFolderPath, @".\Invoices\RawFiles\"));
            }
        }

        public static string PrintedInvoicesFolderPath
        {
            get
            {
                return Path.GetFullPath(
                    Path.Combine(DataStorageRootFolderPath, @".\Invoices\PrintedInvoices\"));
            }
        }

        public static string ImagesRootFolder
        {
            get
            {
                return Path.GetFullPath(
                    Path.Combine(AppRootPath, @".\InvoiceCreatorWPF\Images\"));
            }
        }
    }
}
