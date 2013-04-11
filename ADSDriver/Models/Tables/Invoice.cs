using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Capital_Data_Driver.Models.Tables
{
    public class Invoice : Generic.TGenericTable<Entities.Invoice>
    {
        public Invoice()
        {
            _TableName = "Invoice";
        }
        public Entities.Invoice FindInvoice(string InvoiceNo)
        {

            return null;
        }
    }
}
