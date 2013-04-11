using Capital_Data_Driver.Generic;

namespace ADSDriver.Models.Tables
{
    public class Invoice : TGenericTable<ADSDriver.Models.Entities.Invoice>
    {
        public Invoice()
        {
            _TableName = "Invoice";
        }
        public ADSDriver.Models.Entities.Invoice FindInvoice(string InvoiceNo)
        {

            return null;
        }
    }
}
