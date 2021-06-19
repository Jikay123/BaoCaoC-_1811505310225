namespace ModelEF.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Product")]
    public partial class Product
    {
        [StringLength(10)]
        [Display(Name = "Mã sản phẩm: ")]
        [Required(ErrorMessage = "Value is required")]
        public string ID { get; set; }

        
        [Display(Name = "Tên sản phẩm: ")]
        [Required(ErrorMessage = "Value is required")]
        [StringLength(50)]
        public string Name { get; set; }

        [Required(ErrorMessage = "Value is required")]
        [Display(Name = "Giá tiền: ")]
        [Range(1000000, 100000000, ErrorMessage = "Salary must be between 1000000 and 100000000")]
        public decimal UnitCost { get; set; }

        [Required(ErrorMessage = "Value is required")]
        [Display(Name = "Số lượng: ")]
        [Range(1, 1000, ErrorMessage = "Salary must be between 1 and 1000")]
        public int Quantity { get; set; }

        [StringLength(50)]
        [Display(Name = "Hình ảnh: ")]
        public string Image { get; set; }

        [StringLength(50)]
        [Display(Name = "Mô tả sản phẩm: ")]
        public string Description { get; set; }

        [StringLength(50)]
        [Display(Name = "Trạng thái: ")]
        public string Status { get; set; }

        [Required]
        [StringLength(10)]
        [Display(Name = "Loại sản phẩm: ")]
        public string CategoryID { get; set; }

        public virtual Category Category { get; set; }
    }
}
