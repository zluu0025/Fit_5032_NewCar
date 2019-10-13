namespace Fit_5032_NewCar.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Car")]
    public partial class Car
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Car()
        {
            Order_Line = new HashSet<Order_Line>();
        }

        public int CarID { get; set; }

        [Required]
        public string CarVin { get; set; }

        [Required]
        public string CarMark { get; set; }

        [Required]
        public string CarModel { get; set; }

        [Required]
        public string CarType { get; set; }

        public double CarPrice { get; set; }

        public DateTime CarRegisterDate { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Order_Line> Order_Line { get; set; }
    }
}
