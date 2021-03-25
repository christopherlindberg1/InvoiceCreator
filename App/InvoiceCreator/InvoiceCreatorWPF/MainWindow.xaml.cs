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
using System.ComponentModel;
using System.Windows.Xps.Packaging;
using System.IO;

namespace InvoiceCreatorWPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private Invoice _invoice;
        private ErrorMessageHandler _errorMessageHandler = new ErrorMessageHandler();





        // ======================== Properties ======================== //

        public Invoice Invoice
        {
            get => _invoice;

            set => _invoice = value;
        }

        public ErrorMessageHandler ErrorMessageHandler
        {
            get => _errorMessageHandler;

            set => _errorMessageHandler = value ??
                throw new ArgumentNullException("ErrorMessageHandler", "ErrorMessageHandler cannot be null");
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
            datePickerInvoiceDate.SelectedDate = Invoice.Date;
            datePickerInvoiceDueDate.SelectedDate = Invoice.DueDate;

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

            dataGridInvoiceItems.Items.Clear();
            foreach (InvoiceItem invoiceItem in Invoice.Items)
            {
                dataGridInvoiceItems.Items.Add(invoiceItem);
            }

            textBlockTotalCost.Text = Invoice.Total.ToString();
            textBlockTotalTax.Text = Invoice.TotalTax.ToString();
        }

        private bool ValidateDiscount()
        {
            decimal discount = 0;
            bool couldParse = false;

            string input = textBoxDiscount.Text;

            // If field is empty it still has to validate as a discount of 0
            if (String.IsNullOrWhiteSpace(input))
            {
                return true;
            }

            if (decimal.TryParse(input, out discount) == false)
            {
                if (input.Contains('.'))
                {
                    string updatedInput = input.Replace('.', ',');
                    couldParse = decimal.TryParse(updatedInput, out discount);
                }
                else if (input.Contains(','))
                {
                    string updatedInput = input.Replace(',', '.');
                    couldParse = decimal.TryParse(updatedInput, out discount);
                }
                
                if (couldParse == false)
                {
                    ErrorMessageHandler.AddMessage(
                        "You must provice a whole or a decimal number. Try comma or period for decimal numbers.");

                    return false;
                }
            }

            if (discount < 0)
            {
                ErrorMessageHandler.AddMessage("The discount cannot be less than 0");

                return false;
            }

            return true;
        }

        private void ClearInputFields()
        {
            textBoxDiscount.Text = "";
        }

        private void UpdateInvoiceDataInGUI()
        {
            textBlockTotalCost.Text = Invoice.Total.ToString();
            textBlockTotalTax.Text = Invoice.TotalTax.ToString();
        }





        // ======================== Event handler methods ======================== //

        private void LoadInvoice()
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

        private void AddLogo()
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

        private void AddDiscount()
        {
            bool inputAndStateOk = true;
            string input = textBoxDiscount.Text;
            decimal discount = 0;

            if (Invoice == null)
            {
                ErrorMessageHandler.AddMessage("You must load the invoice before adding a discount");
                inputAndStateOk = false;
            }
            // Discount is 0 if field is empty
            else if (String.IsNullOrWhiteSpace(input))
            {
                inputAndStateOk = true;
            }
            else if (ValidateDiscount() == false)
            {
                inputAndStateOk = false;
            }
            else
            {
                discount = decimal.Parse(input);
                if (discount > Invoice.TotalWithoutDiscount)
                {
                    ErrorMessageHandler.AddMessage("The discount cannot be graeter than the total cost");
                    inputAndStateOk = false;
                }
            }

            if (inputAndStateOk == false)
            {
                MessageBox.Show(
                    ErrorMessageHandler.GetMessages(),
                    "Info",
                    MessageBoxButton.OK,
                    MessageBoxImage.Information);

                return;
            }

            Invoice.Discount = discount;
            UpdateInvoiceDataInGUI();
        }

        private void PrintInvoice()
        {
            try
            {
                this.IsEnabled = false;

                PrintDialog printDialog = new PrintDialog();

                if (printDialog.ShowDialog() == true)
                {
                    printDialog.PrintVisual(printContent, "Invoice");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            finally
            {
                this.IsEnabled = true;
            }
        }





        // ======================== Events ======================== //

        private void btnLoadInvoice_Click(object sender, RoutedEventArgs e)
        {
            LoadInvoice();
        }

        private void btnAddInvoiceLogo_Click(object sender, RoutedEventArgs e)
        {
            AddLogo();
        }

        private void btnSaveDiscount_Click(object sender, RoutedEventArgs e)
        {
            AddDiscount();
        }

        private void btnPrintInvoice_Click(object sender, RoutedEventArgs e)
        {
            PrintInvoice();
        }
    }
}
