using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class Invoice
    {
        private readonly string[] _items;
        
        public string[] Items
        {
            get => _items;

            init => _items = value ??
                throw new ArgumentNullException("Items", "Items cannot be null");
        }

        public Invoice(string[] items)
        {
            Items = items;
        }
    }
}
