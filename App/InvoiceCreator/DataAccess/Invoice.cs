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
        private int _numberOfItems;
        private List<InvoiceItem> _items;
        private string _senderCompanyName;
        private string _senderStreetAddress;
        private string _senderZipCode;
        private string _senderCity;
        private string _senderCountry;
        private string _senderPhone;
        private string _senderHomePage;

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

        public string ReceiverZipAndCity
        {
            get => $"{ ReceiverZipCode } { ReceiverCity }";
        }

        public string ReceiverCountry
        {
            get => _receiverCountry;

            set => _receiverCountry = value ??
                throw new ArgumentException("ReceiverCountry", "ReceiverCountry cannot be null");
        }

        public int NumberOfItems
        {
            get => _numberOfItems;

            set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException(
                        "NumberOfItems", "NumberOfItems cannot be less than 0");
                }

                _numberOfItems = value;
            }
        }

        public List<InvoiceItem> Items
        {
            get => _items;

            init
            {
                if (value == null)
                {
                    throw new ArgumentNullException("Items", "Items cannot be null");
                }

                _items = value;
            }
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

        public string SenderZipAndCity
        {
            get => $"{ SenderZipCode } { SenderCity }";
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

        public string SenderHomePage
        {
            get => _senderHomePage;

            set => _senderHomePage = value ??
                throw new ArgumentException("SenderHomePage", "SenderHomePage cannot be null");
        }

        public decimal TotalTax
        {
            get => Items.Sum(item => item.TotalTax);
            //get
            //{
            //    decimal sum = 0;

            //    foreach (InvoiceItem item in Items)
            //    {
            //        sum += item.TotalTax;
            //    }

            //    return sum;
            //}
        }

        public decimal Total
        {
            get => Items.Sum(item => item.Total);
        }




        public Invoice(string[] items)
        {
            // The parsing could throw a FormatExceptions if the indices doesn't match lines
            // in the text file from which "items" was generated.
            try
            {
                InvoiceNumber = items[0];
                Date = DateTime.Parse(items[1]);
                DueDate = DateTime.Parse(items[2]);
                ReceiverCompanyName = items[3];
                ReceiverPersonName = items[4];
                ReceiverStreetAddress = items[5];
                ReceiverZipCode = items[6];
                ReceiverCity = items[7];
                ReceiverCountry = items[8];
                NumberOfItems = int.Parse(items[9]);

                // Create InvoiceItem objects and add them to the Items list
                Items = new List<InvoiceItem>();

                int index = 10;

                for (int i = 0; i < NumberOfItems; i++)
                {
                    InvoiceItem invoiceItem = new InvoiceItem();

                    invoiceItem.ItemInOrder = i + 1;
                    // Each invoice item will increment the index with 4 since each invoice item has 4 fields
                    invoiceItem.Description = items[index++];
                    invoiceItem.Quantity = int.Parse(items[index++]);

                    // Parse the decimal values. Change between period and comma to make it work 
                    // on the system running the app.
                    string unitPriceString = items[index++];
                    decimal unitPrice;

                    if (decimal.TryParse(unitPriceString, out unitPrice) == false)
                    {
                        if (unitPriceString.Contains('.'))
                        {
                            string updatedUnitPriceString = unitPriceString.Replace('.', ',');
                            unitPrice = decimal.Parse(updatedUnitPriceString);
                        } else
                        {
                            string updatedUnitPriceString = unitPriceString.Replace(',', '.');
                            unitPrice = decimal.Parse(updatedUnitPriceString);
                        }
                    }

                    invoiceItem.UnitPrice = unitPrice;
                    invoiceItem.TaxInPercent = decimal.Parse(items[index++]);

                    Items.Add(invoiceItem);
                }

                SenderCompanyName = items[index++];
                SenderStreetAddress = items[index++];
                SenderZipCode = items[index++];
                SenderCity = items[index++];
                SenderCountry = items[index++];
                SenderPhone = items[index++];
                SenderHomePage = items[index++];
            }
            // Just throw the exceptions to the caller.
            catch (FormatException)
            {
                throw;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
