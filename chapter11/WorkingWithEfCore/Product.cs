using System.ComponentModel.DataAnnotations;

using System.ComponentModel.DataAnnotations.Schema;

namespace Packt.Shared

{

    public class Product

    {

        public int? SupplierID { get; set; }


        [StringLength(20)]
        public string QuantityPerUnit { get; set; }

        //public short? UnitsInStock { get; set; }

        //public short? UnitsOnOrder { get; set; }

        public short? ReorderLevel { get; set; }



        public int ProductID { get; set; }

        [Required]
        [StringLength(40)]
        public string? ProductName { get; set; }

        [Column("UnitPrice", TypeName = "money")]
        public decimal? Cost { get; set; }
        //public decimal? UnitPrice { get; set; }

        [Column("UnitsInStock")]
        public short? Stock { get; set; }

        public bool Discontinued { get; set; }

        // these two define the foreign key relationship

        // to the Categories table

        public int CategoryID { get; set; }

        public virtual Category? Category { get; set; }

    }

}