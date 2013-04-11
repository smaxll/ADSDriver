namespace ADSDriver.Models.Entities
{
    public partial class Invoice
    {

        [Column(ColumnName: "INVOICENO", IsID: true)]
        public string InvoiceNumber;

        [Column(ColumnName: "DEPARTMENT")]
        public string Department;


    }
}
