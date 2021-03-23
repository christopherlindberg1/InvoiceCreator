using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class Invoice
    {
        private string _invoiceNumber;
        private DateTime _date;
        private DateTime _dueDate;
        private string _receiverCompanyName;
        private string _receiverPersonName;
        private string _receiverStreetAddress;
        private string _receiverZipCode;
        private string _receiverCity;
        private string _receiverCountry;
        //private int _numberOfItems;  // Maybe remove
        private List<InvoiceItem> _items;
        private string _senderCompanyName;
        private string _senderStreetAddress;
        private string _senderZipCode;
        private string _senderCity;
        private string _senderCountry;
        private string _senderPhone;
        private string _homePage;

        public string InvoiceNumber
        {
            get => _invoiceNumber;

            set => _invoiceNumber = value ??
                throw new ArgumentException("InvoiceNumber", "InvoiceNumber cannot be null");
        }

        public DateTime Date
        {
            get => _date;

            set => _date = value;
        }

        public DateTime DueDate
        {
            get => _dueDate;

            set => _dueDate = value;
        }

        public string ReceiverCompanyName
        {
            get => _receiverCompanyName;

            set => _receiverCompanyName = value ??
                throw new ArgumentException("ReceiverCompanyName", "ReceiverCompanyName cannot be null");
        }

        public string ReceiverPersonName
        {
            get => _receiverPersonName;

            set => _receiverPersonName = value ??
                throw new ArgumentException("ReceiverPersonName", "ReceiverPersonName cannot be null");
        }

        public string ReceiverStreetAddress
        {
            get => _receiverStreetAddress;

            set => _receiverStreetAddress = value ??
                throw new ArgumentException("ReceiverStreetAddress", "ReceiverStreetAddress cannot be null");
        }

        public string ReceiverZipCode
        {
            get => _receiverZipCode;

            set => _receiverZipCode = value ??
                throw new ArgumentException("ReceiverZipCode", "ReceiverZipCode cannot be null");
        }

        public string ReceiverCity
        {
            get => _receiverCity;

            set => _receiverCity = value ??
                throw new ArgumentException("ReceiverCity", "ReceiverCity cannot be null");
        }

        public string ReceiverCountry
        {
            get => _receiverCountry;

            set => _receiverCountry = value ??
                throw new ArgumentException("ReceiverCountry", "ReceiverCountry cannot be null");
        }

        public List<InvoiceItem> Items
        {
            get => _items;
        }

        public string SenderCompanyName
        {
            get => _senderCompanyName;

            set => _senderCompanyName = value ??
                throw new ArgumentException("SenderCompanyName", "SenderCompanyName cannot be null");
        }

        public string SenderStreetAddress
        {
            get => _senderStreetAddress;

            set => _senderStreetAddress = value ??
                throw new ArgumentException("SenderStreetAddress", "SenderStreetAddress cannot be null");
        }

        public string SenderZipCode
        {
            get => _senderZipCode;

            set => _senderZipCode = value ??
                throw new ArgumentException("SenderZipCode", "SenderZipCode cannot be null");
        }

        public string SenderCity
        {
            get => _senderCity;

            set => _senderCity = value ??
                throw new ArgumentException("SenderCity", "SenderCity cannot be null");
        }

        public string SenderCountry
        {
            get => _senderCountry;

            set => _senderCountry = value ??
                throw new ArgumentException("SenderCountry", "SenderCountry cannot be null");
        }

        public string SenderPhone
        {
            get => _senderPhone;

            set => _senderPhone = value ??
                throw new ArgumentException("SenderPhone", "SenderPhone cannot be null");
        }

        public string HomePage
        {
            get => _homePage;

            set => _homePage = value ??
                throw new ArgumentException("HomePage", "HomePage cannot be null");
        }








        public Invoice(string[] items)
        {

        }
    }
}
