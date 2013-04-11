using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Capital_Data_Driver.Models.Entities
{
    public partial class Invoice
    {

        [Column(ColumnName: "INVOICENO", IsID: true)]
        public string InvoiceNumber;

        [Column(ColumnName: "DEPARTMENT")]
        public string Department;


    }
}
