namespace QuanLyCuaHangTapHoa.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Web;

    public partial class Product
    {

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Product()
        {
            this.Order_Detail = new HashSet<Order_Detail>();
        }

        public int Id { get; set; }
        public Nullable<int> CatalogId { get; set; }
        public string Picture { get; set; }
        public string ProductName { get; set; }
        public string ProductCode { get; set; }
        public Nullable<double> UnitPrice { get; set; }
        public Nullable<int> ProductSold { get; set; }
        public string ProductSale { get; set; }
        public Nullable<double> PriceOld { get; set; }
        [Required(ErrorMessage = "Vui lòng nhập số lượng")]
        [Range(0, int.MaxValue, ErrorMessage = "Vui lòng nhập số lượng > 0")]
        public Nullable<int> SoLuong { get; set; }
        public Nullable<System.DateTime> NgayNhapHang { get; set; }
        [NotMapped]
        public HttpPostedFileBase ProductThumbnailStream { get; set; }
        public virtual Catalog Catalog { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Order_Detail> Order_Detail { get; set; }

        [NotMapped]
        public string FullPicturePath
        {
            get
            {
                if (string.IsNullOrEmpty(Picture))
                    return null;
                return $"/Resources/Pictures/Products/{Picture}";
            }
        }
    }
}
