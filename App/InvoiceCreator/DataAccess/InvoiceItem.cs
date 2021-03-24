using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class InvoiceItem
    {
        private string _description;
        private int _quantity;
        private decimal _unitPrice;
        private decimal _taxInPercent;

        public string Description
        {
            get => _description;

            set
            {
                if (value.Length > 50)
                {
                    throw new ArgumentOutOfRangeException(
                        "Description", "Description cannot be more than 50 characters");
                }

                _description = value ??
                    throw new ArgumentNullException("Description", "Description cannot be null");
            }
        }

        public int Quantity
        {
            get => _quantity;

            set
            {
                if (value < 1)
                {
                    throw new ArgumentOutOfRangeException("Quantity", "Quantity cannot be less than 1");
                }

                _quantity = value;
            }
        }

        public decimal UnitPrice
        {
            get => _unitPrice;

            set
            {
                if (value <= 0)
                {
                    throw new ArgumentOutOfRangeException(
                        "UnitPrice", "UnitPrice cannot be equal to or less than 0");
                }

                _unitPrice = value;
            }
        }

        public decimal TaxInPercent
        {
            get => _taxInPercent;

            set
            {
                if (value < 0 || value > 100)
                {
                    throw new ArgumentOutOfRangeException("TaxInPercent", "TaxInPercent must be in the range 0-100%");
                }

                _taxInPercent = value;
            }
        }

        public decimal TotalTax
        {
            get => UnitPrice * Quantity * (TaxInPercent / 100);
        }

        public decimal Total
        {
            get => UnitPrice * Quantity + TotalTax;
        }
    }
}
