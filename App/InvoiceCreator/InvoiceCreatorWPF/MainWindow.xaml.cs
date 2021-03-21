using DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using DataAccess;
using Microsoft.Win32;

namespace InvoiceCreatorWPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            //OpenFileDialog openFileDialog = new OpenFileDialog();
            //openFileDialog.InitialDirectory = FilePaths.InvoicesDataFolderPath;
            //openFileDialog.Title = "Choose invoice to open";
            //openFileDialog.Filter = "Text Files | *.txt";
            
            //bool? result = openFileDialog.ShowDialog();

            //if (result == null || result == false)
            //{
            //    return;
            //}

            //string filePath = System.IO.Path.GetFullPath(
            //        System.IO.Path.Combine(FilePaths.InvoicesDataFolderPath, @".\InvoiceDemo1.txt"));

            //List<string> lines = TextFileUtility.ReadAllLines(openFileDialog.FileName);

            //MessageBox.Show(lines.Count.ToString());


        }
    }
}
