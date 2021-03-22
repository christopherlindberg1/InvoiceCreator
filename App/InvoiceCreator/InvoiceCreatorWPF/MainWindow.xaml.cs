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
using Microsoft.Win32;

namespace InvoiceCreatorWPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private Invoice _invoice;






        // ======================== Properties ======================== //

        public Invoice Invoice
        {
            get => _invoice;

            set => _invoice = value;
        }






        // ======================== Methods ======================== //

        public MainWindow()
        {
            InitializeComponent();
        }





        // ======================== Event handler methods ======================== //

        private void LoadInvoice_EventHandler()
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.InitialDirectory = FilePaths.InvoicesDataFolderPath;
            openFileDialog.Title = "Choose invoice to open";
            openFileDialog.Filter = "Text Files | *.txt";

            bool? result = openFileDialog.ShowDialog();

            if (result == null || result == false)
            {
                return;
            }

            try
            {
                string[] invoiceItems = TextFileUtility.GetInvoiceItems(openFileDialog.FileName);
                Invoice = new Invoice(invoiceItems);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }





        // ======================== Events ======================== //

        private void btnLoadInvoice_Click(object sender, RoutedEventArgs e)
        {
            LoadInvoice_EventHandler();
        }
    }
}
