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
        private DateTime _invoiceDate;
        private DateTime _dueDate;
        private string _receiverCompanyName;
        private string _receiverPersonName;
        private string _receiverStreetAddress;
        private string _receiverZipCode;
        private string _receiverCity;
        private string _receiverCountry;
        private int _numberOfItems;  // Maybe remove
        private List<InvoiceItem> _items;
        private string _senderCompanyName;
        private string _senderStreetAddress;
        private string _senderZipCode;
        private string _senderCity;
        private string _senderCountry;
        private string _senderPhone;
        private string _homePage;






        

        public Invoice(string[] items)
        {

        }
    }
}
