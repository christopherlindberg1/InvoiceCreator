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







        private void AddInvoiceDataToGUI()
        {
            if (Invoice == null)
            {
                throw new ArgumentNullException("Invoice", "Invoice cannot be null when calling this method");
            }

            textBlockInvoiceNumber.Text = Invoice.InvoiceNumber;
            textBlockInvoiceDate.Text = Invoice.Date.ToShortDateString();
            textBlockInvoiceDueDate.Text = Invoice.DueDate.ToShortDateString();

            // Receiver info
            textBlockReceiverCompany.Text = Invoice.ReceiverCompanyName;
            textBlockReceiverNameOfPerson.Text = Invoice.ReceiverPersonName;
            textBlockReceiverStreetAddress.Text = Invoice.ReceiverStreetAddress;
            textBlockReceiverZipAndCity.Text = Invoice.ReceiverZipAndCity;
            textBlockReceiverCountry.Text = Invoice.ReceiverCountry;

            // Sender info
            textBlockSenderStreetAddress.Text = Invoice.SenderStreetAddress;
            textBlockSenderPhone.Text = Invoice.SenderPhone;
            textBlockSenderSenderHomePage.Text = Invoice.SenderHomePage;
            textBlockSenderZipAndCity.Text = Invoice.SenderZipAndCity;

            foreach (InvoiceItem invoiceItem in Invoice.Items)
            {
                dataGridInvoiceItems.Items.Add(invoiceItem);
            }
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

                AddInvoiceDataToGUI();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void AddLogo_EventHandler()
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.InitialDirectory = FilePaths.ImagesRootFolder;
            openFileDialog.Title = "Choose invoice to open";
            openFileDialog.Filter = "All|*.*|JPG|*.jpg|JPEG|*.jpeg|PNG|*.png";

            bool? result = openFileDialog.ShowDialog();

            if (result == null || result == false)
            {
                return;
            }

            Uri imageUri = new Uri(openFileDialog.FileName, UriKind.Absolute);

            imageLogo.Source = new BitmapImage(imageUri);
        }





        // ======================== Events ======================== //

        private void btnLoadInvoice_Click(object sender, RoutedEventArgs e)
        {
            LoadInvoice_EventHandler();
        }

        private void btnAddInvoiceLogo_Click(object sender, RoutedEventArgs e)
        {
            AddLogo_EventHandler();
        }
    }
}
