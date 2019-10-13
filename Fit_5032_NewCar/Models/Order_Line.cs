namespace Fit_5032_NewCar.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Order_Line
    {
        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int BookingBookingID { get; set; }

        public DateTime ReturnDate { get; set; }

        [Required]
        public string ReturnStatus { get; set; }

        [Key]
        [Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int OlCarID { get; set; }

        public virtual Booking Booking { get; set; }

        public virtual Car Car { get; set; }
    }
}
