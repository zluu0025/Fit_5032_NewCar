namespace Fit_5032_NewCar.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Booking")]
    public partial class Booking
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Booking()
        {
            Order_Line = new HashSet<Order_Line>();
        }

        public int BookingID { get; set; }

        public DateTime BookingTime { get; set; }

        public DateTime RentingStart { get; set; }

        public DateTime RentingEnd { get; set; }

        public int PickUP_LocationCode { get; set; }

        [Required]
        [StringLength(50)]
        public string Contact_PhoneNumber { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Order_Line> Order_Line { get; set; }

        public virtual Location Location { get; set; }
    }
}
