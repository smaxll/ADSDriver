namespace ADSDriver.Models.Entities
{
    public partial class MasterParts
    {
        public virtual string ID { get; set; }
        public virtual string Description { get; set; }
        public virtual string Type { get; set; }
        public virtual string Retail { get; set; }
        public virtual string ABS { get; set; }
        public virtual string DBS { get; set; }
        public virtual string CNS { get; set; }
        public virtual string WIS { get; set; }
        public virtual string NDC { get; set; }
        public virtual string NTS { get; set; }
        public virtual string ROS { get; set; }
        public virtual string ZNW { get; set; }
        public virtual string ImageLocation { get; set; }
        public virtual string DocumentLocation { get; set; }
        public virtual string RItem { get; set; }
        public virtual string ItemType { get; set; }
        public virtual string Barcode { get; set; }
        public virtual string AuxNote { get; set; }

    }

}
